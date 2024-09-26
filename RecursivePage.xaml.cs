namespace Sorting_Algorithms;
using Sorting_Algorithms.Data;

public partial class RecursivePage : ContentPage
{
	public RecursivePage()
	{
		InitializeComponent();
	}

    private async void LoadBookData(object sender, EventArgs e)
    {
        {
            // Open file picker to select a file
            var result = await FilePicker.Default.PickAsync(new PickOptions
            {
                PickerTitle = "Select a book test data file",
                // FileTypes = FilePickerFileType. // Uncomment and configure if needed
            });
        }
    }
}