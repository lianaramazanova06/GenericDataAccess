using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp36
{
    public static class GenericUtils
    {
        public static object GetPropValue(object src, string propName)
        {
            return src.GetType().GetProperty(propName).GetValue(src, null);
        }

        public static List<string> GetProps(Type type)
        {
            List<string> list = new List<string>();

            PropertyInfo[] myPropertyInfo = null;

            // Get the properties of 'Type' class object.
            //myPropertyInfo = Type.GetType("System.Type").GetProperties();

            myPropertyInfo = type.GetProperties();

            //myPropertyInfo = typeof(Employee).GetProperties();
            //myPropertyInfo = typeof(SqlConnection).GetProperties();

            //Console.WriteLine("Properties of System.Type are:");

            for (int i = 0; i < myPropertyInfo.Length; i++)
            {
                //Console.WriteLine(myPropertyInfo[i].ToString());
                //Console.WriteLine(myPropertyInfo[i].Name);
                list.Add(myPropertyInfo[i].Name);
            }

            return list;
        }

        public  static List<string> GetProps(object o)
        {
            List<string> list = new List<string>();

            PropertyInfo[] myPropertyInfo = null;

            // Get the properties of 'Type' class object.
            //myPropertyInfo = Type.GetType("System.Type").GetProperties();

            myPropertyInfo = o.GetType().GetProperties();

            //myPropertyInfo = typeof(Employee).GetProperties();
            //myPropertyInfo = typeof(SqlConnection).GetProperties();

            //Console.WriteLine("Properties of System.Type are:");

            for (int i = 0; i < myPropertyInfo.Length; i++)
            {
                //Console.WriteLine(myPropertyInfo[i].ToString());
                //Console.WriteLine(myPropertyInfo[i].Name);
                list.Add(myPropertyInfo[i].Name);
            }

            return list;
        }
    }
}
