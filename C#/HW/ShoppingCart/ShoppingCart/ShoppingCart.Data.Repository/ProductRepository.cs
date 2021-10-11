using Dapper;
using ShoppingCart.Data.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Data.Repository
{
    public class ProductRepository : IRepository<Product>
    {
        DbContext db;
        public ProductRepository()
        {
            db = new DbContext();
        }
        public int Delete(int id)
        {
            using (IDbConnection conn = db.GetConnection())
            {
                try
                {
                    return conn.Execute("Delete from Products where ID = @ID", new { ID = id });
                }
                catch (Exception e)
                {
                    Console.WriteLine("There Is A SQL Constraint Violation In Your Deletion.");
                    return 0;
                }
            }
        }

        public IEnumerable<Product> GetAll()
        {
            using (IDbConnection conn = db.GetConnection())
            {
                try
                {
                    return conn.Query<Product>("Select ID, ProductName, UnitPrice from Products");
                }
                catch (Exception e)
                {

                    return null;
                }
            }
        }

        public Product GetById(int id)
        {
            using (IDbConnection conn = db.GetConnection())
            {
                try
                {
                    return conn.QueryFirstOrDefault<Product>("Select ID, ProductName, UnitPrice from Products where ID = @ID", new
                    {
                        ID = id
                    });
                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }

        public int Insert(Product item)
        {
            using (IDbConnection conn = db.GetConnection())
            {
                try
                {
                    return conn.Execute("Insert into Products values (@ProductName, @UnitPrice)", item);
                }
                catch (Exception e)
                {
                    Console.WriteLine("There Is A SQL Constraint Violation In Your Insertion.");
                    return 0;
                }
            }
        }

        public int Update(Product item)
        {
            using (IDbConnection conn = db.GetConnection())
            {
                try
                {
                    return conn.Execute("Update Products set ProductName = @ProductName, UnitPrice = @UnitPrice where ID = @ID", item);
                }
                catch (Exception e)
                {
                    Console.WriteLine("There Is A SQL Constraint Violation In Your Update.");
                    return 0;
                }
            }
        }
    }
}
