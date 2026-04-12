using System;
using System.Collections.Generic;
using System.Linq;

namespace MoviestoreApp
{
    internal class MovieService
    {
        private List<Movie> movies = new List<Movie>();
        private const int MAX_LIMIT = 5;

        // safe integer input
        private int GetValidInt(string message)
        {
            int value;
            Console.Write(message);
            while (!int.TryParse(Console.ReadLine(), out value))
            {
                Console.Write("Invalid input. Enter a number: ");
            }
            return value;
        }

        // string validation
        private string GetValidString(string message)
        {
            string input;
            Console.Write(message);
            while (true)
            {
                input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.Write("Input cannot be empty. Try again: ");
                }
                else
                {
                    return input;
                }
            }
        }

        // genre validation
        private string GetValidGenre()
        {
            string genre;
            while (true)
            {
                Console.Write("Enter Genre: ");
                genre = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(genre))
                {
                    Console.WriteLine("Genre cannot be empty.");
                    continue;
                }
                if (!genre.All(char.IsLetter))
                {
                    Console.WriteLine("Genre should contain only alphabets.");
                    continue;
                }
                return genre;
            }
        }

        // Add movie
        public void AddMovie()
        {
            if (movies.Count >= MAX_LIMIT)
            {
                Console.WriteLine("Movie store is full (max 5 movies).");
                return;
            }
            int id = GetValidInt("Enter Movie ID: ");

            // duplicate check
            if (movies.Any(m => m.Id == id))
            {
                Console.WriteLine("Movie with this ID already exists.");
                return;
            }
            string name = GetValidString("Enter Movie Name: ");
            int year = GetValidInt("Enter Year of Release: ");
            string genre = GetValidGenre();
            Movie movie = new Movie
            {
                Id = id,
                Name = name,
                YearOfRelease = year,
                Genre = genre
            };
            movies.Add(movie);
            Console.WriteLine("Movie added successfully!");
        }

        // Display all movies
        public void DisplayMovies()
        {
            if (movies.Count == 0)
            {
                Console.WriteLine("No movies found.");
                return;
            }
            Console.WriteLine("\nMovie List:");
            foreach (var movie in movies)
            {
                Console.WriteLine(movie);
            }
        }

        // Find movie by ID
        public void FindMovieById()
        {
            int id = GetValidInt("Enter Movie ID to search: ");
            var movie = movies.FirstOrDefault(m => m.Id == id);
            if (movie == null)
            {
                Console.WriteLine("Movie not found.");
            }
            else
            {
                Console.WriteLine("Movie Found:");
                Console.WriteLine(movie);
            }
        }

        // Remove movie
        public void RemoveMovie()
        {
            int id = GetValidInt("Enter Movie ID to remove: ");
            var movie = movies.FirstOrDefault(m => m.Id == id);
            if (movie == null)
            {
                Console.WriteLine("Movie not found.");
                return;
            }
            movies.Remove(movie);
            Console.WriteLine("Movie removed successfully.");
        }

        // Clear all movies
        public void ClearAllMovies()
        {
            if (movies.Count == 0)
            {
                Console.WriteLine("Already empty.");
                return;
            }
            movies.Clear();
            Console.WriteLine("All movies cleared.");
        }
    }
}