using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Antra.CompanyApp.Data.Repository
{
    class DbContext
    {
        public int Execute(string cmdText, Dictionary<string, object> parameters = null)
        {
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-ER90S1U\\ALAN;Initial Catalog=TestDB;Integrated Security=True");
            SqlCommand cmd = new SqlCommand();
            try
            {
                connection.Open();
                cmd.CommandText = cmdText;
                if (parameters != null)
                {
                    foreach (var item in parameters)
                    {
                        cmd.Parameters.AddWithValue(item.Key, item.Value);
                    }
                }
                cmd.Connection = connection;
                int r = cmd.ExecuteNonQuery(); //
                return r;
            }
            catch (Exception e)
            {

            }
            finally
            {
                connection.Close();
                connection.Dispose();
                cmd.Dispose();
            }
            return 0;
        }

        public DataTable Query(string cmdText, Dictionary<string, object> parameters, CommandType cmdType = CommandType.Text)
        {
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-ER90S1U/ALAN;Initial Catalog=TestDB;Integrated Security=True");
            SqlCommand cmd = new SqlCommand();
            try
            {
                connection.Open();
                cmd.CommandText = cmdText;
                if (parameters != null)
                {
                    foreach (var item in parameters)
                    {
                        cmd.Parameters.AddWithValue(item.Key, item.Value);
                    }
                }
                cmd.Connection = connection;
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                return dt;
            }
            catch (Exception e)
            {

            }
            finally
            {
                connection.Close();
                connection.Dispose();
                cmd.Dispose();
            }
            return null;
        }


    }
}
