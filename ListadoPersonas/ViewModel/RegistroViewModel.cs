using System;
using System.Threading.Tasks;

namespace ListadoPersonas
{
	public class RegistroViewModel:BaseViewModel
	{
		public Personas Persona {
			get;
			set;
		}
	

		public async Task Registro()
		{
			if (string.IsNullOrEmpty(Persona.Nombre))
				throw new Exception("El nombre  es obligatorio.");

			if (string.IsNullOrEmpty(Persona.Apellidos))
				throw new Exception("El apellido es obligatorio.");
			if (Persona.Edad<18)
				throw new Exception("Edad minima 18");


			IsBusy = true;
			try
			{
				await service.Registro(Persona);

			
			}
			catch(Exception ee){
				throw new Exception ("Error en el alta");
			}
			finally
			{
				IsBusy = false;
			}

		}

	}
}

