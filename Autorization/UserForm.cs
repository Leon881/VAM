using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autorization_form
{
    public class UserForm
    {
        public UserForm(string login, string password)
        {
            Login = login;
            HashPass = password.GetHashCode();
        }

        public UserForm() { }

        public string Login { get; set; }
        public int HashPass { get; set; }        
    }
}
