using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Reflection;

namespace ConsoleApp36
{
    class Program
    {
        static string connString = "Data Source=localhost\\sqlexpress;Initial Catalog=GeneralStore;Integrated Security=True";

        static void Main(string[] args)
        {
            //string s = "12345";
            //string p = s.Replace("23", "Hi Lianka");

            //List<Employee> list = GetEmployeeList();
            List<Vendor> list = GetVendorList();

            /*
            Employee employee = new Employee
            {
                FirstName = "Misha",
                LastName = "Potapov",
                SSN = "000-00-0000"
            };

            SaveEmployee(employee);  
            */
        }

        static void SaveEmployee(Employee employee)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connString;
            conn.Open();

            string query = $"INSERT INTO [dbo].[Employees] ([FirstName],[LastName],[SSN]) VALUES ('@FirstName', '@FLastName', '@SSN')";
            conn.Query(query, employee);

            conn.Close();
            conn.Dispose();
        }

        static List<Vendor> GetVendorList()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connString;
            conn.Open();

            string query = $" select * from Vendors";

            GridReader gridReader = conn.QueryMultiple(query);

            List<Vendor> list = gridReader.Read<Vendor>();

            conn.Close();
            conn.Dispose();

            return list;
        }

        static List<Employee> GetEmployeeList()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connString;
            conn.Open();

            string query = $" select * from Employees";

            GridReader gridReader = conn.QueryMultiple(query);

            List<Employee> list = gridReader.Read<Employee>();

            conn.Close();
            conn.Dispose();

            return list;
        }
    }
}
