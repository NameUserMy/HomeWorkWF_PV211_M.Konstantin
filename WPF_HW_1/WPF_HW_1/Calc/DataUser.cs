using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_HW_1
{
    class DataUser
    {
        public DataUser(string login, string pass)
        {
            Login = login;
            Pass = pass;
        }
        public DataUser() { }

        public string Login { get; set; }
        public string Pass { get; set; }
 
    }
}
