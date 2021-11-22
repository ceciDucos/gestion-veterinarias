using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelosVeterinarias.ValueObject
{
    public class VOLogin
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public VOLogin(string username, string password)
        {
            this.Username = username;
            this.Password = password;
        }
    }
}
