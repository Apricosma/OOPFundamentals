using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementDemo
{
    public class Course
    {
        private int _courseId;
        public int CourseId { get { return _courseId; } } // read only property
        private void _setCourseId(int courseId)
        {
            if (courseId > 99)
            {
                _courseId = courseId;
            } else
            {
                throw new Exception("Course ID cannot exceed 99");
            }
           
        }

        private string _title;
        public string Title { get { return _title; } }
        private void _setTitle(string title)
        {
            if(title.Length > 2)
            {
                _title = title;
            } else
            {
                throw new Exception("Title should be three or more characters");
            }
        }

        private int _capacity;
        public int Capacity { get { return _capacity; } }
        private void _setCapacity(int capacity)
        {
            if (capacity > 0)
            {
                _capacity = capacity;
            } else
            {
                throw new Exception("Capacity must be greater than zero");
            }
        }

        // one course contains many students
        private HashSet<Student> _students = new HashSet<Student>();

        // get method exposes the entire collection; make specific methods instead
        public Student? GetStudentInCourse(int studentId)
        {
            foreach (Student s in _students)
            {
                if(s.StudentId == studentId)
                {
                    return s;
                }
            }

            return null;
        }

        public void AddStudentToCourse(Student student)
        {
            _students.Add(student);
        }

        public void RemoveStudentFromCourse(Student student)
        {
            foreach (Student s in _students)
            {
                if(s == student)
                {
                    Console.WriteLine($"{s.FirstName} {s.LastName} removed from {Title}");
                    _students.Remove(s);
                    student.Course = null;
                    return;
                } else
                {
                    throw new Exception($"Student was not found in course {Title}");
                }
            }
            throw new Exception($"Course {Title} is empty!");
        }

        public Course(int courseId, string title, int capacity)
        {
            _setCourseId(courseId);
            _setTitle(title);
            _setCapacity(capacity);
        }
    }
}
