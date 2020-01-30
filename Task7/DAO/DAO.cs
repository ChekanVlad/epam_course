using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Reflection;
using ORM;
using DbLinq.MySql;
using System.Linq;

namespace DAOClasses
{
    /// <summary>
    /// Class for working with tables.
    /// </summary>
    /// <typeparam name="T">Universal parameter accepting any types.</typeparam>
    public class DAO<T> : IDAO<T> where T : class, ITable
    {
        private MySqlConnection mySqlConnection;

        /// <summary>
        /// Initializes a new instance of the Dao class.
        /// </summary>
        /// <param name="connString">The connection string.</param>
        public DAO(string connString)
        {
            mySqlConnection = new MySqlConnection(connString);
        }

        /// <summary>
        /// create method
        /// </summary>
        /// <param name="t"></param>
        public void Create(T t)
        {
            using (MySqlDataContext dataContext = new MySqlDataContext(mySqlConnection))
            {
                dataContext.GetTable<T>().InsertOnSubmit(t);
                dataContext.SubmitChanges();
            }
        }

        /// <summary>
        /// delete method
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            using (MySqlDataContext dataContext = new MySqlDataContext(mySqlConnection))
            {
                T obj = dataContext.GetTable<T>().FirstOrDefault(x => x.Id == id);
                dataContext.GetTable<T>().DeleteOnSubmit(obj);
                dataContext.SubmitChanges();
            }
        }

        /// <summary>
        /// read method
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T Read(int id)
        {
            using (MySqlDataContext dataContext = new MySqlDataContext(mySqlConnection))
            {
                return dataContext.GetTable<T>().FirstOrDefault(x => x.Id == id);
            }
        }

        /// <summary>
        /// read all method
        /// </summary>
        /// <returns></returns>
        public List<T> ReadAll()
        {
            using (MySqlDataContext dataContext = new MySqlDataContext(mySqlConnection))
            {
                return dataContext.GetTable<T>().ToList();
            }
        }

        /// <summary>
        /// update method
        /// </summary>
        /// <param name="t"></param>
        /// <param name="id"></param>
        public void Update(T t, int id)
        {
            using (MySqlDataContext dataContext = new MySqlDataContext(mySqlConnection))
            {
                T oldObj = dataContext.GetTable<T>().FirstOrDefault(x => x.Id == id);
                Type type = typeof(T);
                PropertyInfo[] fields = type.GetProperties();
                foreach (PropertyInfo field in fields)
                {
                    if (!field.CanWrite || field.Name == "Id")
                        continue;
                    type.GetProperty(field.Name).SetValue(oldObj, type.GetProperty(field.Name).GetValue(t));
                }
                dataContext.SubmitChanges();
            }
        }
    }
}
