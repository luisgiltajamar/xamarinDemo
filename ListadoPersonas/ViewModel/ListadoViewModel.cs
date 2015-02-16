using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ListadoPersonas
{
	public class ListadoViewModel:BaseViewModel
	{
		public List<Personas> Personas {
			get;
			set;
		}
	
		public Personas PersonaSeleccionada {
			get;
			set;
		}



		public async Task Cargar()
		{

			IsBusy = true;
			try
			{
				Personas=	await service.Listado();

			
			}
			catch(Exception ee){
				throw new Exception ("Error cargando");
			}
			finally
			{
				IsBusy = false;
			}

		}

		public void Seleccionar(int idx){

			PersonaSeleccionada = Personas[idx];

		}


	}
}

