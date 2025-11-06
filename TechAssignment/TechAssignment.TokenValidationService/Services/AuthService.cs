using TechAssignment.TokenValidationService.Data;

namespace TechAssignment.TokenValidationService.Services
{
    public class AuthService
    {
        private readonly AppDbContext _context;

        public AuthService(AppDbContext context)
        {
            _context = context;
        }
        public bool ValidateCredentials(string username, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.Username == username);
            if (user is null) return false;

            return user.PasswordHash == password;
        }
    }
}
