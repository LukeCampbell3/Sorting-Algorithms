namespace Sorting_Algorithms
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private async void LoadIntegerTestData(object sender, EventArgs e)
        {
            {
                // Open file picker to select a file
                var result = await FilePicker.Default.PickAsync(new PickOptions
                {
                    PickerTitle = "Select a File",
                    // FileTypes = FilePickerFileType. // Uncomment and configure if needed
                });
            }
        }
    }
}


