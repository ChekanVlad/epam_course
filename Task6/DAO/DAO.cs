using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Reflection;

namespace DAOClasses
{
    public abstract class DAO<T> : IDAO<T>
    {
        private string connectionString;

        public DAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Create(T t)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                Type type = t.GetType();
                PropertyInfo[] fields = type.GetProperties();
                string table = type.Name + "s";

                conn.Open();

                string values = "";
                string columns = "";

                MySqlCommand command = new MySqlCommand();

                foreach (PropertyInfo field in fields)
                {
                    if (!field.CanWrite || field.Name == "Id")
                        continue;

                    columns += field.Name + ", ";
                    values += "@" + field.Name + ", ";

                    command.Parameters.AddWithValue("@" + field.Name, field.GetValue(t));
                }

                values = values.Substring(0, values.Length - 2);
                columns = columns.Substring(0, columns.Length - 2);

                string query = $"INSERT INTO {table} ({columns}) VALUES ({values})";

                command.Connection = conn;
                command.CommandText = query;
                command.ExecuteNonQuery();

                //return (answer > 0) ? true : false;
            }
        }

        public void Delete(int id)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                Type type = typeof(T);
                string table = type.Name + "s";

                conn.Open();

                string query = $"DELETE FROM {table} WHERE id=@id";

                MySqlCommand command = new MySqlCommand(query, conn);
                command.Parameters.AddWithValue("@id", id);

                command.ExecuteNonQuery();

                //return (answer > 0) ? true : false;
            }
        }

        public T Read(int id)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                Type type = typeof(T);
                PropertyInfo[] fields = type.GetProperties();
                string table = type.Name + "s";

                conn.Open();

                string query = $"SELECT * FROM {table} WHERE id=@id";

                MySqlCommand command = new MySqlCommand(query, conn);
                command.Parameters.AddWithValue("@id", id);

                MySqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    object[] par = new object[reader.FieldCount];

                    while (reader.Read())
                    {
                        if (reader.FieldCount != fields.Length)
                        {
                            throw new Exception("The number of type parameters and reader do not match.");
                        }

                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            par[i] = reader.GetValue(i);
                        }
                    }
                    return GetObject(par);
                }
                else
                {
                    throw new ArgumentException("Id not found.");
                }
            }
        }
        public List<T> ReadAll()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                Type type = typeof(T);
                PropertyInfo[] fields = type.GetProperties();
                string table = type.Name + "s";

                conn.Open();

                string query = $"SELECT * FROM {table}";

                MySqlCommand command = new MySqlCommand(query, conn);

                MySqlDataReader reader = command.ExecuteReader();

                List<T> list = new List<T>();
                if (reader.HasRows)
                {
                    object[] par = new object[reader.FieldCount];

                    while (reader.Read())
                    {
                        if (reader.FieldCount != fields.Length)
                        {
                            throw new Exception("The number of type parameters and reader do not match.");
                        }

                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            par[i] = reader.GetValue(i);
                        }
                        list.Add(GetObject(par));
                        Array.Clear(par, 0, reader.FieldCount);
                    }
                    return list;
                }
                else
                {
                    throw new ArgumentException("Id not found.");
                }
            }
        }

        public void Update(T obj, int id)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                Type type = obj.GetType();
                PropertyInfo[] fields = type.GetProperties();
                string table = type.Name + "s";

                conn.Open();

                MySqlCommand command = new MySqlCommand();

                string values = "";

                foreach (PropertyInfo field in fields)
                {
                    if (!field.CanWrite || field.Name == "Id")
                        continue;

                    values += values == "" ? field.Name + "=@" + field.Name : "," + field.Name + "=@" + field.Name;

                    command.Parameters.AddWithValue("@" + field.Name, field.GetValue(obj));
                }

                string query = $"UPDATE {table} SET {values} WHERE id=@id";

                command.Connection = conn;
                command.CommandText = query;
                command.Parameters.AddWithValue("@id", id);

                command.ExecuteNonQuery();

                //return (answer > 0) ? true : false;
            }
        }

        private T GetObject(params object[] args)
        {
            return (T)Activator.CreateInstance(typeof(T), args);
        }
    }
}
