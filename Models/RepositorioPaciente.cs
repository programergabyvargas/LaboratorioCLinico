using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Laboratorio.Models
{
    public class RepositorioPaciente: RepositorioBase, IRepositorio<Paciente>
    {
		//private readonly string connectionString;
		//private readonly IConfiguration configuration;

		public RepositorioPaciente(IConfiguration configuration) : base(configuration)
		{
			
		}

		public int Alta(Paciente p)
		{
			throw new NotImplementedException();
		}

		public int Baja(int id)
		{
			throw new NotImplementedException();
		}

		public int Modificacion(Paciente p)
		{
			throw new NotImplementedException();
		}

		public Paciente ObtenerPorId(int id)
		{
			throw new NotImplementedException();
		}

		public IList<Paciente> ObtenerTodos()
		{
			IList<Paciente> res = new List<Paciente>();
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				string sql = $"SELECT IdPaciente, Apellido, Nombre, Dni, Telefono, Email, Clave " +
					         "FROM Pacientes";
				using (SqlCommand command = new SqlCommand(sql, connection))
				{
					command.CommandType = CommandType.Text;
					connection.Open();
					var reader = command.ExecuteReader();
					while (reader.Read())
					{
						Paciente p = new Paciente
						{
							IdPaciente = reader.GetInt32(0),
							Apellido = reader.GetString(1),
							 Nombre = reader.GetString(2),
							Dni = reader.GetInt32(3),
							Telefono = reader.GetString(4),
							Email = reader.GetString(5),
							Clave = reader.GetString(6),
						};
						res.Add(p);
					}
					connection.Close();
				}
			}
			return res;
		}

		public Paciente ObtenerPorEmail(string email)
		{
			Paciente p = null;
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				string sql = $"SELECT IdPaciente, Nombre, Apellido, Dni, Telefono, Email, Clave FROM Pacientes" +
					$" WHERE Email=@email";
				using (SqlCommand command = new SqlCommand(sql, connection))
				{
					command.CommandType = CommandType.Text;
					command.Parameters.Add("@email", SqlDbType.VarChar).Value = email;
					connection.Open();
					var reader = command.ExecuteReader();
					if (reader.Read())
					{
						p = new Paciente
						{
							IdPaciente = reader.GetInt32(0),
							Nombre = reader.GetString(1),
							Apellido = reader.GetString(2),
							Dni = reader.GetInt32(3),
							Telefono = reader.GetString(4),
							Email = reader.GetString(5),
							Clave = reader.GetString(6),
						};
					}
					connection.Close();
				}
			}
			return p;
		}

		public IList<Paciente> BuscarPorNombre(string nombre)
		{
			List<Paciente> res = new List<Paciente>();
			Paciente p = null;
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				string sql = $"SELECT IdPaciente, Nombre, Apellido, Dni, Telefono, Email, Clave FROM Pacientes" +
					$" WHERE Nombre LIKE @nombre OR Apellido LIKE @nombre";
				using (SqlCommand command = new SqlCommand(sql, connection))
				{
					command.Parameters.Add("@nombre", SqlDbType.VarChar).Value = nombre;
					command.CommandType = CommandType.Text;
					connection.Open();
					var reader = command.ExecuteReader();
					while (reader.Read())
					{
						p = new Paciente
						{
							IdPaciente = reader.GetInt32(0),
							Nombre = reader.GetString(1),
							Apellido = reader.GetString(2),
							Dni = reader.GetInt32(3),
							Telefono = reader.GetString(4),
							Email = reader.GetString(5),
							Clave = reader.GetString(6),
						};
						res.Add(p);
					}
					connection.Close();
				}
			}
			return res;
		}

	}
}
