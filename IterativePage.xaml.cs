namespace Sorting_Algorithms;
using Sorting_Algorithms.Data; 

public partial class IterativePage : ContentPage
{
	public IterativePage()
	{
		InitializeComponent();
	}

    private async void LoadIntegerTestData(object sender, EventArgs e)
    {
        {
            // Open file picker to select a file
            var result = await FilePicker.Default.PickAsync(new PickOptions
            {
                PickerTitle = "Select a integer test file",
                // FileTypes = FilePickerFileType. // Uncomment and configure if needed
            });
        }
    }
}