using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Laboratorio.Models
{
    public class Turno
    {
		[Key]
		[Display(Name = "Código")]
		public int IdTurno { get; set; }
		[Required]
		public DateTime FechaTurno { get; set; }
		[Required]
		public int DniPaciente { get; set; }
		[ForeignKey("DniPaciente")]
        public Paciente Pacient { get; set; }
		public int IdObraSocial { get; set; }
		[ForeignKey("IdObraSocial")]
		public ObraSocial Obra { get; set; }


	}
}
