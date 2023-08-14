using MotivWebApp.Models;

namespace MotivWebApp.Interfaces
{
    public interface IUser<T> where T : Name
    {
        public T Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
