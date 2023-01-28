// Create an OOP "carpark" system
// at its most basic, the static CarPark class will have a private hashset of vehicles
// and a method: public static void Park (Vehicle vehicle)
// Vehicles have a string License number, and a string ParkingSpot
// Both should be private and validated with public properties 

// when the Park method is invoked, it adds the vehicle to the CarPark hashset, counts
// the vehicles in the HashSet, and uses that number to assign a spot.
// If 20 vehicles are parked, then the 21st vehicle parked is given spot 21.

// It should prevent a vehicle from parking in more than one spot (if it already has a spot)
// or if the spots are over capacity

namespace SchoolManagementDemo
{
    class Program
    {
        public static void Main(string[] args)
        {
            HashSet<Enrolment> Enrolments = new HashSet<Enrolment>();

            Course Software = new Course(200, "Software Developer", 30);
            Student Jimmy = new Student(1000);
            Student Tim = new Student(2000, "Tim", "Smith");

            Jimmy.FirstName = "Jimmy";
            Jimmy.LastName = "Smith";            

            RegisterStudent(Jimmy, Software);
            RegisterStudent(Tim, Software);
            Console.WriteLine(Software.GetStudentInCourse(Jimmy.StudentId).FirstName);
            Console.WriteLine(Jimmy.Course.Title);
            DeregisterStudent(Jimmy, Software);
            Console.WriteLine();
            

            // a course can have many students in it
            // and a student can take one course
            // one-to-many relationship (one course, many students)
            // "one" component needs a collection of the many (course needs a collection of students)
            // "many" component needs a property for the "one" (student needs a property of Course)

            // something outside of the objects creating the relationship between them
            void RegisterStudent(Student student, Course course)
            {
                // look to see if a student is already registered in a course
                // search for the student in the course student list
                if (course.GetStudentInCourse(student.StudentId) == null)
                {
                    // if not, add that student to teh course's student list
                    // set the course as the student's currently registered course
                    course.AddStudentToCourse(student);
                    student.Course = course;
                    student.RegistrationDate = DateTime.Now;
                    student.setCourseGrade(0); // here for the sake of seeing the grade saved in Enrollment

                    // enrollment stores all the values as its own class
                    Enrolment enrolment = new Enrolment(student, student.StudentId, course);
                    Enrolments.Add(enrolment);
                }
                else
                {
                    throw new Exception($"Student with id {student.StudentId} already " +
                        $"registered in course {course.Title}");
                }
            }

            void DeregisterStudent(Student student, Course course)
            {
                // dereference Course from Student
                // enrolment hashset still retains all enrolment objects and references
                course.RemoveStudentFromCourse(student);
                student.RegistrationDate = null;
            }
        }
    }

}