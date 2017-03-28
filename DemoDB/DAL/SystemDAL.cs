﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DemoDB.DAL
{
    class SystemDAL
    {
        public Boolean executeNonQuerys(string quary)
        {
            Boolean flag = false;
            SqlConnection con = null;
            SqlCommand com = null;
            try
            {
                con = new SqlConnection(DBEstablish.makeConnection());
                con.Open();
                com = new SqlCommand(quary, con);
                com.ExecuteNonQuery();
                flag = true;

            }
            catch (Exception ex)
            {
                Console.WriteLine("{0}" + ex.Message);
                flag = false;

            }
            finally
            {
                com.Dispose();
                con.Close();
            }
            return flag;
        }
        public SqlDataReader executeQuerys(string quary)
        {
            SqlConnection con = null;
            SqlCommand com = null;
            try
            {
                con = new SqlConnection(DBEstablish.makeConnection());
                con.Open();
                com = new SqlCommand(quary, con);
                return com.ExecuteReader(CommandBehavior.CloseConnection);


            }
            catch (SqlException ex)
            {
                if (com != null)
                {
                    com.Dispose();
                }
                if (con != null)
                {
                    con.Close();
                }
                Console.WriteLine(ex.Message);

                throw;
            }
            catch
            {
                if (com != null)
                {
                    com.Dispose();
                }
                if (con != null)
                {
                    con.Close();
                }
                throw;
            }
            finally
            {
                if (com != null)
                {
                    com.Dispose();
                }
            }

        }

        public Boolean IsServerConnected(string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(DBEstablish.makeConnection()))
            {
                try
                {
                    connection.Open();
                    return true;
                }
                catch (SqlException)
                {
                    return false;
                }
            }
        }


    }
}
