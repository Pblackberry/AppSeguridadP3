namespace AppSeguridad;

using Microsoft.Maui.Storage;

public partial class AdolescentesPage : ContentPage
{
    public AdolescentesPage()
    {
        InitializeComponent(); // Esto ya debe estar
    }

    private async void IrAVerdaderoFalso_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new VerdaderoFalsoPage());
    }

}



