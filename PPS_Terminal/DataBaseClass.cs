using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Media.Imaging;

namespace PPS_Terminal
{
	public static class DataBaseClass
	{
		public static SqlConnection Connection;

		public static string GetConnectionString()
		{
			string result;
			if (!File.Exists("connect.udl"))
			{
				result = "Data Source=localhost;Initial Catalog=PPS;Persist Security Info=True;User ID=sa;Password=12345";
			}
			else
			{
				using (StreamReader sr = File.OpenText("connect.udl"))
				{
					string input;
					while ((input = sr.ReadLine()) != null)
					{
						if (input.Contains("Data Source=") && input.Contains("Initial Catalog="))
						{
							result = input.Replace("Provider=SQLOLEDB.1;", "");
							return result;
						}
					}
					result = "Data Source=localhost;Initial Catalog=PPS;Persist Security Info=True;User ID=sa;Password=12345";
				}
			}
			return result;
		}

		public static SqlConnection GetConnection()
		{
			SqlConnection connection;
			if (DataBaseClass.Connection != null)
			{
				if (DataBaseClass.Connection.State == ConnectionState.Open)
				{
					connection = DataBaseClass.Connection;
				}
				else
				{
					DataBaseClass.Connection.Open();
					connection = DataBaseClass.Connection;
				}
			}
			else
			{
				try
				{
					DataBaseClass.Connection = new SqlConnection(DataBaseClass.GetConnectionString());
					DataBaseClass.Connection.Open();
					connection = DataBaseClass.Connection;
				}
				catch
				{
					throw new Exception("Строка подключения к БД SQL неверна или отсутствует связь с БД SQL!");
				}
			}
			return connection;
		}

		public static int ExecuteNonQuery(string procedureName, SqlParameter[] parameters)
		{
			SqlCommand command = new SqlCommand(procedureName, DataBaseClass.GetConnection());
			command.CommandType = CommandType.StoredProcedure;
			if (parameters != null)
			{
				for (int i = 0; i < parameters.Length; i++)
				{
					SqlParameter parameter = parameters[i];
					command.Parameters.Add(parameter);
				}
			}
			return command.ExecuteNonQuery();
		}

		public static SqlDataReader ExecuteReader(string procedureName, SqlParameter[] parameters)
		{
			SqlCommand command = new SqlCommand(procedureName, DataBaseClass.GetConnection());
			command.CommandType = CommandType.StoredProcedure;
			if (parameters != null)
			{
				for (int i = 0; i < parameters.Length; i++)
				{
					SqlParameter parameter = parameters[i];
					command.Parameters.Add(parameter);
				}
			}
			return command.ExecuteReader(CommandBehavior.CloseConnection);
		}

		public static int ExecuteScript(string aScript)
		{
			return new SqlCommand(aScript, DataBaseClass.GetConnection())
			{
				CommandType = CommandType.Text
			}.ExecuteNonQuery();
		}

		public static List<PreparationGroup> med_PreparationGroupSelect()
		{
			SqlDataReader reader = DataBaseClass.ExecuteReader("med_PreparationGroupSelect", null);
			List<PreparationGroup> list = new List<PreparationGroup>();
			int i = 0;
			while (reader.Read())
			{
				PreparationGroup PreparationGroup = new PreparationGroup((int)reader["ID"], i, reader["Name"].ToString(), null);
				byte[] buffer = new byte[reader.GetBytes(2, 0L, null, 0, 2147483647)];
				reader.GetBytes(2, 0L, buffer, 0, 2147483647);
				MemoryStream stream = new MemoryStream(buffer);
				PreparationGroup.BitImage = new BitmapImage();
				PreparationGroup.BitImage.CacheOption = BitmapCacheOption.OnLoad;
				PreparationGroup.BitImage.BeginInit();
				PreparationGroup.BitImage.StreamSource = stream;
				PreparationGroup.BitImage.EndInit();
				list.Add(PreparationGroup);
				i++;
			}
			reader.Close();
			return list;
		}

		public static List<Preparation> med_PreparationSelect(int GroupID)
		{
			SqlDataReader reader = DataBaseClass.ExecuteReader("med_PreparationSelect", new SqlParameter[]
			{
				new SqlParameter("@GroupID", GroupID)
			});
			List<Preparation> list2 = new List<Preparation>();
			int i = 0;
			while (reader.Read())
			{
				Preparation Preparations = new Preparation((int)reader["ID"], i, reader["Name"].ToString(), null, reader["Desription"].ToString());
				byte[] buffer = new byte[reader.GetBytes(3, 0L, null, 0, 2147483647)];
				reader.GetBytes(3, 0L, buffer, 0, 2147483647);
				MemoryStream stream = new MemoryStream(buffer);
				Preparations.BitImage = new BitmapImage();
				Preparations.BitImage.CacheOption = BitmapCacheOption.OnLoad;
				Preparations.BitImage.BeginInit();
				Preparations.BitImage.StreamSource = stream;
				Preparations.BitImage.EndInit();
				list2.Add(Preparations);
				i++;
			}
			reader.Close();
			return list2;
		}
	}
}
