using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibrary
{

    public static class CommonFunctions
    {
        public static void WriteCSV<T>(List<T> items, string path)
        {
            Type itemType = typeof(T);
            var props = itemType.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                                .OrderBy(p => p.Name);

            using (var writer = new StreamWriter(path))
            {
                // Write header row
                writer.WriteLine(string.Join(",", props.Select(p => $"\"{p.Name}\"")));

                // Write data rows
                foreach (var item in items)
                {
                    writer.WriteLine(string.Join(",", props.Select(p => $"\"{p.GetValue(item, null)}\"")));
                }
            }
        }


    }

}
