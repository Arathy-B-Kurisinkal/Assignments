using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace studentmanagement.Controllers
{
    [ApiController]
    public class StudentController : ControllerBase
    {
        private static List<Student> _students = new List<Student>();
        private static List<Course> _courselist = new List<Course>();


        // GET: api/Student
        [HttpGet("api/student")]
        public IActionResult Getstudent()
        {
            return Ok(_students);
        }


        //GET: api/Student/5
        [HttpGet("api/student/{studentId}")]
        public IActionResult GetStudentByName(int studentID)
        {

            var student = _students.SingleOrDefault(x => x.studentId == studentID);

                if (student == null)
                    return NotFound();

            return Ok(student);
                
                
        }
        //GET: api/Course/list
        [HttpGet("api/Course/list")]
        public IActionResult GetCourse()
        {

            var number = _students.GroupBy(x => x.Course).Select(x => new { x.Key, count = x.Count() });
            

            return Ok(number);


        }



        //POST: api/Student
        [HttpPost("api/student")]
        public IActionResult CreateStudent(Student student1)
        {
               
            var student2 = _students.OrderByDescending(x => x.studentId).LastOrDefault();
            int id;
            bool flag = false;
            if (student2==null)
                id = 1;
            else
                id = student2.studentId + 1;
            foreach (var course in _courselist)
            {
                if (student1.Course == course.CourseName)
                {
                    flag = true;
                }

            }
            if (flag == false)
            {
                return Conflict("Course is not in the list");
            }

            if (Convert.ToDateTime(student1.DateofBirth) > DateTime.Now)
            {
                return Conflict("Enter a valid date");
            }
            if (Convert.ToDateTime(student1.EnrollmentDate) > DateTime.Now)
            {
                return Conflict("Enter a valid date");
            }
            var GiveStudentDtls = new Student
            {
                studentId = id,
                FirstName = student1.FirstName,
                LastName = student1.LastName,
                DateofBirth = student1.DateofBirth,
                Address = student1.Address,
                PhoneNumber = student1.PhoneNumber,
                Course = student1.Course,
                EnrollmentDate = student1.EnrollmentDate
            };
                _students.Add(GiveStudentDtls);
                 return Ok(GiveStudentDtls);
            


        }
        //Post:api for Courses
        [HttpPost("api/Course")]
        public IActionResult CreateCourses(Course course1)
        {

            var lastcourse = _courselist.OrderByDescending(x => x.CourseId).FirstOrDefault();
            int id;
            if (lastcourse == null)
                id = 1;
            else
                id = lastcourse.CourseId + 1;
            var GiveCourses = new Course
            {
                CourseId = id,
                CourseName = course1.CourseName

            };

            _courselist.Add(GiveCourses);
            return Ok(GiveCourses);

        }





        //PUT: api/Student/
        [HttpPut("api/student/{studentId}")]
        public IActionResult EditStudentDetails(int studentId, Student student1)
        {
            var EditStudent = _students.SingleOrDefault(x => x.studentId == studentId);


            if (EditStudent.studentId == null) 
            {
                return NotFound();
                     
            }
                EditStudent.FirstName = student1.FirstName;
                EditStudent.LastName = student1.LastName;
                EditStudent.DateofBirth = student1.DateofBirth;
                EditStudent.Address = student1.Address;
                EditStudent.PhoneNumber = student1.PhoneNumber;
                EditStudent.EnrollmentDate = student1.EnrollmentDate;
                EditStudent.Course = student1.Course;
                return Ok();
            

            

        }

        //delete: api/apiwithactions/5
        //[httpdelete("{id}")]
        //public void delete(int id)
        //{
        //}
    }
}
