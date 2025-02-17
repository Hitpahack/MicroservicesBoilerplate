using Microsoft.EntityFrameworkCore;
using OrderService.Data;
using OrderService.Middleware;
using OrderService.Services;
var builder = WebApplication.CreateBuilder(args);

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("https://localhost:7000") // API Gateway URL
                                .AllowAnyMethod()
                                .AllowAnyHeader();
                      });
});
// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("OrderDb");
builder.Services.AddDbContext<OrderDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient<IPaymentClient, PaymentClient>();
builder.Services.AddScoped<IOrderService, OrderService.Services.OrderService>();

var app = builder.Build();

app.UseCors(MyAllowSpecificOrigins);

// Add custom middleware
app.UseMiddleware<RequestLoggingMiddleware>(); 
app.UseMiddleware<ExceptionHandlingMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Order Service API");
        c.RoutePrefix = "swagger"; // Keeps Swagger UI available at /swagger
    });
}

app.UseHttpsRedirection();



app.UseAuthorization();

app.MapControllers();   

app.Run();
