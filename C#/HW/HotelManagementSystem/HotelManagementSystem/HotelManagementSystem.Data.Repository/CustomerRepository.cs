using Dapper;
using HotelManagementSystem.Data.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.Data.Repository
{
    public class CustomerRepository : IRepositoryAsync<Customer>, IRepository<Customer>
    {
        HotelDbContext db;
        public CustomerRepository()
        {
            db = new HotelDbContext();
        }

        public int Delete(int id)
        {
            using (IDbConnection conn = db.GetConnection())
            {
                try
                {
                    return conn.Execute("Delete from Customers where ID = @ID", new { ID = id });
                }
                catch (Exception)
                {

                    Console.WriteLine("There Is A SQL Constraint Violation In Your Deletion.");
                    return 0;
                }
            }
        }

        public async Task<int> DeleteAsync(int id)
        {
            using (IDbConnection conn = db.GetConnection())
            {
                try
                {
                    return await conn.ExecuteAsync("Delete from Customers where ID = @ID", new { ID = id });
                }
                catch (Exception)
                {

                    Console.WriteLine("There Is A SQL Constraint Violation In Your Deletion.");
                    return 0;
                }
            }
        }

        public IEnumerable<Customer> GetAll()
        {
            using (IDbConnection conn = db.GetConnection())
            {
                try
                {
                    return conn.Query<Customer>("Select ID, RoomNo, CName, Address, Phone, Email, CheckIn, TotalPersons, BookingDays, Advance from Customers");
                }
                catch (Exception)
                {

                    return null;
                }
            }
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            using (IDbConnection conn = db.GetConnection())
            {
                try
                {
                    return await conn.QueryAsync<Customer>("Select ID, RoomNo, CName, Address, Phone, Email, CheckIn, TotalPersons, BookingDays, Advance from Customers");
                }
                catch (Exception)
                {

                    return null;
                }
            }
        }

        public Customer GetById(int id)
        {
            using (IDbConnection conn = db.GetConnection())
            {
                try
                {
                    return conn.QueryFirstOrDefault<Customer>("Select ID, RoomNo, CName, Address, Phone, Email, CheckIn, TotalPersons, BookingDays, Advance from Customers where ID = @ID", new { ID = id });

                }
                catch (Exception)
                {

                    return null;
                }
            }
        }

        public async Task<Customer> GetByIdAsync(int id)
        {
            using (IDbConnection conn = db.GetConnection())
            {
                try
                {
                    return await conn.QueryFirstOrDefaultAsync<Customer>("Select ID, RoomNo, CName, Address, Phone, Email, CheckIn, TotalPersons, BookingDays, Advance from Customers where ID = @ID", new { ID = id });

                }
                catch (Exception)
                {

                    return null;
                }
            }
        }

        public int Insert(Customer item)
        {
            using (IDbConnection conn = db.GetConnection())
            {
                try
                {
                    return conn.Execute("Insert into Customers values (@RoomNo, @CName, @Address, @Phone, @Email, @CheckIn, @TotalPersons, @BookingDays, @Advance)", item);

                }
                catch (Exception)
                {
                    Console.WriteLine("There Is A SQL Constraint Violation In Your Insertion.");
                    return 0;
                }
            }
        }

        public async Task<int> InsertAsync(Customer item)
        {
            using (IDbConnection conn = db.GetConnection())
            {
                try
                {
                    return await conn.ExecuteAsync("Insert into Customers values (@RoomNo, @CName, @Address, @Phone, @Email, @CheckIn, @TotalPersons, @BookingDays, @Advance)", item);

                }
                catch (Exception)
                {

                    Console.WriteLine("There Is A SQL Constraint Violation In Your Insertion.");
                    return 0;
                }
            }
        }

        public int Update(Customer item)
        {
            using (IDbConnection conn = db.GetConnection())
            {
                try
                {
                    return conn.Execute("Update Customers set ID = @ID, RoomNo = @RoomNo, CName = @CName, Address = @Address, Phone = @Phone, " +
                    "Email = @Email, CheckIn = @CheckIn, TotalPersons = @TotalPersons, BookingDays = @BookingDays, Advance = @Advance where ID = @ID", item);
                }
                catch (Exception)
                {

                    Console.WriteLine("There Is A SQL Constraint Violation In Your Update.");
                    return 0;
                }
            }
        }

        public async Task<int> UpdateAsync(Customer item)
        {
            using (IDbConnection conn = db.GetConnection())
            {
                try
                {
                    return await conn.ExecuteAsync("Update Customers set ID = @ID, RoomNo = @RoomNo, CName = @CName, Address = @Address, Phone = @Phone, " +
                    "Email = @Email, CheckIn = @CheckIn, TotalPersons = @TotalPersons, BookingDays = @BookingDays, Advance = @Advance where ID = @ID", item);
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
