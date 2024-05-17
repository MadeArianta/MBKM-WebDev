using MBKM_WebDev.Data;
using MBKM_WebDev.Models;
using Microsoft.AspNetCore.Mvc;

namespace MBKM_WebDev.Controllers
{
    [Route("/Users")]
    [ApiController]
    public class UsersController : Controller
    {
        //Keperluan Koneksi Database
        private readonly AppDbContext _context;

        public UsersController(AppDbContext context)
        {
            _context = context;
        }

        // GET : /Users/GetUser?email={email}
        [HttpGet("GetUser")]
        public async Task<JsonResult> GetUser(string email)
        {
            var user = await _context.Users.FindAsync(email);
            if (user == null)
            {
                return new JsonResult(null);
            }
            return new JsonResult(user);
        }

        // PUT : /Users/{email}
        [HttpPut("{email}")]
        public async Task<IActionResult> Edit([FromBody] Users user, string email)
        {
            if (!ModelState.IsValid)
            {
                return new JsonResult(ModelState);
            }

            var userToUpdate = await _context.Users.FindAsync(email);
            if (userToUpdate == null)
            {
                return new JsonResult(new { success = false, message = "User not found" });
            }

            userToUpdate.FullName = user.FullName;
            userToUpdate.Password = EncryptPassword(user.Password);
            userToUpdate.Address = user.Address;
            userToUpdate.Phone = user.Phone;

            await _context.SaveChangesAsync();
            return new JsonResult(new { success = true });
        }

        //POST : /Users
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Users user)
        {
            if (!ModelState.IsValid)
            {
                return new JsonResult(ModelState);
            }

            user.Password = EncryptPassword(user.Password);
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return new JsonResult(new { success = true });
        }

        // DELETE : /Users/{email}
        [HttpDelete("{email}")]
        public async Task<IActionResult> Delete(string email)
        {
            var user = await _context.Users.FindAsync(email);
            if (user == null)
            {
                return new JsonResult(new { success = false, message = "User not found" });
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return new JsonResult(new { success = true });
        }

        //Keperluan Ecryption
        private string EncryptPassword(string password)
        {
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hashedBytes);
            }
        }


    }
}
