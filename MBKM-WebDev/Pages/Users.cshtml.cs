using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MBKM_WebDev.Models;
using MBKM_WebDev.Data;
using Microsoft.EntityFrameworkCore;

namespace MBKM_WebDev.Pages
{
    public class UsersModel : PageModel
    {
        public IList<Users> ListUsers { get; private set; }

        private readonly AppDbContext _context;

        public UsersModel(AppDbContext context)
        {
            _context = context;
        }

        public async Task OnGetAsync()
        {
            // Data user statis
            //ListUsers = new List<Users>
            //{
            //    new Users { Id = 1, Name = "John Doe", Email = "john.doe@example.com", Role = "Administrator" },
            //    new Users { Id = 2, Name = "Jane Smith", Email = "jane.smith@example.com", Role = "User" },
            //    new Users { Id = 3, Name = "Michael Brown", Email = "michael.brown@example.com", Role = "Moderator" }
            //};

            //ListUsers = await _context.Users.ToListAsync();
            ListUsers = await _context.Users.FromSqlRaw("SELECT * FROM Users").ToListAsync();
        }
    }
}
