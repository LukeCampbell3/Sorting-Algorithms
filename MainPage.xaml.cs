namespace Sorting_Algorithms
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        public async void NavigateIterativePage(object sender, EventArgs e)
        {
            // Navigate to SecondPage
            await Navigation.PushAsync(new IterativePage());
        }

        private void NavigateRecursivePage(object sender, EventArgs e)
        {
            // Navigation logic, e.g.:  
            Navigation.PushAsync(new RecursivePage());
        }

    }
}


