using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
using System;
using System.Collections.Generic;

namespace AppSeguridad
{
    public partial class NinosMatchPage : ContentPage
    {
        // Lista de opciones a mostrar en cada Picker
        readonly List<string> _options = new()
        {
            "antivirus",
            "virus",
            "phishing",
            "actualizar",
            "contraseñas"
        };

        public NinosMatchPage()
        {
            InitializeComponent();
            // Llenar todos los Pickers con las mismas opciones
            foreach (var picker in new[] { Picker1, Picker2, Picker3, Picker4, Picker5 })
            {
                picker.ItemsSource = _options;
                picker.SelectedIndex = -1;
            }
        }

        private async void OnVerifyClicked(object sender, EventArgs e)
        {
            // Definimos las respuestas correctas
            var answers = new Dictionary<Picker, string>
            {
                { Picker1, "antivirus" },
                { Picker2, "virus" },
                { Picker3, "phishing" },
                { Picker4, "actualizar" },
                { Picker5, "contraseñas" }
            };

            bool allCorrect = true;
            // Verificamos cada picker
            foreach (var kv in answers)
            {
                var picker = kv.Key;
                var correct = kv.Value;
                if (picker.SelectedItem is string sel && sel == correct)
                {
                    picker.BackgroundColor = Colors.LightGreen;
                }
                else
                {
                    picker.BackgroundColor = Colors.IndianRed;
                    allCorrect = false;
                }
            }

            ResultLabel.Text = allCorrect
                ? "✅ ¡Bien hecho, todas correctas!"
                : "❌ Revisa los resaltados en rojo.";

            // Si todo es correcto, mostramos el certificado
            if (allCorrect)
            {
                // Mensaje opcional antes del certificado
                await DisplayAlert("¡Felicidades!", "Has completado el juego.", "Ver certificado");

                var certificadoPage = new ContentPage
                {
                    Title = "Tu Certificado",
                    Content = new ScrollView
                    {
                        Content = new Image
                        {
                            Source = "certificado.png",
                            Aspect = Aspect.AspectFit,
                            Margin = new Thickness(20)
                        }
                    }
                };

                await Navigation.PushAsync(certificadoPage);
            }
        }
    }
}
