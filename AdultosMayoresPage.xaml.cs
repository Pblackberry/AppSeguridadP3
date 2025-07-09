using Microsoft.Maui.Controls;

namespace AppSeguridad
{
    public partial class AdultosMayoresPage : ContentPage
    {
        public AdultosMayoresPage()
        {
            InitializeComponent();
        }

        private async void IrACrucigrama_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CrucigramaPage());
        }
    }
}
