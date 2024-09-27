using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Sorting_Algorithms.Data
{
    public class Book : IComparable<Book>
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }

        // Constructor
        public Book(string lastName, string firstName, string title, DateTime releaseDate)
        {
            this.LastName = lastName;
            this.FirstName = firstName;
            this.Title = title;
            this.ReleaseDate = releaseDate;
        }

        // CompareTo method for IComparable
        public int CompareTo(Book? other)
        {
            // Implement your comparison logic here, e.g., compare by release date:
            return this.ReleaseDate.CompareTo(other?.ReleaseDate);
        }

        // TryParse method that attempts to parse a string into a Book object
        public bool TryParse(string str, out Book result)
        {
            result = null;

            // Define the regular expression pattern to match the format
            var pattern = @"^\|\s*(?<LastName>\w+)\s*\|\s*(?<FirstName>\w+)\s*\|\s*(?<Title>.+?)\s*\|\s*(?<ReleaseDate>\d{4}-\d{2}-\d{2})\s*\|$";

            // Use Regex to match the input string
            var match = Regex.Match(str, pattern);

            if (match.Success)
            {
                // Extract matched groups
                string lastName = match.Groups["LastName"].Value;
                string firstName = match.Groups["FirstName"].Value;
                string title = match.Groups["Title"].Value;
                DateTime releaseDate;

                // Try to parse the release date
                if (DateTime.TryParse(match.Groups["ReleaseDate"].Value, out releaseDate))
                {
                    // Populate the result object
                    result = new Book(lastName, firstName, title, releaseDate);
                    return true;
                }
            }

            return false;
        }

        // Parse method that calls TryParse and throws an exception if parsing fails
        public Book Parse(string str)
        {
            if (TryParse(str, out Book book))
            {
                return book;
            }
            else
            {
                throw new FormatException("Input string was not in the correct format.");
            }
        }
    }
}
