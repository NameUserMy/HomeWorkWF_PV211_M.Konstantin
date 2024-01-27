using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET_HW_2.ChroniclesOfAscents
{
    internal class Mountaineer
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Adress { get; set; }
        public int GroupId { get; set; }
        public Mountaineer() { }
        public Mountaineer(string? name, string? adress, int groupId)
        {
            Name = name;
            Adress = adress;
            GroupId = groupId;
        }
    }
}
