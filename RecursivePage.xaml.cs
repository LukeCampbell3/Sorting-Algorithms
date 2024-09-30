namespace Sorting_Algorithms;
using Sorting_Algorithms.Data;
using System.Collections.ObjectModel;

public partial class RecursivePage : ContentPage
{
    // ObservableCollection to bind to the CollectionView
    public ObservableCollection<Book> Books { get; set; }

    public RecursivePage()
	{
		InitializeComponent();
        Books = new ObservableCollection<Book>();
        BindingContext = this;
    }

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
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Failed to load book data: {ex.Message}", "OK");
        }
    }

}