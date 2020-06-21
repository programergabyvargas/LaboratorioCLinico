using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Laboratorio.Models
{
	public interface IRepositorioObraSocial : IRepositorio<ObraSocial>
	{
		Paciente ObtenerPorEmail(string email);
        IList<Paciente> BuscarPorNombre(string nombre);
    }
}
