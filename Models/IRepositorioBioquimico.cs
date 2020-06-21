using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Laboratorio.Models
{
	public interface IRepositorioBioquimico : IRepositorio<Bioquimico>
	{
		Bioquimico ObtenerPorEmail(string email);
        IList<Bioquimico> BuscarPorNombre(string nombre);
    }
}
