using MotivWebApp.Models;

namespace MotivWebApp.Interfaces
{
    public interface ILoanService
    {
        public List<User> Users { get; set; }
        public User LoadUsersById(Guid userId);
    }
}
