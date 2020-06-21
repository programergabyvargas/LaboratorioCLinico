using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Laboratorio.Models
{
    public class RepositorioBioquimico: RepositorioBase, IRepositorio<Bioquimico>
    {
		//private readonly string connectionString;
		//private readonly IConfiguration configuration;

		public RepositorioBioquimico(IConfiguration configuration) : base(configuration)
		{
			
		}

		public int Alta(Bioquimico p)
		{
			throw new NotImplementedException();
		}

		public int Baja(int id)
		{
			throw new NotImplementedException();
		}

		public int Modificacion(Bioquimico p)
		{
			throw new NotImplementedException();
		}

		public Bioquimico ObtenerPorId(int id)
		{
			throw new NotImplementedException();
		}

		public IList<Bioquimico> ObtenerTodos()
		{
			IList<Bioquimico> res = new List<Bioquimico>();
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				string sql = $"SELECT IdBioquimico ,Dni ,Apellido, Nombre, FechaNacimiento, Telefono, Email, Matricula, Usuario , Clave " +
							 "FROM Bioquimicos";
				using (SqlCommand command = new SqlCommand(sql, connection))
				{
					command.CommandType = CommandType.Text;
					connection.Open();
					var reader = command.ExecuteReader();
					while (reader.Read())
					{
						Bioquimico b = new Bioquimico
						{
							IdBioquimico = reader.GetInt32(0),
							Dni = reader.GetInt32(1),
							Apellido = reader.GetString(2),
							Nombre = reader.GetString(3),
							FechaNacimiento = reader.GetDateTime(4),
							Telefono = reader.GetString(5),
							Email = reader.GetString(6),
							Matricula = reader.GetString(7),
							Usuario = reader.GetString(8),
							Clave = reader.GetString(9),
						};
						res.Add(b);
					}
					connection.Close();
				}
			}
			return res;
		}

		public Bioquimico ObtenerPorEmail(string email)
		{
			Bioquimico b = null;
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				string sql = $"SELECT IdBioquimico ,Dni ,Apellido, Nombre, FechaNacimiento, Telefono, Email, Matricula,Usuario , Clave FROM  Bioquimicos" +
					$" WHERE Email=@email";
				using (SqlCommand command = new SqlCommand(sql, connection))
				{
					command.CommandType = CommandType.Text;
					command.Parameters.Add("@email", SqlDbType.VarChar).Value = email;
					connection.Open();
					var reader = command.ExecuteReader();
					if (reader.Read())
					{
						b = new Bioquimico
						{
							IdBioquimico = reader.GetInt32(0),
							Dni = reader.GetInt32(1),
							Apellido = reader.GetString(2),
							Nombre = reader.GetString(3),
							FechaNacimiento = reader.GetDateTime(4),
							Telefono = reader.GetString(5),
							Email = reader.GetString(6),
							Usuario = reader.GetString(7),
							Clave = reader.GetString(8),
						};
					}
					connection.Close();
				}
			}
			return b;
		}

		public IList<Bioquimico> BuscarPorNombre(string nombre)
		{
			List<Bioquimico> res = new List<Bioquimico>();
			Bioquimico b = null;
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				string sql = $"SELECT IdBioquimico ,Dni ,Apellido, Nombre, FechaNacimiento, Telefono, Email, Matricula,Usuario , Clave FROM Bioquimicos" +
					$" WHERE Nombre LIKE @nombre OR Apellido LIKE @nombre";
				using (SqlCommand command = new SqlCommand(sql, connection))
				{
					command.Parameters.Add("@nombre", SqlDbType.VarChar).Value = nombre;
					command.CommandType = CommandType.Text;
					connection.Open();
					var reader = command.ExecuteReader();
					while (reader.Read())
					{
						b = new Bioquimico
						{
							IdBioquimico = reader.GetInt32(0),
							Dni = reader.GetInt32(1),
							Apellido = reader.GetString(2),
							Nombre = reader.GetString(3),
							FechaNacimiento = reader.GetDateTime(4),
							Telefono = reader.GetString(5),
							Email = reader.GetString(6),
							Usuario = reader.GetString(7),
							Clave = reader.GetString(8),
						};
						res.Add(b);
					}
					connection.Close();
				}
			}
			return res;
		}

	}
}
