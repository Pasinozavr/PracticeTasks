using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbDemo.Properties;

namespace DbDemo
{
    public class CustomerProxy
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {

            using (var context = new TestDbContext())
            {
                var customers = context.Customers.ToList<Customer>();

                context.Customers.Add(new Customer() {CustomerName = "New Student" });

                Customer studentToUpdate = customers.Where(s => s.CustomerName == "New Student").FirstOrDefault<Customer>();
                studentToUpdate.CustomerName = "Edited student1";

                context.Customers.Remove(customers.ElementAt<Customer>(0));

                context.SaveChanges();
            }

            var cust = GetCustomersEf();
            foreach (var customer in cust)
            {
                Console.WriteLine("Id: {0}\tName: {1}", customer.CustomerId, customer.CustomerName);
            }
            Console.ReadLine();
        } 
            
        

        private static List<Customer> GetCustomersEf()
        {
            var context = new TestDbContext();

            var customers = context.Customers.ToList();
            return customers;
        }
        private static List<CustomerProxy> GetCustomers()
        {
            using (IDbConnection connection = new SqlConnection(Settings.Default.DbConnect))
            {
                IDbCommand command = new SqlCommand("SELECT * FROM t_customer");
                command.Connection = connection;

                connection.Open();

                IDataReader reader = command.ExecuteReader();
                List<CustomerProxy> customers = new List<CustomerProxy>();
                while (reader.Read())
                {
                    CustomerProxy customer = new CustomerProxy();
                    customer.Id = reader.GetInt32(0);
                    customer.Name = reader.GetString(1);

                    customers.Add(customer);
                }

                return customers;
            }
        }
    }
}
