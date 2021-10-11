using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelManagementSystem.Data.Model;
using System.Data;
using Dapper;

namespace HotelManagementSystem.Data.Repository
{
    public class RoomTypeRepository : IRepositoryAsync<RoomType>, IRepository<RoomType>
    {
        HotelDbContext db;
        public RoomTypeRepository()
        {
            db = new HotelDbContext();
        }

        public int Delete(int id)
        {
            using (IDbConnection conn = db.GetConnection())
            {
                try
                {
                    return conn.Execute("Delete from RoomTypes where ID = @ID", new { ID = id });
                }
                catch (Exception e)
                {
                    throw;
                }
            }
        }

        public async Task<int> DeleteAsync(int id)
        {
            using (IDbConnection conn = db.GetConnection())
            {
                try
                {
                    return await conn.ExecuteAsync("Delete from RoomTypes where ID = @ID", new { ID = id });
                }
                catch (Exception e)
                {
                    throw;
                }
            }
        }

        public IEnumerable<RoomType> GetAll()
        {
            using (IDbConnection conn = db.GetConnection())
            {
                try
                {
                    return conn.Query<RoomType>("Select ID, RTDesc, Rent from RoomTypes");
                }
                catch (Exception e)
                {

                    throw;
                }
            }
        }

        public async Task<IEnumerable<RoomType>> GetAllAsync()
        {
            using (IDbConnection conn = db.GetConnection())
            {
                try
                {
                    return await conn.QueryAsync<RoomType>("Select ID, RTDesc, Rent from RoomTypes");
                }
                catch (Exception e)
                {

                    throw;
                }
            }
        }

        public RoomType GetById(int id)
        {
            using (IDbConnection conn = db.GetConnection())
            {
                try
                {
                    return conn.QueryFirstOrDefault<RoomType>("Select ID, RTDesc, Rent from RoomTypes where ID = @ID", new
                    {
                        ID = id
                    });
                }
                catch (Exception e) { throw; }
            }
        }

        public async Task<RoomType> GetByIdAsync(int id)
        {
            using (IDbConnection conn = db.GetConnection())
            {
                try
                {
                    return await conn.QueryFirstOrDefaultAsync<RoomType>("Select ID, RTDesc, Rent from RoomTypes where ID = @ID", new
                    {
                        ID = id
                    });
                }
                catch (Exception e) { throw; }
            }
        }

        public int Insert(RoomType item)
        {
            using (IDbConnection conn = db.GetConnection())
            {
                try
                {
                    return conn.Execute("Insert into RoomTypes values (@RTDesc, @Rent)", item);
                }
                catch (Exception e) { throw; }
            }
        }

        public async Task<int> InsertAsync(RoomType item)
        {
            using (IDbConnection conn = db.GetConnection())
            {
                try
                {
                    return await conn.ExecuteAsync("Insert into RoomTypes values (@RTDesc, @Rent)", item);
                }
                catch (Exception e) { throw; }
            }
        }

        public int Update(RoomType item)
        {
            using (IDbConnection conn = db.GetConnection())
            {
                try
                {
                    return conn.Execute("Update RoomTypes set RTDesc = @RTDesc, Rent = @Rent where ID = @ID", item);
                }
                catch (Exception e) { Console.WriteLine(e.Message); return 0; }
            }
        }

        public async Task<int> UpdateAsync(RoomType item)
        {
            using (IDbConnection conn = db.GetConnection())
            {
                try
                {
                    return await conn.ExecuteAsync("Update RoomTypes set RTDesc = @RTDesc, Rent = @Rent where ID = @ID", item);
                }
                catch (Exception e) { throw; }
            }
        }

    }
}
