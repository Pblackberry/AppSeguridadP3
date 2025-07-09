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
            // Navega a la p�gina de Verdadero/Falso (o a tu p�gina de juego personalizada)
            await Navigation.PushAsync(new NinosMatchPage());
        }
    }
}
