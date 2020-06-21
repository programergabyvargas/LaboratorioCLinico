using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Laboratorio.Models
{
    public class Bioquimico
    {
		[Key]
		[Display(Name = "Código")]
		public int IdBioquimico { get; set; }
		[Required]
		public int Dni { get; set; }
		[Required]
		public string Apellido { get; set; }
		[Required]
		public string Nombre { get; set; }
		public DateTime FechaNacimiento { get; set; }
		public string Telefono { get; set; }
		[Required, EmailAddress]
		public string Email { get; set; }
		[Required]
		public string Matricula { get; set; }
		[Required]
		public string Usuario { get; set; }

		[Required, DataType(DataType.Password)]
		public string Clave { get; set; }
	}
}
