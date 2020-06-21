using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Laboratorio.Models
{
	public interface IRepositorioPaciente : IRepositorio<Paciente>
	{
		Paciente ObtenerPorEmail(string email);
        IList<Paciente> BuscarPorNombre(string nombre);
    }
}
