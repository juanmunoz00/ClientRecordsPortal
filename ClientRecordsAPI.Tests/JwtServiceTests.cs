using Xunit;
using ClientRecordsAPI.Services;
using Microsoft.Extensions.Configuration;

namespace ClientRecordsAPI.Tests
{
    public class JwtServiceTests
    {
        [Fact]
        public void GenerateToken_ShouldReturnValidToken()
        {
            // Arrange
            var inMemorySettings = new Dictionary<string, string> {
                {"JwtSettings:Key", "supersecurekeywith32chars!!ABC123"},
                {"JwtSettings:Issuer", "ClientRecordsAPI"},
                {"JwtSettings:Audience", "ClientRecordsAPIUsers"},
                {"JwtSettings:DurationInMinutes", "60"}
            };

            IConfiguration configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(inMemorySettings)
                .Build();

            var jwtService = new JwtService(configuration);

            // Act
            var token = jwtService.GenerateToken("1", "Admin");

            // Assert
            Assert.False(string.IsNullOrWhiteSpace(token));
        }
    }
}
