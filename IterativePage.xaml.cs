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
        // Open file picker to select a file 
        var result = await FilePicker.Default.PickAsync(new PickOptions
        {
            PickerTitle = "Select an integer test file",
        });

        if (result != null)
        {
            var filePath = result.FullPath;
            var integers = LoadIntegerTestData(filePath);

            // bubble sort
            IterativeSort<int> iterativeSort = new IterativeSort<int>();

            // Define the left and right for sorting the list, sort whole list 
            int left = 0;
            int right = integers.Count - 1;

            // Pass the left and right indices to the Sort method
            iterativeSort.Sort(integers, left, right);

            // Display sorted integers (or perform further actions)
            GameMessage.Text = $"Sorted {integers.Count} integers! Sorted integers: {string.Join(", ", integers)}";
        }

    }

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
}