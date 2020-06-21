using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Laboratorio.Models
{
    public class RepositorioMuestra: RepositorioBase, IRepositorio<Muestra>
    {
		//private readonly string connectionString;
		//private readonly IConfiguration configuration;

		public RepositorioMuestra(IConfiguration configuration) : base(configuration)
		{
			
		}

		public int Alta(Muestra p)
		{
			throw new NotImplementedException();
		}

		public int Baja(int id)
		{
			throw new NotImplementedException();
		}

		public int Modificacion(Muestra p)
		{
			throw new NotImplementedException();
		}

		public Muestra ObtenerPorId(int id)
		{
			throw new NotImplementedException();
		}

		public IList<Muestra> ObtenerTodos()
		{
			IList<Muestra> res = new List<Muestra>();
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				/*string sql = $"SELECT IdMuestra, NumProtocolo, FechaExtraccion, m.DniPaciente, m.IdBioquimicoExtrae , m.IdOrigen, p.Apellido, p.Nombre, p.Dni , p.Telefono, p.Email, p.Clave, " +
					         $" b.Dni, b.Apellido, b.Nombre, b.FechaNacimiento, b.Telefono, b.Email, b.Matricula, b.Usuario, b.Clave, " +
							 $" o.Nombre, o.Direccion, o.Email, o.Telefono " +
							 $"FROM Muestras m " +
							 $"INNER JOIN pacientes p ON m.DniPaciente = p.Dni " +
							 $"INNER JOIN Bioquimicos b ON m.IdBioquimicoExtrae = b.IdBioquimico " +
							 $"INNER JOIN Origenes o ON  m.IdOrigen = o.IdOrigen ";*/
				string sql = $"SELECT m.NumProtocolo, m.FechaExtraccion, m.DniPaciente, m.IdBioquimicoExtrae , m.IdOrigen, p.Apellido, p.Nombre, p.Dni , p.Telefono, p.Email, p.Clave, " +
					         $"b.Dni, b.Apellido, b.Nombre, b.FechaNacimiento, b.Telefono, b.Email, b.Matricula, b.Usuario, b.Clave, " +
					         $"o.Nombre, o.Direccion, o.Email, o.Telefono " +
							 $" FROM Muestras m " +
							 $"INNER JOIN Pacientes p ON m.DniPaciente = p.Dni " +
							 $"INNER JOIN Bioquimicos b ON m.IdBioquimicoExtrae = b.IdBioquimico " +
							 $"INNER JOIN Origenes o ON m.IdOrigen = o.IdOrigen ";

				using (SqlCommand command = new SqlCommand(sql, connection))
				{
					command.CommandType = CommandType.Text;
					connection.Open();
					var reader = command.ExecuteReader();
					while (reader.Read())
					{
						Muestra m = new Muestra
						{
							
							NumProtocolo = reader.GetInt32(0),
							FechaExtraccion = reader.GetDateTime(1),
							DniPaciente = reader.GetInt32(2),
							IdBioquimicoExtrae = reader.GetInt32(3),
							IdOrigen = reader.GetInt32(4),
							Pacient = new Paciente
							{
								IdPaciente = reader.GetInt32(2),
								Apellido = reader.GetString(5),
								Nombre = reader.GetString(6),
								Dni = reader.GetInt32(7),
								Telefono = reader.GetString(8),
								Email = reader.GetString(9),
								Clave = reader.GetString(10),
							},
							BioquimicoExtrae = new Bioquimico
							{
								IdBioquimico = reader.GetInt32(4),
								Dni = reader.GetInt32(11),
								Apellido = reader.GetString(12),
								Nombre = reader.GetString(13),
								FechaNacimiento = reader.GetDateTime(14),
								Telefono = reader.GetString(15),
								Email = reader.GetString(16),
								Matricula = reader.GetString(17),
								Usuario = reader.GetString(18),
								Clave = reader.GetString(19),
							},
							OrigenMuestra  = new Origen
							{
								IdOrigen = reader.GetInt32(5),
								Nombre = reader.GetString(20),
								Direccion = reader.GetString(21),
								Email = reader.GetString(22),
								Telefono = reader.GetString(23),
							}
							};
						res.Add(m);
					}
					connection.Close();
				}
			}
			return res;
		}

	/*	public Muestra BuscarPorNumProtocolo(int numProtocolo)
		{
			Muestra m = null;
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				string sql = $"SELECT IdMuestra, NumProtocolo, FechaExtraccion, DniPaciente, IdBioquimicoExtrae, IdOrigen " +
							 $" FROM Muestras " +
							 $" WHERE NumProtocolo=@numProtocolo";
				using (SqlCommand command = new SqlCommand(sql, connection))
				{
					command.CommandType = CommandType.Text;
					command.Parameters.Add("@numProtocolo", SqlDbType.VarChar).Value = numProtocolo;
					connection.Open();
					var reader = command.ExecuteReader();
					if (reader.Read())
					{
						 m = new Muestra
						{
							IdMuestra = reader.GetInt32(0),
							NumProtocolo = reader.GetInt32(1),
							FechaExtraccion = reader.GetDateTime(2),
							DniPaciente = reader.GetInt32(3),
							IdBioquimicoExtrae = reader.GetInt32(4),
							IdOrigen = reader.GetInt32(5),

						};
					}
					connection.Close();
				}
			}
			return m;
		}

		
		public IList<Muestra> BuscarPorFechaExtraccion(DateTime fechaExtraccion)
		{
			IList<Muestra> res = new List<Muestra>();
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				string sql = $"SELECT  IdMuestra, NumProtocolo, FechaExtraccion, m.DniPaciente, m.IdBioquimicoExtrae, m.IdOrigen " +
					         $"FROM Muestras m " +
					         $"WHERE FechaExtraccion = @fechaExtraccion";

				using (SqlCommand command = new SqlCommand(sql, connection))
				{
					command.Parameters.Add("@fechaExtraccion", SqlDbType.Date).Value = fechaExtraccion;
					command.CommandType = CommandType.Text;
					connection.Open();
					var reader = command.ExecuteReader();
					while (reader.Read())
					{
						Muestra m = new Muestra
						{
							IdMuestra = reader.GetInt32(0),
							NumProtocolo = reader.GetInt32(1),
							FechaExtraccion = reader.GetDateTime(2),
							DniPaciente = reader.GetInt32(3),
							IdBioquimicoExtrae = reader.GetInt32(4),
							IdOrigen = reader.GetInt32(5),

						};
						res.Add(m);
					}
					connection.Close();
				}
			}
			return res;
		}*/


	}
}
