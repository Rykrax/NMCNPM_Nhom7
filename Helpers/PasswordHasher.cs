namespace NMCNPM_Nhom7.Helpers
{
    public static class PasswordHasher
    {
        public static string Hash(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public static bool Verify(string password, string hashed)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashed);
        }

        public static bool IsHashed(string password)
        {
            return password.StartsWith("$2a$") || password.StartsWith("$2b$") || password.StartsWith("$2y$");
        }

        public static string EnsureHashed(string password)
        {
            if (IsHashed(password))
                return password;
            return Hash(password);
        }
    }
}
