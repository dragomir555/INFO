using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autopraonica_Markus
{
    class Baza
    {

        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;
        public string  getData()
        {
            MySqlConnection conn = new MySqlConnection(myconnstrng);
            conn.Open();
            string query = "select * from autopraonica";
            MySqlCommand command = new MySqlCommand(query,conn);
            //    MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine(reader[1]);
            }
            return "Drago";
        }
       // MySqlConnection conn=new MySqlConnection(connstrng);
    }
}
