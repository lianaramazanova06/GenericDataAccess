using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp36
{
    public static class LianaDapper
    {
        public static void Query(this SqlConnection connection, string query, object obj)
        {
            List<string> namesList = GenericUtils.GetProps(obj);

            foreach (var name in namesList)
            {
                string tryFind = "@" + name;

                int index = query.IndexOf(tryFind);
                if (index >= 0)
                {
                    object value = GenericUtils.GetPropValue(obj, name);
                    query = query.Replace(tryFind, value.ToString());
                }
            }

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = query;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Connection = connection;

            int recordAffected = cmd.ExecuteNonQuery();

            cmd.Dispose();
        }

        public static GridReader QueryMultiple(this SqlConnection connection, string query)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = query;

            SqlDataReader reader = cmd.ExecuteReader();

            GridReader gridReader = new GridReader
            {
                Reader = reader
            };

            return gridReader;
        }
    }
}
