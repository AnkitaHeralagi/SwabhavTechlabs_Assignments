using System;

namespace StudentFilteringSystem
{
    class Program
    {
        static void Main()
        {
            StudentManager manager = new StudentManager();
            manager.SeedData();

            // Define predicates
            Predicate<Student> highMarks = s => s.Marks > 60;
            Predicate<Student> underAge = s => s.Age < 18;
            Predicate<Student> startsWithA = s => s.Name.StartsWith("A");

            // Apply filters
            var marksList = manager.FilterStudents(highMarks);
            var ageList = manager.FilterStudents(underAge);
            var nameList = manager.FilterStudents(startsWithA);

            // Display results
            manager.Display("Students with Marks > 60:", marksList);
            manager.Display("Students Age < 18:", ageList);
            manager.Display("Names starting with A:", nameList);

            // Exists check
            bool anyTopper = manager.HasStudent(highMarks);
            Console.WriteLine($"\nAny student scored above 60? {(anyTopper ? "Yes" : "No")}");
        }
    }
}