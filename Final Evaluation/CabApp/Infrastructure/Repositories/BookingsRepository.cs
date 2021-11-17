using ApplicationCore.Entities;
using ApplicationCore.RepositoryInterfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class BookingsRepository:EfRepository<Bookings>, IBookingsRepository
    {
        public BookingsRepository(CabAppDbContext dbContext) : base(dbContext)
        {

        }

        public async override Task<Bookings> GetById(int id)
        {
            var booking = await _dbContext.Set<Bookings>().FindAsync(id);
            if (booking == null)
            {
                throw new Exception($"Booking With ID = {id} Does Not Exist.");
            }
            var fromPlace = await _dbContext.Set<Place>().FindAsync(booking.FromPlace);
            var toPlace = await _dbContext.Set<Place>().FindAsync(booking.ToPlace);
            var cabType = await _dbContext.Set<CabType>().FindAsync(booking.CabTypeId);
            booking.CabType = cabType;
            booking.To = toPlace;
            booking.From = fromPlace;
            return booking;
        }

        public async override Task<IEnumerable<Bookings>> Get(Expression<Func<Bookings, bool>> predicate)
        {
            var bookings = await _dbContext.Set<Bookings>().Where(predicate).ToListAsync();
            if (bookings == null || bookings.Count() == 0)
            {
                throw new Exception($"No Bookings Found Matching The Search Condition.");
            }
            foreach (var booking in bookings)
            {
                var fromPlace = await _dbContext.Set<Place>().FindAsync(booking.FromPlace);
                var toPlace = await _dbContext.Set<Place>().FindAsync(booking.ToPlace);
                var cabType = await _dbContext.Set<CabType>().FindAsync(booking.CabTypeId);
                booking.CabType = cabType;
                booking.To = toPlace;
                booking.From = fromPlace;
            }
            return bookings;
        }

        public async override Task<IEnumerable<Bookings>> GetAll()
        {
            var bookings = await _dbContext.Set<Bookings>().ToListAsync();
            if (bookings == null || bookings.Count() == 0)
            {
                throw new Exception($"No Bookings Found.");
            }
            foreach (var booking in bookings)
            {
                var fromPlace = await _dbContext.Set<Place>().FindAsync(booking.FromPlace);
                var toPlace = await _dbContext.Set<Place>().FindAsync(booking.ToPlace);
                var cabType = await _dbContext.Set<CabType>().FindAsync(booking.CabTypeId);
                booking.CabType = cabType;
                booking.To = toPlace;
                booking.From = fromPlace;
            }
            return bookings;
        }
    }
}
