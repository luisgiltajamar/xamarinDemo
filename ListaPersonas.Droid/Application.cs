using System;
using ListadoPersonas;
using ListadoPersonas.Utilidades.Mvvm;

namespace ListaPersonas.Droid
{
	using System;
	using Android.App;
	using Android.Runtime;
	using Android.Graphics;



		[Application()]
		public class Application : Android.App.Application
		{
			public Application(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{

			}

			public override void OnCreate()
			{
				base.OnCreate();

				//ViewModels
			ServiceContainer.Register<RegistroViewModel>(() => new RegistroViewModel());


				//Models

				ServiceContainer.Register<IWebService>(() => new WebServiceImpl());
				

			}



		}
	}




