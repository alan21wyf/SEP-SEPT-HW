using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using HotelManagementSystem.Data.Model;

namespace HotelManagementSystem.Data.Repository
{
    public class ServiceRepository : IRepositoryAsync<Service>, IRepository<Service>
    {
        HotelDbContext db;
        public ServiceRepository()
        {
            db = new HotelDbContext();
        }

        public int Delete(int id)
        {
            using (IDbConnection conn = db.GetConnection())
            {
                try
                {
                    return conn.Execute("Delete from Services where ID = @ID", new { ID = id });

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
                    return await conn.ExecuteAsync("Delete from Services where ID = @ID", new { ID = id });

                }
                catch (Exception)
                {

                    Console.WriteLine("There Is A SQL Constraint Violation In Your Deletion.");
                    return 0;
                }
            }
        }

        public IEnumerable<Service> GetAll()
        {
            string query = "Select ID, RoomNo, SDesc, Amount, ServiceDate from Services";
            using (IDbConnection conn = db.GetConnection())
            {
                try
                {
                    return conn.Query<Service>(query);

                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

        public async Task<IEnumerable<Service>> GetAllAsync()
        {
            string query = "Select ID, RoomNo, SDesc, Amount, ServiceDate from Services";
            using (IDbConnection conn = db.GetConnection())
            {
                try
                {
                    return await conn.QueryAsync<Service>(query);

                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

        public Service GetById(int id)
        {
            string query = "Select ID, RoomNo, SDesc, Amount, ServiceDate from Services where ID = @ID";

            using (IDbConnection conn = db.GetConnection())
            {
                try
                {
                    return conn.QueryFirstOrDefault<Service>(query, new { ID = id });

                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

        public async Task<Service> GetByIdAsync(int id)
        {
            string query = "Select ID, RoomNo, SDesc, Amount, ServiceDate from Services where ID = @ID";

            using (IDbConnection conn = db.GetConnection())
            {
                try
                {
                    return await conn.QueryFirstOrDefaultAsync<Service>(query, new { ID = id });

                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

        public int Insert(Service item)
        {
            using (IDbConnection conn = db.GetConnection())
            {
                try
                {
                    return conn.Execute("Insert into Services values (@RoomNo, @SDesc, @Amount, @ServiceDate)", item);

                }
                catch (Exception)
                {

                    Console.WriteLine("There Is A SQL Constraint Violation In Your Insertion.");
                    return 0;
                }
            }
        }

        public async Task<int> InsertAsync(Service item)
        {
            using (IDbConnection conn = db.GetConnection())
            {
                try
                {
                    return await conn.ExecuteAsync("Insert into Services values (@RoomNo, @SDesc, @Amount, @ServiceDate)", item);

                }
                catch (Exception)
                {

                    Console.WriteLine("There Is A SQL Constraint Violation In Your Insertion.");
                    return 0;
                }
            }
        }

        public int Update(Service item)
        {
            using (IDbConnection conn = db.GetConnection())
            {
                try
                {
                    return conn.Execute("Update Services set RoomNo = @RoomNo, SDesc = @SDesc, Amount = @Amount, ServiceDate = @ServiceDate where ID = @ID", item);

                }
                catch (Exception)
                {

                    Console.WriteLine("There Is A SQL Constraint Violation In Your Update.");
                    return 0;
                }
            }
        }

        public async Task<int> UpdateAsync(Service item)
        {
            using (IDbConnection conn = db.GetConnection())
            {
                try
                {
                    return await conn.ExecuteAsync("Update Services set RoomNo = @RoomNo, SDesc = @SDesc, Amount = @Amount, ServiceDate = @ServiceDate where ID = @ID", item);

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
