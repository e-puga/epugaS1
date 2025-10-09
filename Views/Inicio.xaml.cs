using System.Security.Cryptography;

namespace epugaS1.Views;

public partial class Inicio : ContentPage
{
	public Inicio()
	{
		InitializeComponent();
	}

	private void btnEnviar_Clicked(object sender, EventArgs e)
	{
		string nombre = txtNombre.Text;
		int edad = Convert.ToInt32(txtEdad.Text);
		DisplayAlert("ALERTA", "BENVENIDO "+ nombre + "tienes " + edad + " años" 
			, "Cancelar");
    }
}