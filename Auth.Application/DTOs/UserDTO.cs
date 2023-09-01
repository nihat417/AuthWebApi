namespace Auth.Application.DTOs
{
    public class UserDTO
    {
        public string UserName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        //public string ConfirmPassword { get; set; } = null!;
    }
}
