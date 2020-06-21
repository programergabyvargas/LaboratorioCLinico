using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Laboratorio.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
       public DbSet<Paciente> Pacientes { get; set; }
       public DbSet<ObraSocial> ObraSociales { get; set; }
       public DbSet<Bioquimico> Bioquimicos { get; set; }
       public DbSet<Turno> Turnos { get; set; }
       public DbSet<Origen> Origenes { get; set; }
       public DbSet<Muestra> Muestras { get; set; }



    }
}
