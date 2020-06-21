using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Laboratorio.Models
{
    public class RepositorioOrigen: RepositorioBase, IRepositorio<Origen>
    {
		//private readonly string connectionString;
		//private readonly IConfiguration configuration;

		public RepositorioOrigen(IConfiguration configuration) : base(configuration)
		{
			
		}

		public int Alta(Origen p)
		{
			throw new NotImplementedException();
		}

		public int Baja(int id)
		{
			throw new NotImplementedException();
		}

		public int Modificacion(Origen p)
		{
			throw new NotImplementedException();
		}

		public Origen ObtenerPorId(int id)
		{
			throw new NotImplementedException();
		}

		public IList<Origen> ObtenerTodos()
		{
			IList<Origen> res = new List<Origen>();
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				string sql = $"SELECT IdOrigen, Nombre, Direccion, Email, Telefono " +
					         "FROM Origen";
				using (SqlCommand command = new SqlCommand(sql, connection))
				{
					command.CommandType = CommandType.Text;
					connection.Open();
					var reader = command.ExecuteReader();
					while (reader.Read())
					{
						Origen p = new Origen
						{
							IdOrigen = reader.GetInt32(0),
							Nombre = reader.GetString(1),
							Direccion = reader.GetString(2),
							Email = reader.GetString(3),
							Telefono = reader.GetString(4),
						};
						res.Add(p);
					}
					connection.Close();
				}
			}
			return res;
		}

		public Origen ObtenerPorEmail(string email)
		{
			Origen p = null;
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				string sql = $"SELECT IdOrigen, Nombre, Direccion, Email, Telefono FROM Origen " +
					$" WHERE Email=@email";
				using (SqlCommand command = new SqlCommand(sql, connection))
				{
					command.CommandType = CommandType.Text;
					command.Parameters.Add("@email", SqlDbType.VarChar).Value = email;
					connection.Open();
					var reader = command.ExecuteReader();
					if (reader.Read())
					{
						p = new Origen
						{
							IdOrigen = reader.GetInt32(0),
							Nombre = reader.GetString(1),
							Direccion = reader.GetString(2),
							Email = reader.GetString(3),
							Telefono = reader.GetString(4),
						};
					}
					connection.Close();
				}
			}
			return p;
		}

		public IList<Origen> BuscarPorNombre(string nombre)
		{
			List<Origen> res = new List<Origen>();
			Origen p = null;
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				string sql = $"SELECT IdOrigen, Nombre, Direccion, Email, Telefono FROM Origen" +
					$" WHERE Nombre LIKE @nombre ";
				using (SqlCommand command = new SqlCommand(sql, connection))
				{
					command.Parameters.Add("@nombre", SqlDbType.VarChar).Value = nombre;
					command.CommandType = CommandType.Text;
					connection.Open();
					var reader = command.ExecuteReader();
					while (reader.Read())
					{
						p = new Origen
						{
							IdOrigen = reader.GetInt32(0),
							Nombre = reader.GetString(1),
							Direccion = reader.GetString(2),
							Email = reader.GetString(3),
							Telefono = reader.GetString(4),
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
