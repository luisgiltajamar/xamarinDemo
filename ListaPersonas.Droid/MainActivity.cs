using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using ListadoPersonas;

namespace ListaPersonas.Droid
{
	[Activity (Label = "ListaPersonas.Droid", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : BaseActivity<RegistroViewModel>
	{

		EditText txtNom,txtApe,txtEda;
		Button btnReg;


		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			txtNom = FindViewById<EditText> (Resource.Id.txtNombre);
			txtApe=FindViewById<EditText> (Resource.Id.txtApellido);
			txtEda= FindViewById<EditText> (Resource.Id.txtEdad);
			btnReg= FindViewById<Button> (Resource.Id.btnRegistro);

			btnReg.Click += OnRegistro;

		}

		async void OnRegistro (object sender, EventArgs e)
		{

			viewModel.Persona = new Personas () {
				Nombre = txtNom.Text,
				Apellidos = txtApe.Text,
				Edad = Convert.ToInt32 (txtEda.Text)

			};

			try
			{
				await viewModel.Registro();


			}
			catch (Exception exc)
			{
				DisplayError(exc);
			}

		}
	}
}


