using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace DAO
{
    public class DAO<T> : IDAO<T>
    {
        private string ConnectionString { get; set; }

        public DAO(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public void Delete(int id)
        {
           using (MySqlConnection sqlConnection = new MySqlConnection(ConnectionString))
            {
                Type type = typeof(T);
                string tableName = type.Name + "s";
                PropertyInfo IdField = type.GetProperty("Id");
                string parameter = "@" + IdField.Name;
                sqlConnection.Open();
                string sqlExpression = $"DELETE FROM {tableName} WHERE Id={parameter}";
                MySqlCommand sqlCommand = new MySqlCommand(sqlExpression, sqlConnection);
                MySqlParameter idParameter = new MySqlParameter(parameter, id);
                sqlCommand.Parameters.Add(idParameter);
                sqlCommand.ExecuteNonQuery();
            }
        }

        public T Read(int id)
        {
            using (MySqlConnection sqlConnection = new MySqlConnection(ConnectionString))
            {
                Type type = typeof(T);
                string tableName = type.Name + "s";
                PropertyInfo IdField = type.GetProperty("Id");
                string parameter = "@" + IdField.Name;
                PropertyInfo[] classFields = type.GetProperties();
                sqlConnection.Open();
                string sqlExpression = $"SELECT * FROM {tableName} WHERE Id={parameter}";
                MySqlCommand sqlCommand = new MySqlCommand(sqlExpression, sqlConnection);
                MySqlParameter idParameter = new MySqlParameter(parameter, id);
                sqlCommand.Parameters.Add(idParameter);
                MySqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                if (sqlDataReader.HasRows)
                {
                    object[] par = new object[sqlDataReader.FieldCount];
                    while (sqlDataReader.Read())
                    {
                        if (sqlDataReader.FieldCount != classFields.Length)
                        {
                            throw new Exception();
                        }
                        for (int i = 0; i < sqlDataReader.FieldCount; i++)
                        {
                            par[i] = sqlDataReader.GetValue(i);
                        }
                    }
                    return GetObject(par);
                }
                else
                {
                    throw new Exception();
                }
            }
        }

        public void Update(T t)
        {
            using (MySqlConnection sqlConnection = new MySqlConnection(ConnectionString))
            {
                Type type = t.GetType();

                PropertyInfo IdField = type.GetProperty("Id");
                string parameter = "@" + IdField.Name;
                PropertyInfo[] classFields = type.GetProperties();
                string tableName = type.Name + "s";
                string resultingString = "";
                MySqlCommand sqlCommand = new MySqlCommand();
                foreach (var property in classFields)
                {
                    if (property.CanWrite == false) 
                        continue;

                    if (resultingString == "")
                    {
                        resultingString += property.Name + "=@" + property.Name;
                        MySqlParameter sqlParameter = new MySqlParameter("@" + property.Name, property.GetValue(t));
                        sqlCommand.Parameters.Add(sqlParameter);
                    }
                    else
                    {
                        resultingString += ", " + property.Name + "=@" + property.Name;
                        MySqlParameter sqlParameter = new MySqlParameter("@" + property.Name, property.GetValue(t));
                        sqlCommand.Parameters.Add(sqlParameter);
                    }
                }

                string expression = $"UPDATE {tableName} SET {resultingString} WHERE Id={parameter}";
                MySqlParameter idParameter = new MySqlParameter(parameter, IdField.GetValue(t));
                sqlCommand.Parameters.Add(idParameter);
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = expression;
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
            }
        }

        public void Create(T t)
        {
            using (MySqlConnection sqlConnection = new MySqlConnection(ConnectionString))
            {
                Type type = t.GetType();
                PropertyInfo[] classFields = type.GetProperties();

                string tableName = type.Name + "s";

                string columns = "";

                string parameters = "";

                MySqlCommand sqlCommand = new MySqlCommand();

                foreach (var property in classFields)
                {
                    if (property.CanWrite == false) continue;

                    if (columns == "")
                    {
                        columns += property.Name;
                        parameters += "@" + property.Name;

                        MySqlParameter sqlParameter = new MySqlParameter("@" + property.Name, property.GetValue(t));
                        sqlCommand.Parameters.Add(sqlParameter);
                    }
                    else
                    {
                        columns += ", " + property.Name;
                        parameters += ", " + "@" + property.Name;

                        MySqlParameter sqlParameter = new MySqlParameter("@" + property.Name, property.GetValue(t));
                        sqlCommand.Parameters.Add(sqlParameter);
                    }
                }

                string expression = $"INSERT INTO {tableName} ({columns }) VALUES ({parameters})";

                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = expression;

                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
            }
        }

        public List<T> ReadAll(T t)
        {
            using (MySqlConnection sqlConnection = new MySqlConnection(ConnectionString))
            {
                Type type = typeof(T);
                string tableName = type.Name + "s";
                PropertyInfo[] classFields = type.GetProperties();
                sqlConnection.Open();
                string sqlExpression = $"SELECT * FROM {tableName}";
                MySqlCommand sqlCommand = new MySqlCommand(sqlExpression, sqlConnection);
                MySqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                List<T> tempListT = new List<T>();
                if (sqlDataReader.HasRows)
                {
                    object[] par = new object[sqlDataReader.FieldCount];
                    while (sqlDataReader.Read())
                    {
                        if (sqlDataReader.FieldCount != classFields.Length)
                        {
                            throw new Exception();
                        }

                        for (int i = 0; i < sqlDataReader.FieldCount; i++)
                        {
                            par[i] = sqlDataReader.GetValue(i);
                        }
                        tempListT.Add(GetObject(par));
                        Array.Clear(par, 0, sqlDataReader.FieldCount);
                    }
                    return tempListT;
                }
                else
                {
                    throw new Exception();
                }
            }
        }

        protected T GetObject(params object[] args)
        {
            return (T)Activator.CreateInstance(typeof(T), args);
        }
    }
}