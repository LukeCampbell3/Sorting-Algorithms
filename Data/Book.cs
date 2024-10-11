using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Sorting_Algorithms.Data
{
    /// <summary>
    /// Book class
    /// </summary>
    public class Book : IComparable<Book>
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }

        /// <summary>
        /// This is the constructor for the Book object
        /// </summary>
        /// <param name="lastName">String containing Author's last name</param>
        /// <param name="firstName">String containing Author's first name</param>
        /// <param name="title">String containing the Book's title</param>
        /// <param name="releaseDate">DateTime which containing Book's release date</param>
        public Book(string lastName, string firstName, string title, DateTime releaseDate)
        {
            this.LastName = lastName;
            this.FirstName = firstName;
            this.Title = title;
            this.ReleaseDate = releaseDate;
        }

        /// <summary>
        /// Makes sure Book is comparable
        /// </summary>
        /// <param name="other"></param>
        /// <returns>
        /// the priority in which the book is to be sorted
        ///     LastName
        ///     FirstName
        ///     Title
        ///     ReleaseDate
        /// </returns>
        public int CompareTo(Book? other)
        {
            if (other == null) return 1; // If the other book is null, this book comes first.

            // Compare by last name
            int lastnameComparison = this.LastName.CompareTo(other.LastName);
            if (lastnameComparison != 0)
            {
                return lastnameComparison; // If last names are different, return the comparison result
            }

            // Compare by first name
            int firstnameComparison = this.FirstName.CompareTo(other.FirstName);
            if (firstnameComparison != 0)
            {
                return firstnameComparison; // If first names are different, return the comparison result
            }

            // Compare by title
            int titleComparison = this.Title.CompareTo(other.Title);
            if (titleComparison != 0)
            {
                return titleComparison; // If titles are different, return the comparison result
            }

            // Compare by release date
            return this.ReleaseDate.CompareTo(other.ReleaseDate); // Compare by release date last
        }


        public bool TryParse(string str, out Book result)
        {
            result = null;

            // Skip separator lines (those that start with '+')
            if (str.StartsWith("+"))
            {
                return false;
            }

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
                    // Create a Book object
                    result = new Book(lastName, firstName, title, releaseDate);
                    return true;
                }
            }

            return false;
        }

        public Book Parse(string str)
        {
            if (TryParse(str, out Book book))
            {
                return book;
            }
            else
            {
                throw new FormatException($"Failed to parse the line: {str}");
            }
        }

        /// <summary>
        /// I AM UNSURE IF WE REALLY NEED THIS BECAUSE WE ARE USING MAUI
        /// We essentially go around this. 
        /// We could use it maybe idk
        /// </summary>
        /// <returns>returns the Book object in string form</returns>
        public override string ToString()
        {
            return($"{this.LastName},{this.LastName},\"{this.Title}\",{this.ReleaseDate.ToShortDateString()}");
        }

    }
}
