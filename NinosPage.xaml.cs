using Microsoft.Maui.Controls;
using System;

namespace AppSeguridad
{
    public partial class NinosPage : ContentPage
    {
        public NinosPage()
        {
            InitializeComponent();
        }

        private async void OnPlayQuizClicked(object sender, EventArgs e)
        {
            // Navega a la página de Verdadero/Falso (o a tu página de juego personalizada)
            await Navigation.PushAsync(new NinosMatchPage());
        }
    }
}
