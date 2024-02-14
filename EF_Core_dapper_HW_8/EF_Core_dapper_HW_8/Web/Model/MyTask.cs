using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core_dapper_HW_8.Web.Model
{
    internal class MyTask
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsCompleted { get; set; }

        public override string ToString()
        {
            return $"{Title}  {Description} {DueDate} {IsCompleted} ";
        }

    }
}
