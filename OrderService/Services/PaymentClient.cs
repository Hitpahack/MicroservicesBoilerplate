using OrderService.DTOs;
using System.Text.Json;
using System.Text;

namespace OrderService.Services
{
    public class PaymentClient : IPaymentClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _paymentServiceUrl;

        public PaymentClient(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _paymentServiceUrl = configuration["PaymentServiceUrl"];
        }
        public async Task<PaymentResponse> ProcessPayment(PaymentRequest paymentRequest)
        {
            var jsonContent = JsonSerializer.Serialize(paymentRequest);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync($"{_paymentServiceUrl}/api/payments/process", content);

            var responseBody = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"🔍 Raw Payment API Response: {responseBody}"); // ✅ Log response

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Failed to process payment. Status Code: {response.StatusCode}");
            }

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true // ✅ Ensures case insensitivity in deserialization
            };

            var paymentResponse = JsonSerializer.Deserialize<PaymentResponse>(responseBody, options);
            Console.WriteLine($"✅ Deserialized PaymentResponse: {JsonSerializer.Serialize(paymentResponse)}"); // ✅ Log object

            return paymentResponse;
        }

    }
}
