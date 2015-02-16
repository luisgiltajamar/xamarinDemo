
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ListadoPersonas;
using ListadoPersonas.Utilidades.Mvvm;

namespace ListaPersonas.Droid
{
	[Activity (Label = "ListadoActivity")]			
	public class ListadoActivity : BaseActivity<ListadoViewModel>
	{

		ListView listView;
		Adapter adapter;




		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
		
			SetContentView (Resource.Layout.Listado);

			listView = FindViewById<ListView> (Resource.Id.listaPersonas);

			listView.Adapter = adapter = new Adapter (this);

		//	listView.ItemClick += SeleccionarCalendario;

		
		}

		protected async override void OnResume()
		{
			base.OnResume();

			try
			{
				await viewModel.Cargar();

				adapter.NotifyDataSetInvalidated();
			}
			catch (Exception exc)
			{
				DisplayError(exc);
			}
		}

		/*protected async void SeleccionarCalendario(object sender, Android.Widget.AdapterView.ItemClickEventArgs e){
			try
			{
				viewModel.Calendario=adapter[e.Position];
				await viewModel.ObtenerEventos();

				StartActivity(typeof(EventosActivity));
			}
			catch (Exception exc)
			{
				DisplayError(exc);
			}

		}*/




		class Adapter : BaseAdapter<Personas>
		{
			readonly ListadoViewModel listadoViewModel = ServiceContainer.Resolve<ListadoViewModel>();
			readonly LayoutInflater inflater;

			public Adapter(Context context)
			{
				inflater = (LayoutInflater)context.GetSystemService (Context.LayoutInflaterService);
			}

			public override long GetItemId(int position)
			{
				return (long)position;
			}

			public override View GetView(int position, View convertView, ViewGroup parent)
			{
				if (convertView == null)
				{
					convertView = inflater.Inflate (Resource.Layout.PersonaItem, null);
				}

				if (position % 2 != 0)
					convertView.SetBackgroundColor(Android.Graphics.Color.Black);
				else
					convertView.SetBackgroundColor(new Android.Graphics.Color(41,41,41));

				var persona = this [position];
				var nombre = convertView.FindViewById<TextView>(Resource.Id.txtNombre);
				nombre.Text = persona.Nombre + " " + persona.Apellidos;
				return convertView;
			}

			public override int Count
			{
				get { return listadoViewModel.Personas == null ? 0 : listadoViewModel.Personas.Count; }
			}

			public override Personas this[int index]
			{
				get { return listadoViewModel.Personas [index]; }
			}
		}
	}
	}


