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
    public class OrderRepository : IRepository<Order>
    {
        DbContext db;
        public OrderRepository()
        {
            db = new DbContext();
        }

        public int Delete(int id)
        {
            using (IDbConnection conn = db.GetConnection())
            {
                try
                {
                    return conn.Execute("Delete from Orders where ID = @ID", new { ID = id });
                }
                catch (Exception)
                {

                    Console.WriteLine("There Is A SQL Constraint Violation In Your Deletion.");
                    return 0;
                }
            }
        }

        public IEnumerable<Order> GetAll()
        {
            using (IDbConnection conn = db.GetConnection())
            {
                try
                {
                    return conn.Query<Order>("Select ID, OrderDate from Orders");
                }
                catch (Exception)
                {

                    return null;
                }
            }
        }

        public Order GetById(int id)
        {
            using (IDbConnection conn = db.GetConnection())
            {
                try
                {
                    return conn.QueryFirstOrDefault<Order>("Select ID, OrderDate from Orders where ID = @ID", new { ID = id });

                }
                catch (Exception)
                {

                    return null;
                }
            }
        }

        public int Insert(Order item)
        {
            using (IDbConnection conn = db.GetConnection())
            {
                try
                {
                    return conn.Execute("Insert into Orders values (@OrderDate)", item);

                }
                catch (Exception)
                {
                    Console.WriteLine("There Is A SQL Constraint Violation In Your Insertion.");
                    return 0;
                }
            }
        }

        public int Update(Order item)
        {
            using (IDbConnection conn = db.GetConnection())
            {
                try
                {
                    return conn.Execute("Update Orders set ID = @ID, OrderDate = @OrderDate where ID = @ID", item);
                }
                catch (Exception)
                {

                    Console.WriteLine("There Is A SQL Constraint Violation In Your Update.");
                    return 0;
                }
            }
        }
    }
}
