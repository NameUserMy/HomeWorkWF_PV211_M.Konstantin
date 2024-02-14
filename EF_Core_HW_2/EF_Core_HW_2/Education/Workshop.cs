using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core_HW_2.Education
{
    internal class Workshop
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime Date { get; set; }
        public int MaxParticipants { get; set; }
        public int CourseId { get; set; }
        public Course? course { get; set; }
        public List<Student>? students { get; set; }

        public override string ToString()
        {
            return $"Title : {Title} Description : {Description} Date : {Date} Max Participants : {MaxParticipants} ";
        }
    }
}
