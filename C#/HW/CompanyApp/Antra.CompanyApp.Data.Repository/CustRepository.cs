using Antra.CompanyApp.Data.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antra.CompanyApp.Data.Repository
{
    public class CustRepository : IRepository<Customers>
    {
        DbContext db;
        public CustRepository()
        {
            db = new DbContext();
        }
        public int Delete(int id)
        {
            string cmd = "Delete from Customers where ID = @id";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@id", id);
            return db.Execute(cmd, parameters);
        }

        public IEnumerable<Customers> GetAll()
        {
            List<Customers> lst = new List<Customers>();
            DataTable dt = db.Query("Select ID, FirstName, LastName, Mobile, EmailID, City, State from Customers", null);
            if (dt != null)
            {
                foreach (DataRow dataRow in dt.Rows)
                {
                    Customers c = new Customers();
                    DataRow dr = dt.Rows[0];
                    c.ID = Convert.ToInt32(dr["ID"]);
                    c.FirstName = Convert.ToString(dr["FirstName"]);
                    c.LastName = Convert.ToString(dr["LastName"]);
                    c.Mobile = Convert.ToString(dr["Mobile"]);
                    c.EmailId = Convert.ToString(dr["EmailID"]);
                    c.City = Convert.ToString(dr["City"]);
                    c.State = Convert.ToString(dr["State"]);
                    lst.Add(c);
                }
            }
            return lst;
        }

        public Customers GetById(int id)
        {
            Dictionary<string, object> parameter = new Dictionary<string, object>();
            parameter.Add("@id", id);
            DataTable dt = db.Query("select ID, FirstName, LastName, Mobile, EmailID, City, State from Customers where ID = @id", parameter);
            if (dt != null)
            {
                Customers c = new Customers();
                DataRow dr = dt.Rows[0];
                c.ID = Convert.ToInt32(dr["ID"]);
                c.FirstName = Convert.ToString(dr["FirstName"]);
                c.LastName = Convert.ToString(dr["LastName"]);
                c.Mobile = Convert.ToString(dr["Mobile"]);
                c.EmailId = Convert.ToString(dr["EmailID"]);
                c.City = Convert.ToString(dr["City"]);
                c.State = Convert.ToString(dr["State"]);

                return c;
            }
            return null;
        }

        public int Insert(Customers item)
        {
            string cmd = "Insert into Customers values (@fname,@lname,@mobile, @email, @city, @state)";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@fname", item.FirstName);
            parameters.Add("@lname", item.LastName);
            parameters.Add("@mobile", item.Mobile);
            parameters.Add("@email", item.EmailId);
            parameters.Add("@city", item.City);
            parameters.Add("@state", item.State);
            return db.Execute(cmd, parameters);
        }

        public int Update(Customers item)
        {
            string cmd = "Update Customers set FirstName = @fname, LastName = @lname, Mobile = @mobile, EmailID = @email, City = @city, State = @state where ID = @id)";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@fname", item.FirstName);
            parameters.Add("@lname", item.LastName);
            parameters.Add("@mobile", item.Mobile);
            parameters.Add("@email", item.EmailId);
            parameters.Add("@city", item.City);
            parameters.Add("@state", item.State);
            parameters.Add("@id", item.ID);
            return db.Execute(cmd, parameters);
        }
    }
}
