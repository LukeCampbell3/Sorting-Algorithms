namespace Sorting_Algorithms;
using Sorting_Algorithms.Data;
using System.Collections.ObjectModel;
using System.Diagnostics;

public partial class RecursivePage : ContentPage
{
    // ObservableCollection to bind to the CollectionView
    public ObservableCollection<Book> Books { get; set; }

    /// <summary>
    /// Initializes new page for the recursive algorithm 
    /// </summary>
    public RecursivePage()
    {
        InitializeComponent();
        Books = new ObservableCollection<Book>();
        BindingContext = this;
    }

    /// <summary>
    /// Called when the button on xaml page is pressed that uses file picker to load in the test files for integer data and
    /// sorts it automatically and then prints it onscreen for the user to view 
    /// </summary>
    /// <param name="sender">button stuff</param>
    /// <param name="e">button stuff</param>
    private async void LoadIntegerTestData(object sender, EventArgs e)
    {
        // Open file picker to select a file 
        var result = await FilePicker.Default.PickAsync(new PickOptions
        {
            PickerTitle = "Select an integer test file",
        });

        if (result != null)
        {
            var filePath = result.FullPath;
            var fileName = Path.GetFileName(filePath);
            var integers = LoadIntegerTestData(filePath);

            // Initialize the stopwatch
            Stopwatch stopwatch = new Stopwatch();

            // Start the stopwatch before sorting
            stopwatch.Start();

            // bubble sort
            IterativeSort<int> iterativeSort = new IterativeSort<int>();

            // Define the left and right for sorting the list, sort whole list 
            int left = 0;
            int right = integers.Count - 1;

            // Pass the left and right indices to the Sort method
            iterativeSort.Sort(integers, left, right);

            stopwatch.Stop();
            var elapsedTime = stopwatch.ElapsedMilliseconds;

            // Display sorted integers (or perform further actions)
            GameMessage.Text = $"Sorted {fileName} in {elapsedTime} ms! Sorted integers: {string.Join(", ", integers)}";
        }

    }

    /// <summary>
    /// Aids in parsing int data and adds numbers to a list to be easily sorted 
    /// </summary>
    /// <param name="filePath">string representation of the file path</param>
    /// <returns>list of ints in file</returns>
    private List<int> LoadIntegerTestData(string filePath)
    {
        List<int> integers = new List<int>();
        var lines = File.ReadAllLines(filePath);
        foreach (var line in lines)
        {
            if (int.TryParse(line, out int number))
            {
                integers.Add(number);
            }
        }
        return integers;
    }

    /// <summary>
    /// Loads in book data from a book test data file and 
    /// sorts it automatically and displays it in a table format on the screen 
    /// </summary>
    /// <param name="sender">button stuff</param>
    /// <param name="e">button stuff </param>
    private async void LoadBookData(object sender, EventArgs e)
    {
        try
        {
            // Open file picker to select a file
            var result = await FilePicker.Default.PickAsync(new PickOptions
            {
                PickerTitle = "Select a book test data file",
            });

            if (result != null)
            {
                // Read file content
                var fileContent = await File.ReadAllTextAsync(result.FullPath);
                var fileName = Path.GetFileName(result.FullPath);

                // Split the content into lines
                var lines = fileContent.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

                foreach (var line in lines)
                {
                    // Skip lines with '+' or the title header (which usually starts with "| Last Name")
                    if (line.Contains('+') || line.StartsWith("| Last Name"))
                    {
                        continue;
                    }

                    try
                    {
                        // Use the Book.Parse method to create a Book object
                        var book = new Book("", "", "", DateTime.MinValue).Parse(line);
                        Books.Add(book); // Add the parsed book to the list
                    }
                    catch (FormatException)
                    {
                        // Handle invalid format (optional)
                        await DisplayAlert("Error", $"Failed to parse the line: {line}", "OK");
                    }
                }

                // Apply RecursiveSort after all books are added
                RecursiveSort<Book> recursiveSort = new RecursiveSort<Book>();

                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();

                recursiveSort.Sort(Books, 0, Books.Count - 1); // Sort directly on Books

                stopwatch.Stop();

                var elapsedTime = stopwatch.ElapsedMilliseconds;

                GameMessage.Text = $"Loaded and sorted {fileName} in {elapsedTime} ms!";


                // Manually refresh the UI by resetting the ItemsSource if necessary
                BookCollectionView.ItemsSource = null;
                BookCollectionView.ItemsSource = Books; // Resetting the ItemsSource forces UI update
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Failed to load book data: {ex.Message}", "OK");
        }
    }

    /*private async void LoadBookData(object sender, EventArgs e)
    {
        try
        {
            // Open file picker to select a file
            var result = await FilePicker.Default.PickAsync(new PickOptions
            {
                PickerTitle = "Select a book test data file",
            });

            if (result != null)
            {
                // Read file content
                var fileContent = await File.ReadAllTextAsync(result.FullPath);

                // Split the content into lines
                var lines = fileContent.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

                foreach (var line in lines)
                {
                    try
                    {
                        // Use the Book.Parse method to create a Book object
                        var book = new Book("", "", "", DateTime.MinValue).Parse(line);
                        Books.Add(book); // Add the parsed book to the list
                    }
                    catch (FormatException)
                    {
                        // Handle invalid format (optional)
                        await DisplayAlert("Error", $"Failed to parse the line: {line}", "OK");
                    }
                }

                // Apply RecursiveSort after all books are added
                RecursiveSort<Book> recursiveSort = new RecursiveSort<Book>();
                recursiveSort.Sort(Books, 0, Books.Count - 1); // Sort directly on Books

                // Manually refresh the UI by resetting the ItemsSource if necessary
                BookCollectionView.ItemsSource = null;
                BookCollectionView.ItemsSource = Books; // Resetting the ItemsSource forces UI update
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Failed to load book data: {ex.Message}", "OK");
        }
    }*/
}