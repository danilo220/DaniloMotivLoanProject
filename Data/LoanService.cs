using MotivWebApp.Interfaces;
using MotivWebApp.Models;

namespace MotivWebApp.Data
{
    public class LoanService: ILoanService
    {
        private readonly EntityDbContext _context;
        public  LoanService(EntityDbContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }

        public List<User> Users { get; set; } = new List<User>();

        public User LoadUsersById(Guid userId)
        {
            return _context.Users.FirstOrDefault(u => u.Id == userId);
        }
    }
}
