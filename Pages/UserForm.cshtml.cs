using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MotivWebApp.Models;

namespace MotivWebApp.Pages
{
    public class UserFormModel : PageModel
    {
        private readonly EntityDbContext _context;

        public UserFormModel(EntityDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            Titles.Add("Mr");
            Titles.Add("Mrs");
            Titles.Add("Ms");
            Titles.Add("Miss ");
            Titles.Add("Dr ");
            Titles.Add("Professor");
            return Page();
        }

        [BindProperty]
        public User User { get; set; } = default!;
        public int MinimumLoanAmount = 1;
        public List<string> Titles = new List<string>();

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Users == null || User == null)
            {
                return Page();
            }
            User.Loan.CheckLoanAcceptance(User.AnnualIncome);
            User.Loan.CalculateInterestRate(User.AnnualIncome);

            _context.Users.Add(User);
            await _context.SaveChangesAsync();

            return RedirectToPage("UserLoanDetails", User);
        }
    }
}
