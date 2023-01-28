using SchoolManagementDemo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementDemo
{
    public class Enrolment
    {
        // everything in here except for setGrade is read only
        // because this is meant to be a permanent record of enrolments

        // I don't think we need validation, because they're already being validated by the other classes?

        private int _studentId;
        public int Id
        {
            get { return _studentId; }
        }
        private void _setStudentId(int studentId)
        {
            _studentId = studentId;
        }

        private Course _course;
        public Course Course
        {
            get { return _course; }
        }
        private void _setCourse(Course course)
        {
            _course = course;
        }

        private Student _student;
        public Student Student
        {
            get { return _student; }
        }
        private void _setStudent(Student student)
        {
            _student = student;
        }

        private double? _grade;
        public double? Grade
        {
            get { return _grade; }
        }
        // public since the grade should be easily updated
        public void setGrade(double? grade)
        {
            if (grade < 0 || grade > 100)
            {
                throw new Exception("Grade cannot be below 0, or above 100");
            }
            _grade = grade;
        }

        private DateTime? _enrolmentDate;
        public DateTime? EnrolmentDate { get { return _enrolmentDate; } }
        private void _setEnrolmentDate(DateTime? enrolmentDate)
        {
            _enrolmentDate = enrolmentDate;
        }

        public Enrolment(Student student, int studentId, Course course)
        {
            _setStudent(student);
            _setStudentId(studentId);
            _setCourse(course);
            setGrade(student.CourseGrade);
            _setEnrolmentDate(student.RegistrationDate);
        }
    }
}
