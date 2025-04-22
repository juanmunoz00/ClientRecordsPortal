using System.Net;
using System.Net.Http.Headers;
using Xunit;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ClientRecordsAPI.DTOs;

namespace ClientRecordsAPI.Tests.Integration
{
    public class ClientsControllerIntegrationTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public ClientsControllerIntegrationTests(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task PostClient_ShouldReturnCreated()
        {
            // Step 1: Log in to get a token
            var login = new LoginRequestDto
            {
                Username = "admin",
                Password = "password"
            };
            var loginJson = JsonConvert.SerializeObject(login);
            var loginContent = new StringContent(loginJson, Encoding.UTF8, "application/json");
            
            var loginResponse = await _client.PostAsync("/api/Auth/login", loginContent);
            loginResponse.EnsureSuccessStatusCode();

            var loginResponseBody = await loginResponse.Content.ReadAsStringAsync();
            var tokenObj = JsonConvert.DeserializeObject<LoginResponseDto>(loginResponseBody);

            _client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", tokenObj!.Token);

            // Step 2: Now test POST /api/Clients
            var newClient = new CreateClientDto
            {
                FullName = "Test User",
                Email = "test@example.com",
                Phone = "1234567890"
            };

            var json = JsonConvert.SerializeObject(newClient);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync("/api/Clients", content);
            var responseBody = await response.Content.ReadAsStringAsync();

            Console.WriteLine($"🚨 Server responded with: {response.StatusCode}");
            Console.WriteLine($"🔍 Response body: {responseBody}");

            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        }
    

    }
}
