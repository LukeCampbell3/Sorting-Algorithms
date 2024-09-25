using Microsoft.Maui.Controls.Shapes;
using Microsoft.Maui;

namespace Sorting_Algorithms
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnStartButtonClicked(object sender, EventArgs e)
        {
            try
            {
                // Open file picker to select a file
                var result = await FilePicker.Default.PickAsync(new PickOptions
                {
                    PickerTitle = "Select a Ship Data File",
                    // FileTypes = FilePickerFileType. // Uncomment and configure if needed
                });

                if (result != null)
                {
                    string filePath = result.FullPath;
                    if (!string.IsNullOrEmpty(filePath))
                    {
                        // Read the content of the file
                        string fileContent = File.ReadAllText(filePath);

                        // Split the file content into individual lines (ship descriptions)
                        var lines = fileContent.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

                        // Initialize a list to store the valid ships
                        List<Ship> validShips = new List<Ship>();
                        bool allShipsValid = true;

                        // Iterate through each line and process ship data
                        foreach (var line in lines)
                        {
                            string trimmedLine = line.Trim();

                            // Skip empty lines or comments
                            if (string.IsNullOrWhiteSpace(trimmedLine) || trimmedLine.StartsWith("#"))
                            {
                                continue;
                            }

                            try
                            {
                                // Verify and parse each ship description
                                if (ShipFactory.VerifyShipString(trimmedLine))
                                {
                                    Ship ship = ShipFactory.ParseShipString(trimmedLine);
                                    validShips.Add(ship);
                                }
                                else
                                {
                                    // Mark that not all ships are valid
                                    allShipsValid = false;
                                    GameMessage.Text = $"Invalid ship data found: {trimmedLine}. Please check the file.";
                                    break;
                                }
                            }
                            catch (FormatException ex)
                            {
                                // Handle format exceptions
                                GameMessage.Text = $"Error parsing ship data: {ex.Message}";
                                allShipsValid = false;
                                break;
                            }
                        }

                        // If all ship data is valid, add ships to the game
                        if (allShipsValid)
                        {
                            Ships.AddRange(validShips);
                            GameMessage.Text = "Ships loaded successfully. Click 'Next' to start the game!";
                            StartButton.IsVisible = false;
                            NextButton.IsVisible = true;
                        }
                        else
                        {
                            // If any ship data was invalid, allow user to retry
                            StartButton.IsVisible = true; // Keep the start button visible to allow the user to try again
                            NextButton.IsVisible = false; // Ensure the 'Next' button is not shown since the game cannot start
                        }
                    }
                }
                else
                {
                    GameMessage.Text = "File selection was canceled.";
                }
            }
            catch (Exception ex)
            {
                GameMessage.Text = $"Error loading ships: {ex.Message}";
            }
        }



    }

}
