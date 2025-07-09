using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
using System;

namespace AppSeguridad
{
    public partial class VerdaderoFalsoPage : ContentPage
    {
        public VerdaderoFalsoPage()
        {
            InitializeComponent();
        }

        // Helper para colorear y mostrar alerta
        private async void HandleAnswer(Button btn, bool esCorrecto, string mensajeCorrecto, string mensajeIncorrecto)
        {
            // Colorea el botón
            btn.BackgroundColor = esCorrecto ? Colors.LightGreen : Colors.IndianRed;

            // Mensaje
            if (esCorrecto)
                await DisplayAlert("¡Correcto!", mensajeCorrecto, "OK");
            else
                await DisplayAlert("Incorrecto", mensajeIncorrecto, "OK");
        }

        private void Pregunta1_Correcto(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            HandleAnswer(btn, true,
                "Nunca uses la misma contraseña en todos lados.",
                "");
        }

        private void Pregunta1_Falso(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            HandleAnswer(btn, false,
                "",
                "Usar la misma contraseña es riesgoso.");
        }

        private void Pregunta2_Correcto(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            HandleAnswer(btn, true,
                "El 2FA añade una capa de seguridad.",
                "");
        }

        private void Pregunta2_Falso(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            HandleAnswer(btn, false,
                "",
                "El 2FA ayuda a proteger tus cuentas.");
        }

        private void Pregunta3_Correcto(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            HandleAnswer(btn, true,
                "Nunca hables con desconocidos en línea.",
                "");
        }

        private void Pregunta3_Falso(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            HandleAnswer(btn, false,
                "",
                "Puede ser peligroso hablar con extraños.");
        }

        private void Pregunta4_Correcto(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            HandleAnswer(btn, true,
                "Las tiendas oficiales son más seguras.",
                "");
        }

        private void Pregunta4_Falso(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            HandleAnswer(btn, false,
                "",
                "Apps desconocidas pueden tener virus.");
        }

        private async void Pregunta5_Correcto(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            HandleAnswer(btn, true,
                "Debes contarle a un adulto si algo te incomoda.",
                "");

            // Espera un momento para que el usuario vea el color
            await System.Threading.Tasks.Task.Delay(300);

            // Felicitación y certificado
            await DisplayAlert("¡Felicidades!", "Has completado el cuestionario.", "Ver certificado");

            var certificadoPage = new ContentPage
            {
                Title = "Tu Certificado",
                Content = new ScrollView
                {
                    Content = new Image
                    {
                        Source = "adolescente.png",
                        Aspect = Aspect.AspectFit,
                        Margin = new Thickness(20)
                    }
                }
            };

            await Navigation.PushAsync(certificadoPage);
        }

        private void Pregunta5_Falso(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            HandleAnswer(btn, false,
                "",
                "Guardar silencio puede ponerte en riesgo.");
        }
    }
}
