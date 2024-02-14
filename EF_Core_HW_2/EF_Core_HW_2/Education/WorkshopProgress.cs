using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core_HW_2.Education
{
    internal class WorkshopProgress
    {
        public int Id { get; set; }
        public int WorkshopId { get; set; }
        public int StudentId { get; set; }
        public bool IsProgress { get; set; }
    }
}
