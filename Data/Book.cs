using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Sorting_Algorithms.Data
{
    /// <summary>
    /// Represents a book with information such as author names, title, and release date 
    /// Implements IComparable to allow comparison of books
    /// </summary>
    public class Book : IComparable<Book>
    {
        /// <summary>
        /// Gets/sets the last name of the author.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets/sets the first name of the author.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets/sets the title of the book.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets/sets the release date of the book.
        /// </summary>
        public DateTime ReleaseDate { get; set; }


        /// <summary>
        /// Initializes and constructs a new instance of the Book class
        /// </summary>
        /// <param name="lastName">The last name of the author.</param>
        /// <param name="firstName">The first name of the author.</param>
        /// <param name="title">The title of the book.</param>
        /// <param name="releaseDate">The release date of the book.</param>
        public Book(string lastName, string firstName, string title, DateTime releaseDate)
        {
            this.LastName = lastName;
            this.FirstName = firstName;
            this.Title = title;
            this.ReleaseDate = releaseDate;
        }

        /// <summary>
        /// Compares this book to another book to be able to sort it
        /// </summary>
        /// <param name="other">The other book to compare to.</param>
        /// <returns>
        /// An integer indicating the relative order of the books.
        /// Returns 1 if the other book is null, otherwise it compares by last name,
        /// first name, title, and release date in that order.
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

        /// <summary>
        /// Parses a string into a Book object from a file to be able to sort 
        /// data from a file 
        /// Uses regex to do this 
        /// </summary>
        /// <param name="str">The string to parse.</param>
        /// <param name="result">The resulting Book object if parsing succeeds.</param>
        /// <returns>True if parsing was successful; otherwise, false.</returns>
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

        /// <summary>
        /// Parses a string from the file into a Book object.
        /// </summary>
        /// <param name="str">The string to parse.</param>
        /// <returns>The Book object parsed from the string.</returns>
        /// <exception cref="FormatException">Thrown if the string is not in the correct format.</exception>
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
