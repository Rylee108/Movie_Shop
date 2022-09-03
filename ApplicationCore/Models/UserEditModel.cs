using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models
{
    public class UserEditModel
    {
        public String Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public String LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
