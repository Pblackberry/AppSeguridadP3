using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
using System;

namespace AppSeguridad
{
    public partial class MainPage : ContentPage
    {
        private LinearGradientBrush _bgBrush;
        private bool _animando;

        public MainPage()
        {
            InitializeComponent();
            // Obtenemos el gradiente definido en XAML
            _bgBrush = (LinearGradientBrush)Resources["PageBackgroundGradient"];
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (!_animando)
            {
                _animando = true;

                // Animación que desplaza los GradientStops
                var animation = new Animation(
                    callback: v =>
                    {
                        _bgBrush.GradientStops[0].Offset = (float)v;
                        _bgBrush.GradientStops[1].Offset = (float)(1 - v);
                    },
                    start: 0, end: 1);

                // 5 segundos, repite infinitamente
                animation.Commit(
                    owner: this,
                    name: "BackgroundShift",
                    length: 5000,
                    easing: Easing.Linear,
                    repeat: () => true,
                    rate: 16);
            }
        }

        private async void OnNinosClicked(object sender, EventArgs e)
            => await Navigation.PushAsync(new NinosPage());

        private async void OnAdolescentesClicked(object sender, EventArgs e)
            => await Navigation.PushAsync(new AdolescentesPage());

        private async void OnAdultosClicked(object sender, EventArgs e)
            => await Navigation.PushAsync(new AdultosMayoresPage());
    }
}
