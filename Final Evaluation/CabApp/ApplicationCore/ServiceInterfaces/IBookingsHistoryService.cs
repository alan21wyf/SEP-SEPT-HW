using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.ServiceInterfaces
{
    public interface IBookingsHistoryService
    {
        Task<List<BookingHistoryResponseModel>> GetAllBookingsHistories();
        Task<List<BookingHistoryResponseModel>> GetBookingsHistoriesByCabType(int cabTypeId);
        Task<BookingHistoryResponseModel> GetBookingHistoryById(int id);
        Task<BookingHistoryResponseModel> CreateBookingHistory(BookingHistoryRequestModel requestModel);
        Task<BookingHistoryResponseModel> UpdateBookingHistory(BookingHistoryRequestModel requestModel);
        Task<BookingHistoryResponseModel> DeleteBookingHistory(int id);
    }
}
