using System;
using System.Collections.Generic;
using System.Text;

namespace StudentFilteringSystem
{
    internal class Student
    {
        public string Name { get; set; }
        public int Marks { get; set; }
        public int Age { get; set; }

        public Student(string name, int marks, int age)
        {
            Name = name;
            Marks = marks;
            Age = age;
        }

        public override string ToString()
        {
            return $"{Name} (Marks: {Marks}, Age: {Age})";
        }
    }
}
