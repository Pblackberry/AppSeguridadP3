namespace AppSeguridad;

public partial class VerdaderoFalsoPage : ContentPage
{
    public VerdaderoFalsoPage()
    {
        InitializeComponent();
    }

    private async void Pregunta1_Correcto(object sender, EventArgs e) =>
        await DisplayAlert("�Correcto!", "Nunca uses la misma contrase�a en todos lados.", "OK");

    private async void Pregunta1_Falso(object sender, EventArgs e) =>
        await DisplayAlert("Incorrecto", "Usar la misma contrase�a es riesgoso.", "OK");

    private async void Pregunta2_Correcto(object sender, EventArgs e) =>
        await DisplayAlert("�Correcto!", "El 2FA a�ade una capa de seguridad.", "OK");

    private async void Pregunta2_Falso(object sender, EventArgs e) =>
        await DisplayAlert("Incorrecto", "El 2FA ayuda a proteger tus cuentas.", "OK");

    private async void Pregunta3_Correcto(object sender, EventArgs e) =>
        await DisplayAlert("�Correcto!", "Nunca hables con desconocidos en l�nea.", "OK");

    private async void Pregunta3_Falso(object sender, EventArgs e) =>
        await DisplayAlert("Incorrecto", "Puede ser peligroso hablar con extra�os.", "OK");

    private async void Pregunta4_Correcto(object sender, EventArgs e) =>
        await DisplayAlert("�Correcto!", "Las tiendas oficiales son m�s seguras.", "OK");

    private async void Pregunta4_Falso(object sender, EventArgs e) =>
        await DisplayAlert("Incorrecto", "Apps desconocidas pueden tener virus.", "OK");

    private async void Pregunta5_Correcto(object sender, EventArgs e) =>
        await DisplayAlert("�Correcto!", "Debes contarle a un adulto si algo te incomoda.", "OK");

    private async void Pregunta5_Falso(object sender, EventArgs e) =>
        await DisplayAlert("Incorrecto", "Guardar silencio puede ponerte en riesgo.", "OK");
}
