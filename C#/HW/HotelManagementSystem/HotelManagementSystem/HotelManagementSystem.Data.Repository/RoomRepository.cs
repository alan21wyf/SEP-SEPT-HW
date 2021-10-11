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
    public class RoomRepository : IRepositoryAsync<Room>, IRepository<Room>
    {
        HotelDbContext db;
        public RoomRepository()
        {
            db = new HotelDbContext();
        }

        public int Delete(int id)
        {
            using (IDbConnection conn = db.GetConnection())
            {
                try
                {
                    return conn.Execute("Delete from Rooms where ID = @ID", new { ID = id });

                }
                catch (Exception e)
                {
                    Console.WriteLine("There Is A SQL Constraint Violation In Your Deletion.");
                    return 0;
                }
            }
        }

        async public Task<int> DeleteAsync(int id)
        {
            using (IDbConnection conn = db.GetConnection())
            {
                try
                {
                    return await conn.ExecuteAsync("Delete from Rooms where ID = @ID", new { ID = id });

                }
                catch (Exception e)
                {
                    Console.WriteLine("There Is A SQL Constraint Violation In Your Deletion.");
                    return 0;
                }
            }
        }

        public IEnumerable<Room> GetAll()
        {
            using (IDbConnection conn = db.GetConnection())
            {
                try
                {
                    return conn.Query<Room>("Select ID, RTCode, Status from Rooms");

                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }

        async public Task<IEnumerable<Room>> GetAllAsync()
        {
            using (IDbConnection conn = db.GetConnection())
            {
                try
                {
                    return await conn.QueryAsync<Room>("Select ID, RTCode, Status from Rooms");

                }
                catch (Exception e)
                {
                    return null ;
                }
            }
        }

        public Room GetById(int id)
        {
            using (IDbConnection conn = db.GetConnection())
            {
                try
                {
                    return conn.QueryFirstOrDefault<Room>("Select ID, RTCode, Status from Rooms where ID = @ID", new
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

        async public Task<Room> GetByIdAsync(int id)
        {
            using (IDbConnection conn = db.GetConnection())
            {
                try
                {
                    return await conn.QueryFirstOrDefaultAsync<Room>("Select ID, RTCode, Status from Rooms where ID = @ID", new
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

        public int Insert(Room item)
        {
            using (IDbConnection conn = db.GetConnection())
            {
                try
                {
                    return conn.Execute("Insert into Rooms values (@RTCode, @Status)", item);

                }
                catch (Exception e)
                {
                    Console.WriteLine("There Is A SQL Constraint Violation In Your Insertion.");
                    return 0;
                }
            }
        }

        async public Task<int> InsertAsync(Room item)
        {
            using (IDbConnection conn = db.GetConnection())
            {
                try
                {
                    return await conn.ExecuteAsync("Insert into Rooms values (@RTCode, @Status)", item);

                }
                catch (Exception e)
                {
                    Console.WriteLine("There Is A SQL Constraint Violation In Your Insertion.");
                    return 0;
                }
            }
        }

        public int Update(Room item)
        {
            using (IDbConnection conn = db.GetConnection())
            {
                try
                {
                    return conn.Execute("Update Rooms set RTCode = @RTCode, Status = @Status where ID = @ID", item);

                }
                catch (Exception e)
                {
                    Console.WriteLine("There Is A SQL Constraint Violation In Your Update.");
                    return 0;
                }
            }
        }

        async public Task<int> UpdateAsync(Room item)
        {
            using (IDbConnection conn = db.GetConnection())
            {
                try
                {
                    return await conn.ExecuteAsync("Update Rooms set RTCode = @RTCode, Status = @Status where ID = @ID");

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
