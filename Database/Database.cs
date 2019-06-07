﻿using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;
using Models.Enums;

namespace Databases
{
    public class Database
    {
        private static MySqlConnection conn;
        private MySqlCommand cmd;
        private MySqlDataReader reader;

        public static void SetConnectionString(string connectionstring)
        {
            conn = new MySqlConnection(connectionstring);
        }

        public DataTable ExecuteQuery(string sql)
        {
            conn.Open();
            cmd = new MySqlCommand(sql, conn);
            DataTable dt = new DataTable();

            try
            {
                reader = cmd.ExecuteReader();
                dt.Load(reader);
                reader.Close();
                reader.Dispose();
            }
            catch
            {
                dt = null;
            }
            
            cmd.Dispose();
            conn.Close();
            conn.Dispose();
            return dt;
        }

        public DataTable ExecuteQuery(string sql, List<MySqlParameter> parameters = null)
        {
            conn.Open();

            cmd = new MySqlCommand(sql, conn);

            foreach (MySqlParameter p in parameters)
            {
                cmd.Parameters.Add(p);
            }

            DataTable dt = new DataTable();

            try
            {
                reader = cmd.ExecuteReader();
                dt.Load(reader);
                reader.Close();
                reader.Dispose();
            }
            catch
            {
                dt = null;
            }

            cmd.Dispose();
            conn.Close();
            conn.Dispose();
            return dt;
        }

        public DataTable ExecuteQuery(string sql, MySqlParameter parameter = null)
        {
            conn.Open();
            cmd = new MySqlCommand(sql, conn);

            if (parameter != null)
            {
                cmd.Parameters.Add(parameter);
            }

            DataTable dt = new DataTable();

            try
            {
                reader = cmd.ExecuteReader();
                dt.Load(reader);
                reader.Close();
                reader.Dispose();
            }
            catch
            {
                dt = null;
            }

            cmd.Dispose();
            conn.Close();
            conn.Dispose();
            return dt;
        }

        public ExecuteQueryStatus ExecuteQueryWithStatus(string sql, List<MySqlParameter> parameters = null)
        {
            conn.Open();
            cmd = new MySqlCommand(sql, conn);

            foreach (MySqlParameter p in parameters)
            {
                cmd.Parameters.Add(p);
            }

            ExecuteQueryStatus status = ExecuteQueryStatus.OK;

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch
            {
                status = ExecuteQueryStatus.Error;
            }

            cmd.Dispose();
            conn.Close();
            conn.Dispose();
            return status;
        }

        public ExecuteQueryStatus ExecuteQueryWithStatus(string sql, MySqlParameter p = null)
        {
            conn.Open();
            cmd = new MySqlCommand(sql, conn);

            if (p != null)
            {
                cmd.Parameters.Add(p);
            }

            ExecuteQueryStatus status = ExecuteQueryStatus.OK;

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch
            {
                status = ExecuteQueryStatus.Error;
            }
            
            cmd.Dispose();
            conn.Close();
            conn.Dispose();
            return status;
        }

        public ExecuteQueryStatus ExecuteStoredProcedure(string procedureName)
        {
            conn.Open();
            cmd = new MySqlCommand(procedureName, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            ExecuteQueryStatus status = ExecuteQueryStatus.OK;

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch
            {
                status = ExecuteQueryStatus.Error;
            }

            cmd.Dispose();
            conn.Close();
            conn.Dispose();
            return status;
        }

        public ExecuteQueryStatus ExecuteStoredProcedure(string procedureName, MySqlParameter parameter = null)
        {
            conn.Open();
            cmd = new MySqlCommand(procedureName, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(parameter);

            ExecuteQueryStatus status = ExecuteQueryStatus.OK;

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch
            {
                status = ExecuteQueryStatus.Error;
            }

            cmd.Dispose();
            conn.Close();
            conn.Dispose();
            return status;
        }

        public ExecuteQueryStatus ExecuteStoredProcedure(string procedureName, List<MySqlParameter> parameters = null)
        {
            conn.Open();
            cmd = new MySqlCommand(procedureName, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            foreach (MySqlParameter p in parameters)
            {
                cmd.Parameters.Add(p);
            }

            ExecuteQueryStatus status = ExecuteQueryStatus.OK;

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch
            {
                status = ExecuteQueryStatus.Error;
            }

            cmd.Dispose();
            conn.Close();
            conn.Dispose();
            return status;
        }

        public int ExecuteStoredProcedureWithOutput(string procedureName, MySqlParameter parameter = null)
        {
            conn.Open();
            cmd = new MySqlCommand(procedureName, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(parameter);

            int id = 0;

            try
            {
                cmd.ExecuteNonQuery();
                id = (int)cmd.Parameters["pOutId"].Value;
            }
            catch
            {
                id = 0;
            }

            cmd.Dispose();
            conn.Close();
            conn.Dispose();
            return id;
        }

        public int ExecuteStoredProcedureWithOutput(string procedureName, List<MySqlParameter> parameters = null)
        {
            conn.Open();
            cmd = new MySqlCommand(procedureName, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            foreach (MySqlParameter p in parameters)
            {
                cmd.Parameters.Add(p);
            }

            int id = 0;

            try
            {
                cmd.ExecuteNonQuery();
                id = (int)cmd.Parameters["pOutId"].Value;
            }
            catch
            {
                id = 0;
            }

            cmd.Dispose();
            conn.Close();
            conn.Dispose();
            return id;
        }
    }
}
