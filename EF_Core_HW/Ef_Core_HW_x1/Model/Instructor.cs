﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ef_Core_HW_x1.Model
{
    internal class Instructor
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? LName { get; set; }
        public List<Course>? Courses { get; set; }
    }
}
