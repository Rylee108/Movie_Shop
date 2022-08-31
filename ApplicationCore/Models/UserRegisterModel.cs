using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models
{
    public class UserRegisterModel
    {
        public String Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public String LastName { get; set; }
        public DateTime DateofBirth { get; set; }
    }
}
