using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NetCrucdOperation
{
	internal class Program
	{
		static void Main(string[] args)
		{
			while (true)
			{
				Console.WriteLine("\nCustomer Menu:");
				Console.WriteLine("1. Add Contact");
				Console.WriteLine("2. Display Customer");
				Console.WriteLine("3. Update Customer");
				Console.WriteLine("4. Delete Customer");
				Console.WriteLine("5. Exit");
				Console.Write("Enter your choice: ");

				int choice;
				if (int.TryParse(Console.ReadLine(), out choice))
				{
					switch (choice)
					{
						case 1:
							Customer cs1 = new Customer();
							cs1.insertCustomer();
						break;
						case 2:
							Customer cs2 = new Customer();
							cs2.fetchData();
						 break;
						case 3:
                            Customer cs3 = new Customer();
							cs3.fetchData();
							cs3.updataCustomer();
					    break;
						case 4:
							Customer cs4 = new Customer();
							cs4.deleteCust();
						break;
						case 5:
							Console.WriteLine("Exiting program. Goodbye!");
							return;

						default:
							Console.WriteLine("Invalid choice. Please enter a valid option.");
							break;
					}
				}
				else
				{
					Console.WriteLine("Invalid input. Please enter a number.");
				}

			}
		}
	}
}

