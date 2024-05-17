using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace MBKM_WebDev.Models
{
    public class Users
    {
        [Key]
        public string Email { get; set; }
        public string FullName { get; set; }
        public string Password { get; set; }
        [AllowNull]
        public string Address { get; set; }
        [AllowNull]
        public string Phone { get; set; }
    }
}
