using System;
using System.Collections.Generic;
using System.Text;

namespace StudentFilteringSystem
{
    internal class StudentManager
    {
        private List<Student> students = new List<Student>();

        // Adding sample students
        public void SeedData()
        {
            students.Add(new Student("Amit", 75, 20));
            students.Add(new Student("Ankita", 92, 19));
            students.Add(new Student("Arjun", 65, 17));
            students.Add(new Student("Ravi", 55, 16));
            students.Add(new Student("Kiran", 45, 21));
            students.Add(new Student("Neha", 90, 22));
        }

        // Generic filter method 
        public List<Student> FilterStudents(Predicate<Student> condition)
        {
            return students.FindAll(condition);
        }

        // Check if any student matches condition
        public bool HasStudent(Predicate<Student> condition)
        {
            return students.Exists(condition);
        }

        // Display method
        public void Display(string title, List<Student> list)
        {
            Console.WriteLine($"\n{title}");

            if (list == null || list.Count == 0)
            {
                Console.WriteLine("No students found!");
                return;
            }

            Console.WriteLine($"Total: {list.Count}");

            foreach (var student in list)
            {
                Console.WriteLine($"- {student}");  //for all the data
                //Console.WriteLine($"- {student.Name}");  //just for the names
            }
        }
    }
}
