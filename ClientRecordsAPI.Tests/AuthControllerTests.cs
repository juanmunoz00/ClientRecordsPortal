using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using ClientRecordsAPI.Controllers;
using ClientRecordsAPI.Services;
using ClientRecordsAPI.DTOs;

namespace ClientRecordsAPI.Tests
{
    public class AuthControllerTests
    {
        [Fact]
        public void Login_WithValidCredentials_ReturnsToken()
        {
            // Arrange
            var mockJwtService = new Mock<JwtService>(null!);
            mockJwtService.Setup(j => j.GenerateToken("1", "Admin"))
                          .Returns("fake-jwt-token");

            var controller = new AuthController(mockJwtService.Object);
            var loginRequest = new LoginRequestDto
            {
                Username = "admin",
                Password = "password"
            };

            // Act
            var result = controller.Login(loginRequest);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var payload = Assert.IsType<LoginResponseDto>(okResult.Value);
            Assert.Equal("fake-jwt-token", payload.Token);
        }

        [Fact]
        public void Login_WithInvalidCredentials_ReturnsUnauthorized()
        {
            // Arrange
            var mockJwtService = new Mock<JwtService>(null!);
            var controller = new AuthController(mockJwtService.Object);
            var loginRequest = new LoginRequestDto
            {
                Username = "wrong",
                Password = "bad"
            };

            // Act
            var result = controller.Login(loginRequest);

            // Assert
            Assert.IsType<UnauthorizedObjectResult>(result);
        }
    }
}
