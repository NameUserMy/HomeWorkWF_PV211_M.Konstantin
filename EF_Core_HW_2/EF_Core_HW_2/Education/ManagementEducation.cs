using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core_HW_2.Education
{



    internal class ManagementEducation
    {
        private readonly ContextEducation? _db;
        public void AddCourse(params Course[] courses)
        {
            _db?.AddRange(courses);
            _db?.SaveChanges();
        }
        public void AddLecture(params Lecture[] lectures)
        {
            _db?.AddRange(lectures);
            _db?.SaveChanges();
        }
        public void AddWorkshop(params Workshop[] workshops)
        {
            _db?.AddRange(workshops);
            _db?.SaveChanges();
        }
        public void AddStudent(params Student [] students)
        {
            _db?.AddRange(students);
            _db?.SaveChanges();
        }
        public void CourseRegistration(params CourseRegistration[] courseRegistrations)
        {

            _db?.AddRange(courseRegistrations);
            _db?.SaveChanges();

        }
        public void AddLectureProgress(params LectureProgress[] lectureProgresses)
        {

            _db?.AddRange(lectureProgresses);
            _db?.SaveChanges();

        }
        public Course GetCoursById(int id)
        {
            return _db.Courses.FirstOrDefault(e => e.Id == id);

        }
        public Student GetStudentById(int id)
        {
            return _db.Students.FirstOrDefault(e => e.Id == id);

        }
        public ManagementEducation(ContextEducation? db)=>_db = db;
        
    }
}
