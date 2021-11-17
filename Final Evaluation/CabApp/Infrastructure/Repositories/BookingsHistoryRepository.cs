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
    public class BookingsHistoryRepository : EfRepository<BookingsHistory>, IBookingsHistoryRepository
    {
        public BookingsHistoryRepository(CabAppDbContext dbContext) : base(dbContext)
        {

        }

        public async override Task<BookingsHistory> GetById(int id)
        {
            var bookingHist = await _dbContext.Set<BookingsHistory>().FindAsync(id);
            if (bookingHist == null)
            {
                throw new Exception($"Booking History With ID = {id} Does Not Exist.");
            }
            var fromPlace = await _dbContext.Set<Place>().FindAsync(bookingHist.FromPlace);
            var toPlace = await _dbContext.Set<Place>().FindAsync(bookingHist.ToPlace);
            var cabType = await _dbContext.Set<CabType>().FindAsync(bookingHist.CabTypeId);
            bookingHist.CabType = cabType;
            bookingHist.To = toPlace;
            bookingHist.From = fromPlace;
            return bookingHist;
        }

        public async override Task<IEnumerable<BookingsHistory>> Get(Expression<Func<BookingsHistory, bool>> predicate)
        {
            var bookingsHists = await _dbContext.Set<BookingsHistory>().Where(predicate).ToListAsync();
            if (bookingsHists == null || bookingsHists.Count() == 0)
            {
                throw new Exception($"No Bookings Histories Found Matching The Search Condition.");
            }
            foreach (var bookingHist in bookingsHists)
            {
                var fromPlace = await _dbContext.Set<Place>().FindAsync(bookingHist.FromPlace);
                var toPlace = await _dbContext.Set<Place>().FindAsync(bookingHist.ToPlace);
                var cabType = await _dbContext.Set<CabType>().FindAsync(bookingHist.CabTypeId);
                bookingHist.CabType = cabType;
                bookingHist.To = toPlace;
                bookingHist.From = fromPlace;
            }
            return bookingsHists;
        }

        public async override Task<IEnumerable<BookingsHistory>> GetAll()
        {
            var bookingsHists = await _dbContext.Set<BookingsHistory>().ToListAsync();
            if (bookingsHists == null || bookingsHists.Count() == 0)
            {
                throw new Exception($"No Bookings Histories Found.");
            }
            foreach (var bookingHist in bookingsHists)
            {
                var fromPlace = await _dbContext.Set<Place>().FindAsync(bookingHist.FromPlace);
                var toPlace = await _dbContext.Set<Place>().FindAsync(bookingHist.ToPlace);
                var cabType = await _dbContext.Set<CabType>().FindAsync(bookingHist.CabTypeId);
                bookingHist.CabType = cabType;
                bookingHist.To = toPlace;
                bookingHist.From = fromPlace;
            }
            return bookingsHists;
        }
    }
}
