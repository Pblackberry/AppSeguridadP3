namespace AppSeguridad
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnNinosClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NinosPage());
        }

        private async void OnAdolescentesClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AdolescentesPage());
        }

        private async void OnAdultosClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AdultosMayoresPage());
        }
    }
}
