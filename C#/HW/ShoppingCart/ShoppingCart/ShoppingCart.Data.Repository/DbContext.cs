using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Data.Repository
{
    public class DbContext
    {
        public IDbConnection GetConnection()
        {
            string con = new ConfigurationBuilder().AddJsonFile("appSettings.json").Build().GetConnectionString("ShoppingDb");
            return new SqlConnection(con);
        }
    }
}
