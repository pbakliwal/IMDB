using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace IMDB.DataAccess
{
    public class Access
    {
        private readonly IConfiguration configuration;
        public Access()
        {
            configuration =  new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();
        }

        public bool InsertObject(object Obj)
        {
            Type t = Obj.GetType();   //Finding the type or class of Object received
            PropertyInfo[] props = t.GetProperties(); //getting name of properties specifoed in model

            //getting name of respective db

            bool msg;
           
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = configuration.GetConnectionString("IMDBCon");
                con.Open();
                using (SqlCommand cmd = new SqlCommand("sp_" + nameof(InsertObject) + t.Name, con))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    foreach (var prop in props)
                    {
                        if (prop.GetValue(Obj) != null)// since created date is not accepted in parameter from here, so skiping createdDate similalry others
                        {
                        string attributName = "@" + prop.Name;
                        cmd.Parameters.AddWithValue(attributName, prop.GetValue(Obj));
                        }
                    }
                    int g = cmd.ExecuteNonQuery();
                    if (g > 0)//checking if query execued without any error
                        msg = true;
                    else
                        msg = false;
                }
                con.Close();
                return msg;
            }
        }

        public List<T> GetAllData<T>() where T : class, new()
        {
            List<T> lst = new List<T>();//creating list of specified generic objects
            Type t = typeof(T);
            PropertyInfo[] props = t.GetProperties();//getting all properties of specified generic objects
            

            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = configuration.GetConnectionString("IMDBCon");
                con.Open();
                using (SqlCommand cmd = new SqlCommand("sp_" + nameof(GetAllData), con))//getting required stored procedure
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TableName", t.Name);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            object[] Obj = new object[props.Length];//getting the values of a row into object type array
                            reader.GetValues(Obj);
                            T newT = new T();//declaring generic object
                            for (int i = 0; i < props.Length; i++)
                            {
                                props[i].SetValue(newT, Obj[i]);//initializing all the propety of generic object
                            }
                            lst.Add(newT);//adding generic object to list

                        }
                    }
                }
                return lst;
            }
        }

        public List<T> GetObjectByParam<T>(string key,string Value, string tabName= "") where T : class, new()
        {
            List<T> lst = new List<T>();//creating list of specified generic objects
            Type t = typeof(T);
            PropertyInfo[] props = t.GetProperties();//getting all properties of specified generic objects
            tabName = tabName==""?t.Name:tabName;

            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = configuration.GetConnectionString("IMDBCon");
                con.Open();
                using (SqlCommand cmd = new SqlCommand("sp_" + nameof(GetObjectByParam), con))//getting required stored procedure
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TableName", tabName);
                    cmd.Parameters.AddWithValue("@SearchCol", key);
                    cmd.Parameters.AddWithValue("@SearchValue",Value);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            object[] Obj = new object[props.Length];//getting the values of a row into object type array
                            reader.GetValues(Obj);
                            T newT = new T();//declaring generic object
                            for (int i = 0; i < props.Length; i++)
                            {
                                props[i].SetValue(newT, Obj[i]);//initializing all the propety of generic object
                            }
                            lst.Add(newT);//adding generic object to list

                        }
                    }
                }
                return lst;
            }
        }

        public string UpdateObject(object Obj)
        {
            Type t = Obj.GetType();
            PropertyInfo[] props = t.GetProperties();

            string msg;
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = configuration.GetConnectionString("IMDBCon");
                con.Open();
                using (SqlCommand cmd = new SqlCommand("sp_" + nameof(UpdateObject) + t.Name, con))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    foreach (var prop in props)
                    {
                        if (prop.GetValue(Obj) != null)// since created date is not accepted in parameter from here, so skiping createdDate
                        {
                        string attributName = "@" + prop.Name;
                        cmd.Parameters.AddWithValue(attributName, prop.GetValue(Obj));
                        }
                    }
                    try
                    {
                    int g = cmd.ExecuteNonQuery();
                        if (g > 0)
                        {
                            msg = "Success";
                        }
                        else
                        {
                            msg = "Error";
                        }
                    }
                    catch (Exception ex)
                    {
                        msg = ex.Message;
                    }
                }
                con.Close();
                return msg;
            }
        }

        public bool DeleteObjectByID<T>(int ID) where T : class, new()
        {
            Type t = typeof(T);
            bool msg;
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = configuration.GetConnectionString("IMDBCon");
                con.Open();
                using (SqlCommand cmd = new SqlCommand("sp_"+nameof(DeleteObjectByID), con))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TableName", t.Name);
                    cmd.Parameters.AddWithValue("@ID", ID);

                    int g = cmd.ExecuteNonQuery();
                    if (g > 0)//checking if query execued without any error
                        msg = true;
                    else
                        msg = false;
                }
                con.Close();
                return msg;
            }
        }
        public bool DeleteMovieLisT(int ID)
        {
            bool msg;
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = configuration.GetConnectionString("IMDBCon");
                con.Open();
                using (SqlCommand cmd = new SqlCommand("Sp_DeleteMovieList", con))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", ID);

                    int g = cmd.ExecuteNonQuery();
                    if (g > 0)//checking if query execued without any error
                        msg = true;
                    else
                        msg = false;
                }
                con.Close();
                return msg;
            }
        }


    }
}
