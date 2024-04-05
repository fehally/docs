using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NatyBeautyModel.Utils
{
    public static class ObjectsGenerator
    {
        /// <summary>
        /// Create object based on the received type T.
        /// </summary>
        /// <typeparam name="T">Type of object to be created, can be any type of Model.</typeparam>
        /// <param name="row">DataTable row to be read and fill properties of the object T.</param>
        /// <returns>T object, can be any type of Model.</returns>
        public static T CreateObject<T>(DataRow row) where T : new()
        {
            try
            {
                T t = new T();

                foreach (var prop in t.GetType().GetProperties())
                {
                    t.GetType().GetProperty(prop.Name).SetValue(t, row[prop.Name]);
                }

                return t;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Create list of objects based on the received type T.
        /// </summary>
        /// <typeparam name="T">Type of object to be created, can be any type of Model.</typeparam>
        /// <param name="dt">DataTable to be read and fill properties of the object T.</param>
        /// <returns>List of T object, can be any type of Model.</returns>
        public static List<T> CreateObject<T>(DataTable dt) where T : new()
        {
            try
            {
                List<T> listReturn = new List<T>();

                foreach (DataRow row in dt.Rows)
                {
                    T t = new T();
                    foreach (var prop in t.GetType().GetProperties())
                    {
                        t.GetType().GetProperty(prop.Name).SetValue(t, row[prop.Name]);
                    }

                    listReturn.Add(t);
                }

                return listReturn;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
