using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Laboratorio.Models
{
    public class Paciente
    {
		
		public int IdPaciente { get; set; }
		//[Required]
		public string Apellido { get; set; }
		//[Required]
		public string Nombre { get; set; }
		
		[Key]
		[Display(Name = "Código")]
		public int Dni { get; set; }


		public string Telefono { get; set; }
		[Required, EmailAddress]
		public string Email { get; set; }
		[Required, DataType(DataType.Password)]
		public string Clave { get; set; }
	}
}
