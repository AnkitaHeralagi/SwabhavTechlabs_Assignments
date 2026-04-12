using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace MoviestoreApp
{
    internal class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int YearOfRelease { get; set; }
        public string Genre { get; set; }
        public override string ToString()
        {
            return $"ID: {Id}, Name: {Name}, Year: {YearOfRelease}, Genre: {Genre}";
        }
    }
}
