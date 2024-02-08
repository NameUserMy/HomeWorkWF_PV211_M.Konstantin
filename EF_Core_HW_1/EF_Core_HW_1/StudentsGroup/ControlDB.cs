
using System;
using System.Linq;

namespace EF_Core_HW_1.StudentsGroup
{
    internal class ControlDB
    {
        private ContextGroup _groupDB;
        public void GetGroupByStudent(string nameStudent)
        {
            var student = _groupDB.Student.FirstOrDefault(e => e.Name == nameStudent);
            var group = _groupDB.Group.Where(e => e.Student.Contains(student));
            foreach (var item in group)
            {
                Console.WriteLine($"{item.Title}");
            }


        }
        public void GetStudentByGroup(string nameGroup)
        {
            var group = _groupDB.Group.FirstOrDefault(e => e.Title == nameGroup);
            var students = _groupDB.Student.Where(e => e.Group.Contains(group));

            foreach (var item in students)
            {
                Console.WriteLine($"{item.Name}");
            }


        }
        public void DeleteStudentById(int id)
        {
            var targetStudent=_groupDB.Student.Where(e => e.Id == id).FirstOrDefault();
            if(targetStudent is not null)
            {
                _groupDB.Remove(targetStudent);
                _groupDB.SaveChanges();
            }
        }
        public void UpdateStudentById(Student student) {

            var targetStudent = _groupDB.Student.Where(e => e.Id == student.Id).FirstOrDefault();
            if (targetStudent is not null) {

                targetStudent.Name = student.Name;
                targetStudent.Id = student.Id;
                _groupDB.Update(targetStudent);
                _groupDB.SaveChanges();
            }




        }
        public ControlDB(ContextGroup db) =>_groupDB = db;

    }
}
