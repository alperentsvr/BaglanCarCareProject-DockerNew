namespace BaglanCarCare.Application.DTOs
{
    public class LoginDto { public string Username { get; set; } public string Password { get; set; } }
    public class RegisterDto { public string Username { get; set; } public string Password { get; set; } public string FullName { get; set; } public string Role { get; set; } }
    public class TokenDto { public string Token { get; set; } public string Role { get; set; } public string FullName { get; set; } public DateTime Expiration { get; set; } }
}