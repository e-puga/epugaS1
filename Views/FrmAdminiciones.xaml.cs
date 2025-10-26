namespace epugaS1.Views;

public partial class FrmAdminiciones : ContentPage
{
	public FrmAdminiciones()
	{
		InitializeComponent();
	}

    private async void btnButton_Clicked(object sender, EventArgs e)
    {
		try
		{

		
			string tipoIdentificacion = pckTipoIdentificacion.Items[pckTipoIdentificacion.SelectedIndex].ToString().ToUpper();
			string apellido = txtApellidos.Text.ToUpper();
			string nombres = txtNombres.Text.ToUpper();
			string telefono = txtTelefono.Text.ToUpper();
			string correo = txtCorreo.Text.ToLower();
			string correoConfirmacion = txtCorreoConfirmacion.Text.ToLower();

			string carrera = pckCarrera.Items[pckCarrera.SelectedIndex].ToString().ToUpper();
			string modalidad = pckModalidad.Items[pckModalidad.SelectedIndex].ToString().ToUpper();
			string campus = pckCampus.Items[pckCampus.SelectedIndex].ToString().ToUpper();


			if (string.IsNullOrEmpty(tipoIdentificacion)	||
				string.IsNullOrEmpty(apellido)				||
				string.IsNullOrEmpty(nombres)				||
				string.IsNullOrEmpty(telefono)				||
				string.IsNullOrEmpty(correo)				||
				string.IsNullOrEmpty(correoConfirmacion)	||
				string.IsNullOrEmpty(carrera)				||
				string.IsNullOrEmpty(modalidad)				||
				string.IsNullOrEmpty(campus))
			{
				DisplayAlert("ALERTA", "Todos los campos deben ser completados", "Aceptar");
				return;
			}

			if(correo != correoConfirmacion)
			{
				DisplayAlert("VERIFICACION CORREO", "El correo debe ser el mismo", "Aceptar");
				return;
			}

			string contenidoArchivo =
                $"===============================================\n" +
                $"Tipo Identificacion: {tipoIdentificacion}\n" +
				$"Apellidos: {apellido}\n" +
				$"Nombres: {nombres}\n" +
				$"Telefono: {telefono}\n" +
				$"Correo: {correo}\n" +
				$"Correo Confirmación {correoConfirmacion}\n" +
				$"Carrera: {carrera}\n" +
				$"Modalidad: {modalidad}\n" +
				$"Campus: {modalidad}";

			string rutaDirectorio = FileSystem.AppDataDirectory;
			string nombreArchivo = "DatosFormulario.txt";
			string rutaCompleta = Path.Combine(rutaDirectorio, nombreArchivo);

			await File.WriteAllTextAsync(rutaCompleta, contenidoArchivo);

			await DisplayAlert("Éxito", $"Datos guardados en: {rutaCompleta}", "OK");
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"No se pudo guardar el archivo: {ex.Message}", "OK");
        }
    }
}