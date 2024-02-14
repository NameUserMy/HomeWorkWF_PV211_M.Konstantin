using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core_HW_2.Education
{
    internal class LectureProgress
    {
        public int Id { get; set; }
        public int LectureId { get; set; }
        public int StudentId { get; set; }
        public bool IsProgress { get; set; }

        public override string ToString()
        {
            return $"{IsProgress}";
        }

    }
}
