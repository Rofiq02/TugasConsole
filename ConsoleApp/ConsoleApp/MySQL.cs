using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;

namespace ConsoleApp
{
    class MySQL
    {
        MySqlConnection koneksi;

        public MySQL()
        {
            string koneksiString = "Server=127.0.0.1;user=root;password;database=dtsekolah";
            koneksi = new MySqlConnection(koneksiString);
            koneksi.Open();
        }

        //insert update and delete
        public void Execute(string query, Dictionary<string, dynamic> data = null)
        {
            MySqlCommand cmd = new MySqlCommand(query, koneksi);
            if (data != null)
            {
                foreach (string key in data.Keys)
                {
                    cmd.Parameters.AddWithValue(key, data[key]);
                }
            }
            cmd.ExecuteNonQuery();

        }

        //select 
        public DataTable GetData(string Query, Dictionary<string, dynamic> data = null)
        {
            MySqlCommand cmd = new MySqlCommand(Query, koneksi);
            if (data != null)
            {
                foreach (string key in data.Keys)
                {
                    cmd.Parameters.AddWithValue(key, data[key]);
                }
            }
            MySqlDataReader reader = cmd.ExecuteReader();

            DataTable result = new DataTable();
            result.Load(reader);

            return result;
        }
        ~MySQL()
        {
            koneksi.Close();
        }
    }
}
