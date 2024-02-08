using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core_HW_1.Note
{
    internal class Task
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateOnly CreateDate { get; }
        public bool Status { get; set; }

    }


 
}

