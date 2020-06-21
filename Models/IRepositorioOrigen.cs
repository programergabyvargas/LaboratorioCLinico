using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Laboratorio.Models
{
	public interface IRepositorioOrigen : IRepositorio<Origen>
	{
		Origen ObtenerPorEmail(string email);
        IList<Origen> BuscarPorNombre(string nombre);
    }
}
