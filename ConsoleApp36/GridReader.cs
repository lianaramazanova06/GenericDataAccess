using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp36
{
    public class GridReader
    {
        public SqlDataReader Reader { get; set; }

        public List<T> Read<T>() where T : new()
        {
            List<T> list = new List<T>();

            SqlDataReader reader = Reader;

            Type typeParameterType = typeof(T);

            List<string> namesList = GenericUtils.GetProps(typeParameterType);

            while (reader.Read())
            {
                T o = new T();

                foreach (var name in namesList)
                {
                    var propertyInfo = typeParameterType.GetProperty(name);
                    propertyInfo.SetValue(o, reader[name], null);
                }

                list.Add(o);
            }

            Reader.Close();

            return list;
        }
    }
}
