using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration.Json;
using System.Data;
using Microsoft.Extensions.Configuration;

namespace HotelManagementSystem.Data.Repository
{
    class HotelDbContext
    {

        public IDbConnection GetConnection()
        {
            string con = new ConfigurationBuilder().AddJsonFile("appSettings.json").Build().GetConnectionString("HotelDB");
            return new SqlConnection(con);
        }
    }
}
