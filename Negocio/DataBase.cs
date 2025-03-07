﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
namespace Negocio
{
    public class DataBase
    {
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataReader reader;

        public DataBase()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
            conn = new SqlConnection(connectionString);
            cmd = new SqlCommand();
        }
        public SqlDataReader Reader { get { return reader; } }

        public void setQuery(string query)
        {
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = query;
        }

        public void executeQuery()
        {
            cmd.Connection = conn;
            try
            {
                conn.Open();
                reader = cmd.ExecuteReader();
            }
            catch (Exception ex)
            { 
                throw ex;
            }
        }

        public void executeNonQuery()
        {
            cmd.Connection = conn;
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void setParameter(string parametro, object value)
        {
            cmd.Parameters.AddWithValue(parametro, value);
        }

        public void closeConn()
        {
            if (reader != null)
                reader.Close();
            conn.Close();
        }
    }
}

