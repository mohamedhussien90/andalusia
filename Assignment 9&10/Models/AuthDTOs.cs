namespace Assignment_8.Models
{
    public class AuthDTOs
    {
        public class RegisterRequest {
            public string Email { get; set; } 
            public string Password { get; set; } 
        }
        public class LoginRequest {
            public string Email { get; set; } 
            public string Password { get; set; } 
        }
    }
}

