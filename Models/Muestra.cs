using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Laboratorio.Models
{
    public class Muestra
	{
		
		[Key]
		[Display(Name = "Código")]
		public int NumProtocolo { get; set; }
		//[Required]
		[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
		public DateTime FechaExtraccion { get; set; }
		[Required]

		public int DniPaciente { get; set; }
		[ForeignKey("DniPaciente")]
        public Paciente Pacient { get; set; }
		
		public int IdBioquimicoExtrae { get; set; }
		[ForeignKey("IdBioquimicoExtrae")]
		public Bioquimico BioquimicoExtrae { get; set; }

		
		public int IdOrigen { get; set; }
		[ForeignKey("IdOrigen")]
		public Origen OrigenMuestra { get; set; }



	}
}
