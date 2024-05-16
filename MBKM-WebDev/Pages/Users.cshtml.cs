using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MBKM_WebDev.Pages
{
    public class UsersModel : PageModel
    {
        public List<Users> ListUsers { get; private set; }

        public void OnGet()
        {
            // Data user statis
            ListUsers = new List<Users>
            {
                new Users { Id = 1, Name = "John Doe", Email = "john.doe@example.com", Role = "Administrator" },
                new Users { Id = 2, Name = "Jane Smith", Email = "jane.smith@example.com", Role = "User" },
                new Users { Id = 3, Name = "Michael Brown", Email = "michael.brown@example.com", Role = "Moderator" }
            };
        }
    }

    public class Users
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
    }
}
