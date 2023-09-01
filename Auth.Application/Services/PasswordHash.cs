using System.Security.Cryptography;

namespace Auth.Application.Services
{
    public static class PasswordHash
    {
        public static void CreatePasswordHash(string password , out byte[] passHash , out byte[] passSalt )
        {
            using var hmac = new HMACSHA512();
            passSalt = hmac.Key;
            passHash = hmac.ComputeHash( System.Text.Encoding.UTF8.GetBytes(password));
        }

        public static bool VerifyPasswordHash(string password,byte[] passHash,byte[] passSalt)
        {
            using var hmac =new HMACSHA512(passSalt);
            var computeHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            return computeHash.SequenceEqual( passHash );
        }
    }
}
