using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using DAOClasses;
using ORM;

namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "server=localhost;user=root;database=task6;password=G8129307csgo;";
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            string query = $"INSERT INTO subjects (name) VALUES ('hellopidr')";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}