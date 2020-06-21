using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Laboratorio.Models
{
    public class RepositorioTurno: RepositorioBase, IRepositorio<Turno>
    {
		//private readonly string connectionString;
		//private readonly IConfiguration configuration;

		public RepositorioTurno(IConfiguration configuration) : base(configuration)
		{
			
		}

		public int Alta(Turno p)
		{
			throw new NotImplementedException();
		}

		public int Baja(int id)
		{
			throw new NotImplementedException();
		}

		public int Modificacion(Turno p)
		{
			throw new NotImplementedException();
		}

		public Turno ObtenerPorId(int id)
		{
			throw new NotImplementedException();
		}

		public IList<Turno> ObtenerTodos()
		{
			IList<Turno> res = new List<Turno>();
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				string sql = $"SELECT IdTurno, FechaTurno, t.DniPaciente, t.IdObraSocial, p.Apellido, p.Nombre, p.Telefono, p.Email, os.Nombre  " +
							 "FROM Turno t" +
							 "INNER JOIN Paciente p ON t.DniPaciente = p.Dni " +
							 "INNER JOIN ObraSociales os ON t.IdObraSocial = os.IdObraSocial ";
							 

				using (SqlCommand command = new SqlCommand(sql, connection))
				{
					command.CommandType = CommandType.Text;
					connection.Open();
					var reader = command.ExecuteReader();
					while (reader.Read())
					{
						Turno t = new Turno
						{
							IdTurno = reader.GetInt32(0),
							FechaTurno = reader.GetDateTime(1),
							DniPaciente = reader.GetInt32(2),
							IdObraSocial = reader.GetInt32(3),
							Pacient = new Paciente
							{
								IdPaciente = reader.GetInt32(2),
								Apellido = reader.GetString(4),
								Nombre = reader.GetString(5),
								Telefono = reader.GetString(6),
								Email = reader.GetString(7),
							},
							Obra = new ObraSocial
							{
								IdObraSocial = reader.GetInt32(3),
								Nombre = reader.GetString(8),
							}
						};
						res.Add(t);
					}
					connection.Close();
				}
			}
			return res;
		}

		public IList<Turno> BuscarPorPaciente(int dni)
		{
			IList<Turno> res = new List<Turno>();
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				string sql = $"SELECT IdTurno, FechaTurno, DniPaciente, IdObraSocial FROM Turno t INNER JOIN Pacientes p ON t.DniPaciente = p.DniPaciente " +
					$" WHERE t.DniPaciente=@dni";
				using (SqlCommand command = new SqlCommand(sql, connection))
				{
					command.CommandType = CommandType.Text;
					command.Parameters.Add("@dni", SqlDbType.VarChar).Value = dni;
					connection.Open();
					var reader = command.ExecuteReader();
					while (reader.Read())
					{
						Turno t = new Turno
						{
							IdTurno = reader.GetInt32(0),
							FechaTurno = reader.GetDateTime(1),
							DniPaciente = reader.GetInt32(2),
							IdObraSocial = reader.GetInt32(3),

						};
						res.Add(t);
					}
					connection.Close();
				}
			}
			return res;
		}


		public IList<Turno> BuscarPorObraSocial(int idObra)
		{
			IList<Turno> res = new List<Turno>();
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				string sql = $"SELECT IdTurno, FechaTurno, DniPaciente, IdObraSocial FROM Turno t INNER JOIN ObraSociales o ON t.IdObraSocial = o.IdObraSocial " +
					$" WHERE t.IdObraSocial=@idObra";
				using (SqlCommand command = new SqlCommand(sql, connection))
				{
					command.CommandType = CommandType.Text;
					command.Parameters.Add("@idObra", SqlDbType.VarChar).Value = idObra;
					connection.Open();
					var reader = command.ExecuteReader();
					while (reader.Read())
					{
						Turno t = new Turno
						{
							IdTurno = reader.GetInt32(0),
							FechaTurno = reader.GetDateTime(1),
							DniPaciente = reader.GetInt32(2),
							IdObraSocial = reader.GetInt32(3),

						};
						res.Add(t);
					}
					connection.Close();
				}
			}
			return res;
		}

		public IList<Turno> BuscarPorRangoDeFecha(DateTime fechaInicio, DateTime fechaFin)
		{
			IList<Turno> res = new List<Turno>();
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				string sql = $"SELECT IdTurno, FechaTurno, DniPaciente, IdObraSocial " +
					         $"FROM Turno t  " +
					         $"WHERE t.FechaTurno BETWEEN @fechaInicio AND @fechaFin";

				using (SqlCommand command = new SqlCommand(sql, connection))
				{
					command.Parameters.Add("@fechaInicio", SqlDbType.Date).Value = fechaInicio;
					command.Parameters.Add("@fechaFin", SqlDbType.Date).Value = fechaFin;
					command.CommandType = CommandType.Text;
					connection.Open();
					var reader = command.ExecuteReader();
					while (reader.Read())
					{
						Turno t = new Turno
						{
							IdTurno = reader.GetInt32(0),
							FechaTurno = reader.GetDateTime(1),
							DniPaciente = reader.GetInt32(2),
							IdObraSocial = reader.GetInt32(3),

						};
						res.Add(t);
					}
					connection.Close();
				}
			}
			return res;
		}


	}
}
