using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
using System;
using System.Collections.Generic;
using Microsoft.Maui.ApplicationModel;


namespace AppSeguridad
{
    public partial class CrucigramaPage : ContentPage
    {
        private Dictionary<(int, int), Entry> celdas = new();

        private string[,] respuestas = new string[13, 12]
        {
            { null, null, null,  null,  null,  null,  null,   null,  null,  null,  null,  null },
            { null, null, "a",   "n",   "t",   "i",   "v",   "i",   "r",   "u",   "s",   null },
            { null, null, "l",   null,  null,  null,  "i",   null,  null,  null,  null,  null },
            { null, null, "e",   null,  null,  null,  "r",   "o",   "b",   "a",   "r",   null },
            { null, null, "r",   null,  "h",  null,  "u",   null,  null,  null,  null,  null },
            { null, null, "t",   null,  "a",  null,  "s",   null,  null,  null,  null,  null },
            { null, "h",  "a",   "c",   "k",   "e",   "r",   null,  null,  null,  null,  null },
            { null, null, null,  null,  "i",  null,  null,  null,  null,  null,  null,  null },
            { null, null, null,  null,  "n",  null,  null,   null,  null,  null,  null,  null },
            { null, null, "s",    "e",  "g",   "u",  "r",  "i",  "d",  "a",  "d",  null },
            { null, null, null,  null,  null,  null,  null,   null,  null,  null,  null,  null },
            { null, null, null,  null,  null,   null,  null,   null,  null,  null,  null,  null },
            { null, null, null,  null,  null,  null,  null,   null,  null,  null,  null,  null },
           
        };

        // —————— Correción de posiciones de pistas ——————
        // —————— Ajustes en el diccionario de pistas ——————
        private Dictionary<(int, int), string> numerosPistas = new()
        {
            { (0, 2), "1" }, // antivirus (horizontal)
            { (1, 2), "2" }, // alerta (vertical)
            { (2, 6), "3" }, // robar (horizontal)
            { (5, 1), "4" }, // hacker (horizontal)
            { (8, 2), "5" }, // seguridad (horizontal)
        };


        public CrucigramaPage()
        {
            InitializeComponent();
            CrearCrucigramaVisual();
        }

        private void CrearCrucigramaVisual()
        {
            CrucigramaGrid.RowDefinitions.Clear();
            CrucigramaGrid.ColumnDefinitions.Clear();

            int filas = respuestas.GetLength(0);
            int columnas = respuestas.GetLength(1);

            for (int r = 0; r < filas; r++)
                CrucigramaGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(35) });

            for (int c = 0; c < columnas; c++)
                CrucigramaGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(35) });

            for (int r = 0; r < filas; r++)
            {
                for (int c = 0; c < columnas; c++)
                {
                    if (respuestas[r, c] != null)
                    {
                        var cell = new Grid();

                        if (numerosPistas.TryGetValue((r, c), out string num))
                        {
                            var numLabel = new Label
                            {
                                Text = num,
                                FontSize = 10,
                                VerticalOptions = LayoutOptions.Start,
                                HorizontalOptions = LayoutOptions.Start,
                                Margin = new Thickness(2, 0, 0, 0),
                                TextColor = Colors.Black
                            };
                            cell.Children.Add(numLabel);
                        }

                        var entry = new Entry
                        {
                            MaxLength = 1,
                            FontSize = 18,
                            BackgroundColor = Colors.White,
                            TextColor = Colors.Black,
                            HorizontalTextAlignment = TextAlignment.Center,
                            VerticalOptions = LayoutOptions.Center
                        };

                        cell.Children.Add(entry);
                        CrucigramaGrid.Add(cell, c, r);
                        celdas[(r, c)] = entry;
                    }
                    else
                    {
                        CrucigramaGrid.Add(new BoxView
                        {
                            Color = Colors.Black
                        }, c, r);
                    }
                }
            }
        }

        private async void Verificar_Clicked(object sender, EventArgs e)
        {
            bool todoCorrecto = true;

            foreach (var kvp in celdas)
            {
                var (r, c) = kvp.Key;
                var entry = kvp.Value;
                var valor = entry.Text?.Trim().ToLower();
                var esperado = respuestas[r, c]?.ToLower();

                if (valor == esperado)
                    entry.BackgroundColor = Colors.LightGreen;
                else
                {
                    entry.BackgroundColor = Colors.IndianRed;
                    todoCorrecto = false;
                }
            }

            if (todoCorrecto)
            {
                ResultadoLabel.Text = "✅ ¡Todo correcto!";
                await DisplayAlert("¡Felicidades!", "Has completado el crucigrama.", "Ver certificado");

                // Abre una nueva página con la imagen local
                var certificadoPage = new ContentPage
                {
                    Title = "Tu Certificado",
                    Content = new ScrollView
                    {
                        Content = new Image
                        {
                            Source = "adultosmayores.png",
                            Aspect = Aspect.AspectFit,
                            Margin = new Thickness(20)
                        }
                    }
                };

                await Navigation.PushAsync(certificadoPage);
            }
            else
            {
                ResultadoLabel.Text = "❌ Revisa los cuadros rojos.";
            }
        }


    }
}
