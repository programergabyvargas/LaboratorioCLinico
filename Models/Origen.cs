using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Laboratorio.Models
{
    public class Origen
    {
		[Key]
		[Display(Name = "Código")]
		public int IdOrigen { get; set; }
		[Required]
		public string Nombre { get; set; }
		[Required]
		public string Direccion { get; set; }
		[Required, EmailAddress]
		public string Email { get; set; }
		[Required]
		public string Telefono { get; set; }
	}
}
