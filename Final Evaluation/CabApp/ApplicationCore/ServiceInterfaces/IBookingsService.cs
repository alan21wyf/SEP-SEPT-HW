using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.ServiceInterfaces
{
    public interface IBookingsService
    {
        Task<List<BookingResponseModel>> GetAllBookings();
        Task<List<BookingResponseModel>> GetBookingsByCabType(int cabTypeId);
        Task<BookingResponseModel> GetBookingById(int id);
        Task<BookingResponseModel> CreateBooking(BookingRequestModel requestModel);
        Task<BookingResponseModel> UpdateBooking(BookingRequestModel requestModel);
        Task<BookingResponseModel> DeleteBooking(int id);
    }
}
