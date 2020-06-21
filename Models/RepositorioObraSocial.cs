using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Laboratorio.Models
{
    public class RepositorioObraSocial: RepositorioBase, IRepositorio<ObraSocial>
    {
		//private readonly string connectionString;
		//private readonly IConfiguration configuration;

		public RepositorioObraSocial(IConfiguration configuration) : base(configuration)
		{
			
		}

		public int Alta(ObraSocial p)
		{
			throw new NotImplementedException();
		}

		public int Baja(int id)
		{
			throw new NotImplementedException();
		}

		public int Modificacion(ObraSocial p)
		{
			throw new NotImplementedException();
		}

		public ObraSocial ObtenerPorId(int id)
		{
			throw new NotImplementedException();
		}

		public IList<ObraSocial> ObtenerTodos()
		{
			IList<ObraSocial> res = new List<ObraSocial>();
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				string sql = $"SELECT IdObraSocial, Nombre, Direccion, Telefono, Email " +
					         "FROM ObraSocial";
				using (SqlCommand command = new SqlCommand(sql, connection))
				{
					command.CommandType = CommandType.Text;
					connection.Open();
					var reader = command.ExecuteReader();
					while (reader.Read())
					{
						ObraSocial p = new ObraSocial
						{
							IdObraSocial = reader.GetInt32(0),
							Nombre = reader.GetString(1),
							Direccion = reader.GetString(2),
							Telefono = reader.GetString(3),
							Email = reader.GetString(4),
						};
						res.Add(p);
					}
					connection.Close();
				}
			}
			return res;
		}

		public ObraSocial ObtenerPorEmail(string email)
		{
			ObraSocial p = null;
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				string sql = $"SELECT IdObraSocial, Nombre, Direccion, Telefono, Email FROM ObraSocial" +
					$" WHERE Email=@email";
				using (SqlCommand command = new SqlCommand(sql, connection))
				{
					command.CommandType = CommandType.Text;
					command.Parameters.Add("@email", SqlDbType.VarChar).Value = email;
					connection.Open();
					var reader = command.ExecuteReader();
					if (reader.Read())
					{
						p = new ObraSocial
						{
							IdObraSocial = reader.GetInt32(0),
							Nombre = reader.GetString(1),
							Direccion = reader.GetString(2),
							Telefono = reader.GetString(3),
							Email = reader.GetString(4),
						};
					}
					connection.Close();
				}
			}
			return p;
		}

		public IList<ObraSocial> BuscarPorNombre(string nombre)
		{
			List<ObraSocial> res = new List<ObraSocial>();
			ObraSocial p = null;
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				string sql = $"SELECT IdObraSocial, Nombre, Direccion, Dni, Telefono, Email FROM ObraSocial" +
					$" WHERE Nombre LIKE @nombre";
				using (SqlCommand command = new SqlCommand(sql, connection))
				{
					command.Parameters.Add("@nombre", SqlDbType.VarChar).Value = nombre;
					command.CommandType = CommandType.Text;
					connection.Open();
					var reader = command.ExecuteReader();
					while (reader.Read())
					{
						p = new ObraSocial
						{
							IdObraSocial = reader.GetInt32(0),
							Nombre = reader.GetString(1),
							Direccion = reader.GetString(2),
							Telefono = reader.GetString(3),
							Email = reader.GetString(4),
							
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
