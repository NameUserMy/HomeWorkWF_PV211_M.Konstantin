using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ef_Core_HW_x.UserSeting.Model
{
    internal class UsJoin
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public string? Email { get; set; }

        public string? Loggin { get; set; }
        public string? Pass { get; set; }
    }
}
