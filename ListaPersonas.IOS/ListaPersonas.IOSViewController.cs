using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using ListadoPersonas;
using ListadoPersonas.Utilidades.Mvvm;

namespace ListaPersonas.IOS
{
	public partial class ListaPersonas_IOSViewController : UIViewController
	{

		readonly RegistroViewModel registroViewModel = 
			ServiceContainer.Resolve<RegistroViewModel>();



		public ListaPersonas_IOSViewController (IntPtr handle) : base (handle)
		{
		}

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}

		#region View lifecycle

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			txtNombre.ShouldReturn = _ => 
			{
				txtApellido.BecomeFirstResponder();
				return false;
			};
			txtApellido.ShouldReturn = _ => 
			{
				txtEdad.BecomeFirstResponder();
				return false;
			};

			txtEdad.ShouldReturn = _ =>
			{
				OnRegistro(this, EventArgs.Empty);
				return false;
			};

			btnReg.TouchUpInside += OnRegistro;


			// Perform any additional setup after loading the view, typically from a nib.
		}

	
		//Nuevo


		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);
			txtNombre.Text =
				txtApellido.Text = txtEdad.Text = string.Empty;

			registroViewModel.IsBusyChanged += OnIsBusyChanged;
		}

		public override void ViewDidAppear (bool animated)
		{
			base.ViewDidAppear (animated);
			registroViewModel.IsBusyChanged += OnIsBusyChanged;
		}

		public override void ViewWillDisappear (bool animated)
		{
			base.ViewWillDisappear (animated);
		}

		public override void ViewDidDisappear (bool animated)
		{
			base.ViewDidDisappear (animated);
		}

		void OnIsBusyChanged (object sender, EventArgs e)
		{
			txtNombre.Enabled =
				txtApellido.Enabled = 
					txtEdad.Enabled = 
						btnReg.Enabled= !registroViewModel.IsBusy;
		}
		async void OnRegistro (object sender, EventArgs e)
		{
			registroViewModel.Persona = new Personas (){ 
				Nombre=txtNombre.Text,
				Apellidos=txtApellido.Text,
				Edad=Convert.ToInt32(txtEdad.Text)
			
			
			};

			try
			{
				await registroViewModel.Registro();

				UIApplication.SharedApplication.RegisterForRemoteNotificationTypes(
					UIRemoteNotificationType.Alert | 
					UIRemoteNotificationType.Badge | 
					UIRemoteNotificationType.Sound);


			}
			catch (Exception exc)
			{
				exc.DisplayError();
			}
		}


		#endregion
	}
}

