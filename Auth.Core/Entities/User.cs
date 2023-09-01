using Auth.Core.Entities.Abstracts;

namespace Auth.Core.Entities
{
    public class User:BaseEntity
    {
        public string UserName { get; set; } = null!;
        public string Email { get;set; } = null!;
        public byte[] PasswordHash { get; set;} = new byte[32];
        public byte[] PasswordSalt { get; set; } = new byte[32];
        //public string? VerificationToken { get; set; }
        //public DateTime? VerifiedAt { get; set; }
        //public string? PasswordResetToken { get; set; }
        //public DateTime? ResetTokenExpire { get; set; }
    }
}
