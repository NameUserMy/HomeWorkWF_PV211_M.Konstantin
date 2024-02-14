﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core_HW_2.Education
{
    internal class Student
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public List<Course>? Courses { get; set; } = new();
        public List<Lecture>? Lectures { get; set; } = new();
        public List<Workshop>? Workshops { get; set; } = new();
    }
}
