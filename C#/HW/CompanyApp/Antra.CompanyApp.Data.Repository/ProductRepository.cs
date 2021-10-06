using Antra.CompanyApp.Data.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antra.CompanyApp.Data.Repository
{
    public class ProductRepository : IRepository<Products>
    {
        DbContext db;
        public ProductRepository()
        {
            db = new DbContext();
        }
        public int Delete(int id)
        {
            string cmd = "Delete from Products where ID = @id";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@id", id);
            return db.Execute(cmd, parameters);
        }

        public IEnumerable<Products> GetAll()
        {
            List<Products> lst = new List<Products>();
            DataTable dt = db.Query("Select ID, Name, Unit_Price from Products", null);
            if (dt != null)
            {
                foreach (DataRow dataRow in dt.Rows)
                {
                    Products p = new Products();
                    p.ProductID = Convert.ToInt32(dataRow["ID"]);
                    p.ProductName = Convert.ToString(dataRow["Name"]);
                    p.UnitPrice = Convert.ToDecimal(dataRow["Unit_Price"]);
                    lst.Add(p);
                }
            }
            return lst;
        }

        public int Insert(Products item)
        {
            string cmd = "Insert into Products values (@pname, @uprice)";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@pname", item.ProductName);
            parameters.Add("@uprice", item.UnitPrice);
            return db.Execute(cmd, parameters);
        }

        public int Update(Products item)
        {
            string cmd = "Update Products set Name = @pname, Unit_Price = @uprice where ID = @id)";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@pname", item.ProductName);
            parameters.Add("@uprice", item.UnitPrice);
            parameters.Add("@id", item.ProductID);
            return db.Execute(cmd, parameters);
        }

        public Products GetById(int id)
        {
            Dictionary<string, object> parameter = new Dictionary<string, object>();
            parameter.Add("@id", id);
            DataTable dt = db.Query("select ID, Name, Unit_Price from Products where ID = @id", parameter);
            if (dt != null && dt.Rows.Count > 0 )
            {
                Products p = new Products();
                DataRow dr = dt.Rows[0];
                p.ProductID = Convert.ToInt32(dr["ID"]);
                p.ProductName = Convert.ToString(dr["Name"]);
                p.UnitPrice = Convert.ToDecimal(dr["Unit_Price"]);
                return p;
            }
            return null;
        }
    }
}
