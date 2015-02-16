using System;
using Android.App;
using ListadoPersonas;
using ListadoPersonas.Utilidades.Mvvm;
using Android.OS;
using Android.Views;
using System.Linq;
using Android.Content;

namespace ListaPersonas.Droid
{
	[Activity(Icon = "@drawable/Icon",ScreenOrientation=Android.Content.PM.ScreenOrientation.Portrait)]			
	public class BaseActivity<TViewModel> : Activity
		where TViewModel : BaseViewModel
	{
		protected readonly TViewModel viewModel;
		protected ProgressDialog progress;



		public BaseActivity()
		{
			viewModel = ServiceContainer.Resolve<TViewModel>();



		}

		protected override void OnCreate(Bundle bundle)
		{




			base.OnCreate(bundle);
			if(ActionBar!=null)
				ActionBar.Hide ();
			progress = new ProgressDialog(this);

			progress.SetCancelable(false);
			progress.SetTitle(Resource.String.Loading);



		}

		protected override void OnResume()
		{
			base.OnResume();

			viewModel.IsBusyChanged += OnIsBusyChanged;
		}

		protected override void OnPause()
		{
			base.OnPause();

			viewModel.IsBusyChanged -= OnIsBusyChanged;
		}

		protected void DisplayError(Exception exc)
		{
			string error;
			AggregateException aggregate = exc as AggregateException;
			if (aggregate != null)
			{
				error = aggregate.InnerExceptions.First().Message;
			}
			else
			{
				error = exc.Message;
			}

			new AlertDialog.Builder(this)
				.SetTitle(Resource.String.ErrorTitle)
				.SetMessage(error)
				.SetPositiveButton(Android.Resource.String.Ok, (IDialogInterfaceOnClickListener)null)
				.Show();
		}

		void OnIsBusyChanged (object sender, EventArgs e)
		{
			if (viewModel.IsBusy)
				progress.Show();
			else
				progress.Hide();
		}

	}
}

