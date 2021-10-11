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
    public class OrderDetailRepository:IRepository<OrderDetail>
    {
        DbContext db;
        public OrderDetailRepository()
        {
            db = new DbContext();
        }

        public int Delete(int id)
        {
            using (IDbConnection conn = db.GetConnection())
            {
                try
                {
                    return conn.Execute("Delete from OrderDetails where ID = @ID", new { ID = id });
                }
                catch (Exception)
                {

                    Console.WriteLine("There Is A SQL Constraint Violation In Your Deletion.");
                    return 0;
                }
            }
        }

        public IEnumerable<OrderDetail> GetAll()
        {
            using (IDbConnection conn = db.GetConnection())
            {
                try
                {
                    return conn.Query<OrderDetail>("Select ID, OrderID, ProductID, Quantity, UnitPrice from OrderDetails");
                }
                catch (Exception)
                {

                    return null;
                }
            }
        }

        public OrderDetail GetById(int id)
        {
            using (IDbConnection conn = db.GetConnection())
            {
                try
                {
                    return conn.QueryFirstOrDefault<OrderDetail>("Select ID, OrderID, ProductID, Quantity, UnitPrice from OrderDetails where ID = @ID", new { ID = id});

                }
                catch (Exception)
                {

                    return null;
                }
            }
        }


        public int Insert(OrderDetail item)
        {
            using (IDbConnection conn = db.GetConnection())
            {
                try
                {
                    return conn.Execute("Insert into OrderDetails values (@OrderID, @ProductID, @Quantity, @UnitPrice)", item);

                }
                catch (Exception)
                {
                    Console.WriteLine("There Is A SQL Constraint Violation In Your Insertion.");
                    return 0;
                }
            }
        }

        public int Update(OrderDetail item)
        {
            using (IDbConnection conn = db.GetConnection())
            {
                try
                {
                    return conn.Execute("Update OrderDetails set OrderID = @OrderID, ProductID = @ProductID, Quantity = @Quantity, UnitPrice = @UnitPrice from OrderDetails where ID = @ID", item);
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
