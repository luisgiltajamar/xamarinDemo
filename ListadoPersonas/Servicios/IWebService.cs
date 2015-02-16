using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ListadoPersonas
{
	public interface IWebService
	{
		Task Registro(Personas p);

		Task<List<Personas>> Listado ();
		Task<Personas> Detalle (String id);
	}
}

