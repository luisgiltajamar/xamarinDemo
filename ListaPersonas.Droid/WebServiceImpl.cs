using System;
using ListadoPersonas;
using Microsoft.WindowsAzure.MobileServices;
using ListadoPersonas.Utilidades;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ListaPersonas.Droid
{
	public class WebServiceImpl:IWebService
	{

		MobileServiceClient client;
		IMobileServiceTable<Personas> tablaPersonas;


		public WebServiceImpl(){
			CurrentPlatform.Init();

			client = new MobileServiceClient (Cadenas.AzureUrl, Cadenas.AzureKey);
			tablaPersonas = client.GetTable<Personas> ();


		}


		#region IWebService implementation

		public async Task Registro (Personas p)
		{
			await tablaPersonas.InsertAsync (p);
		}

		public async Task<List<Personas>> Listado ()
		{
			var r = await tablaPersonas.ToListAsync ();
			return r;
		}

		public async Task<Personas> Detalle (string id)
		{
			var r=await tablaPersonas.Where(o=>o.id==id).ToListAsync();

			if (r.Count > 0)
				return r [0];

			return null;
		}

		#endregion


	}
}

