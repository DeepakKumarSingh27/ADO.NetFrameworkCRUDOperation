using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ADO.NetCrucdOperation
{
	public class Customer
	{
		public int ID { get; set; }
		public string Name { get; set; }
		public long phone { get; set; }
		public string city { get; set; }
		public string country { get; set; }
		public int salary { get; set; }
		public int pincode { get; set; }

		public static SqlConnection sqlconnection;
		string connectionString = @"Data Source=Deepak\SQLEXPRESS;Initial Catalog=Customer1;Integrated Security=True;";
		public static void connection()
		{
			string connectionString = @"Data Source=Deepak\SQLEXPRESS;Initial Catalog=Customer1;Integrated Security=True;";
			sqlconnection = new SqlConnection(connectionString);
			sqlconnection.Open();
		}

		public void insertCustomer()
		{
			connection();
			Console.WriteLine("Enter the Name:");
			string name = Console.ReadLine();
			Console.WriteLine("Enter the Phone:");
			long phone = Convert.ToInt64(Console.ReadLine());
			Console.WriteLine("Enter the city:");
			string city = Console.ReadLine();
			Console.WriteLine("Enter the country:");
			string country = Console.ReadLine();
			Console.WriteLine("Enter the salary:");
			int salary = Convert.ToInt32(Console.ReadLine());
			Console.WriteLine("Enter the pincode:");
			int pincode = Convert.ToInt32(Console.ReadLine());
			string insertQuery = "insert into Customer1 (name,phone,city,country,salary,pincode)values('" + name + "','" + phone + "','" + city + "','" + country + "','" + salary + "','" + pincode + "')";
			SqlCommand insertCommand = new SqlCommand(insertQuery, sqlconnection);
			insertCommand.ExecuteNonQuery();
			Console.WriteLine("Data is inserted successfully in Database....");
		}

		public void fetchData()
		{
			connection();
			string selectQuery = @"select * from Customer1";
			SqlCommand display = new SqlCommand(selectQuery, sqlconnection);
			SqlDataReader reader = display.ExecuteReader();
			while (reader.Read())
			{
				Console.WriteLine($"Customer ID: {reader["id"]}, Name: {reader["Name"]}, city: {reader["city"]},country:{reader["country"]},salary:{reader["salary"]},pincode:{reader["pincode"]}");
			}
			reader.Close();
		}
		public void updataCustomer()
		{
			connection();
			Console.WriteLine("Enter id you want to update the databases: ");
			int id = Convert.ToInt32(Console.ReadLine());
			Console.WriteLine("Enter the Name:");
			string name = Console.ReadLine();
			Console.WriteLine("Enter the Phone:");
			long phone = Convert.ToInt64(Console.ReadLine());
			Console.WriteLine("Enter the city:");
			string city = Console.ReadLine();
			Console.WriteLine("Enter the country:");
			string country = Console.ReadLine();
			Console.WriteLine("Enter the salary:");
			int salary = Convert.ToInt32(Console.ReadLine());
			Console.WriteLine("Enter the pincode:");
			int pincode = Convert.ToInt32(Console.ReadLine());

			// SQL update query
			string query = "UPDATE Customer1 SET name = @Name, phone = @Phone, city = @City, country = @Country, salary = @Salary, pincode = @Pincode WHERE id = @ID";

			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				using (SqlCommand command = new SqlCommand(query, connection))
				{
					// Adding parameters to prevent SQL Injection
					command.Parameters.AddWithValue("@ID", id);
					command.Parameters.AddWithValue("@Name", name);
					command.Parameters.AddWithValue("@Phone", phone);
					command.Parameters.AddWithValue("@City", city);
					command.Parameters.AddWithValue("@Country", country);
					command.Parameters.AddWithValue("@Salary", salary);
					command.Parameters.AddWithValue("@Pincode", pincode);

					try
					{
						connection.Open();
						int rowsAffected = command.ExecuteNonQuery();
						Console.WriteLine($"Rows affected: {rowsAffected}");
					}
					catch (Exception ex)
					{
						Console.WriteLine("Error: " + ex.Message);
					}
				}
			}
		}
		public void deleteCust()
		{
			connection();
			Console.WriteLine("Enter id you want to delete");
			int id = Convert.ToInt32(Console.ReadLine());
			string query = "DELETE FROM Customer1 WHERE id = @ID";
			SqlCommand command = new SqlCommand(query, sqlconnection);
			command.Parameters.AddWithValue("@ID", id);
			try
			{
				int rowsAffected = command.ExecuteNonQuery();
				Console.WriteLine($"Rows affected: {rowsAffected}");
			}
			catch (Exception ex)
			{
				Console.WriteLine("Error: " + ex.Message);
			}
		}
		
	  
	}
}

	