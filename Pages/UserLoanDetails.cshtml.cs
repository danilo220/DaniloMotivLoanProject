﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MotivWebApp.Models;

namespace MotivWebApp.Pages
{
    public class UserLoanDetailsModel : PageModel
    {
        private readonly EntityDbContext _context;

        public UserLoanDetailsModel(EntityDbContext context)
        {
            _context = context;
        }

        public User User { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || _context.Users == null)
            {
                return NotFound();
            }

            var user = await _context.Users.FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            else 
            {
                User = user;
            }
            return Page();
        }
    }
}
