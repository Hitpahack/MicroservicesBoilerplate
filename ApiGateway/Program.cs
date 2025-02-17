using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);
builder.Services.AddControllers();

// Add Swagger and Ocelot
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "API Gateway", Version = "v1" });

    // Manually Add Order and Payment Services
    c.SwaggerDoc("order", new OpenApiInfo { Title = "Order Service", Version = "v1" });
    c.SwaggerDoc("payment", new OpenApiInfo { Title = "Payment Service", Version = "v1" });
});
builder.Services.AddOcelot();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer("Bearer", options =>
    {
        options.Authority = "https://your-auth-server.com"; // Change this to your identity provider
        options.Audience = "your-api-audience"; // Change this to your API resource identifier
    });
var app = builder.Build();

// Configure middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Gateway v1");
        c.SwaggerEndpoint("https://localhost:7001/swagger/v1/swagger.json", "Order Service");
        c.SwaggerEndpoint("https://localhost:7002/swagger/v1/swagger.json", "Payment Service");
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers(); // Maps controller endpoints

// Use Ocelot as the last middleware
app.UseOcelot().Wait();

app.Run();
