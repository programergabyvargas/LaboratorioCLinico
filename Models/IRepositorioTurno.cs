using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Laboratorio.Models
{
	public interface IRepositorioTurno : IRepositorio<Turno>
	{
		//Turno ObtenerPorId(int idTurno);
        IList<Turno> BuscarPorPaciente(int dni);
		IList<Turno> BuscarPorObraSocial(string nombre);
		IList<Turno> BuscarPorRangoDeFecha(DateTime fechaInicio, DateTime fechaFin);


	}
}
