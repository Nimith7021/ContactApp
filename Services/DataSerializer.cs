using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using UserAdminApp.Models;

namespace UserAdminApp.Services
{
    internal class DataSerializer
    {
        static string path = ConfigurationManager.AppSettings["filePath"].ToString();

        public static void Serializer(List<User> users)
        {
            using (StreamWriter sw = new StreamWriter(path, false))
            {
                sw.WriteLine(JsonSerializer.Serialize(users));
            }
        }

        public static List<User> DeSerializer()
        {
            if (!File.Exists(path))

                return new List<User>();
            using (StreamReader sr = new StreamReader(path))
            {
                List<User> users = JsonSerializer.Deserialize<List<User>>(sr.ReadToEnd())!;
                return users;
            }
        }
    }
}
