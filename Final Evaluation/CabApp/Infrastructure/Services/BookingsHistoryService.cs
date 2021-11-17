using ApplicationCore.Entities;
using ApplicationCore.Models;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class BookingsHistoryService : IBookingsHistoryService
    {
        private readonly IBookingsHistoryRepository _bookingsHistoryRepository;
        private readonly IPlaceRepository _placeRepository;
        private readonly ICabTypeRepository _cabTypeRepository;
        public BookingsHistoryService(IBookingsHistoryRepository bookingsHistoryRepository, IPlaceRepository placeRepository, ICabTypeRepository cabTypeRepository)
        {
            _bookingsHistoryRepository = bookingsHistoryRepository;
            _placeRepository = placeRepository;
            _cabTypeRepository = cabTypeRepository;
        }

        public async Task<BookingHistoryResponseModel> CreateBookingHistory(BookingHistoryRequestModel requestModel)
        {
            var fromPlace = await _placeRepository.GetById(requestModel.FromPlace.GetValueOrDefault());
            var toPlace = await _placeRepository.GetById(requestModel.ToPlace.GetValueOrDefault());
            var cabType = await _cabTypeRepository.GetById(requestModel.CabTypeId.GetValueOrDefault());

            var bookingHist = new BookingsHistory
            {
                Email = requestModel.Email,
                BookingDate = requestModel.BookingDate,
                BookingTime = requestModel.BookingTime,
                FromPlace = requestModel.FromPlace,
                ToPlace = requestModel.ToPlace,
                PickupAddress = requestModel.PickupAddress,
                Landmark = requestModel.Landmark,
                PickupDate = requestModel.PickupDate,
                PickupTime = requestModel.PickupTime,
                CabTypeId = requestModel.CabTypeId,
                ContactNo = requestModel.ContactNo,
                Status = requestModel.Status,
                Comp_time = requestModel.Comp_time,
                Charge = requestModel.Charge,
                Feedback = requestModel.Feedback,
                CabType = cabType,
                From = fromPlace,
                To = toPlace
            };


            var dbBookingHist = await _bookingsHistoryRepository.Add(bookingHist);

            var bookingHistModel = new BookingHistoryResponseModel
            {
                Id = dbBookingHist.Id,
                Email = dbBookingHist.Email,
                BookingDate = dbBookingHist.BookingDate,
                BookingTime = dbBookingHist.BookingTime,
                FromPlace = dbBookingHist.FromPlace,
                FromPlaceName = dbBookingHist.From.PlaceName,
                ToPlace = dbBookingHist.ToPlace,
                ToPlaceName = dbBookingHist.To.PlaceName,
                PickupAddress = dbBookingHist.PickupAddress,
                Landmark = dbBookingHist.Landmark,
                PickupDate = dbBookingHist.PickupDate,
                PickupTime = dbBookingHist.PickupTime,
                CabTypeId = dbBookingHist.CabTypeId,
                CabTypeName = dbBookingHist.CabType.CabTypeName,
                ContactNo = dbBookingHist.ContactNo,
                Status = dbBookingHist.Status,
                Comp_time = dbBookingHist.Comp_time,
                Charge = dbBookingHist.Charge,
                Feedback = dbBookingHist.Feedback
            };
            return bookingHistModel;
            
        }

        public async Task<BookingHistoryResponseModel> DeleteBookingHistory(int id)
        {
            var bookingHist = await _bookingsHistoryRepository.GetById(id);
            if (bookingHist == null)
            {
                throw new Exception($"Booking History With ID = {id} Does Not Exist.");
            }
            var deleted = await _bookingsHistoryRepository.Delete(bookingHist);
            var deletedModel = new BookingHistoryResponseModel
            {
                Email = deleted.Email,
                BookingDate = deleted.BookingDate,
                BookingTime = deleted.BookingTime,
                FromPlace = deleted.FromPlace,
                ToPlace = deleted.ToPlace,
                PickupAddress = deleted.PickupAddress,
                Landmark = deleted.Landmark,
                PickupDate = deleted.PickupDate,
                PickupTime = deleted.PickupTime,
                CabTypeId = deleted.CabTypeId,
                ContactNo = deleted.ContactNo,
                Status = deleted.Status,
                Comp_time = deleted.Comp_time,
                Charge = deleted.Charge,
                Feedback = deleted.Feedback
            };
            return deletedModel;
        }

        public async Task<List<BookingHistoryResponseModel>> GetAllBookingsHistories()
        {
            var bookingHists = await _bookingsHistoryRepository.GetAll();
            var models = new List<BookingHistoryResponseModel>();
            foreach (var bookingHist in bookingHists)
            {
                models.Add(new BookingHistoryResponseModel
                {
                    Id = bookingHist.Id,
                    Email = bookingHist.Email,
                    BookingDate = bookingHist.BookingDate,
                    BookingTime = bookingHist.BookingTime,
                    FromPlace = bookingHist.FromPlace,
                    FromPlaceName = bookingHist.From.PlaceName,
                    ToPlace = bookingHist.ToPlace,
                    ToPlaceName = bookingHist.To.PlaceName,
                    PickupAddress = bookingHist.PickupAddress,
                    Landmark = bookingHist.Landmark,
                    PickupDate = bookingHist.PickupDate,
                    PickupTime = bookingHist.PickupTime,
                    CabTypeId = bookingHist.CabTypeId,
                    CabTypeName = bookingHist.CabType.CabTypeName,
                    ContactNo = bookingHist.ContactNo,
                    Status = bookingHist.Status,
                    Comp_time = bookingHist.Comp_time,
                    Charge = bookingHist.Charge,
                    Feedback = bookingHist.Feedback
                });
            }
            return models;
        }

        public async Task<BookingHistoryResponseModel> GetBookingHistoryById(int id)
        {
            var bookingHists = await _bookingsHistoryRepository.GetAll();
            if (bookingHists.FirstOrDefault() == null || bookingHists.Count() != 1)
            {
                throw new Exception("Booking History Does Not Exist.");
            }
            var bookingHist = bookingHists.FirstOrDefault();

            var model = new BookingHistoryResponseModel
            {
                Id = bookingHist.Id,
                Email = bookingHist.Email,
                BookingDate = bookingHist.BookingDate,
                BookingTime = bookingHist.BookingTime,
                FromPlace = bookingHist.FromPlace,
                FromPlaceName = bookingHist.From.PlaceName,
                ToPlace = bookingHist.ToPlace,
                ToPlaceName = bookingHist.To.PlaceName,
                PickupAddress = bookingHist.PickupAddress,
                Landmark = bookingHist.Landmark,
                PickupDate = bookingHist.PickupDate,
                PickupTime = bookingHist.PickupTime,
                CabTypeId = bookingHist.CabTypeId,
                CabTypeName = bookingHist.CabType.CabTypeName,
                ContactNo = bookingHist.ContactNo,
                Status = bookingHist.Status,
                Comp_time = bookingHist.Comp_time,
                Charge = bookingHist.Charge,
                Feedback = bookingHist.Feedback
            };

            return model;
        }

        public async Task<List<BookingHistoryResponseModel>> GetBookingsHistoriesByCabType(int cabTypeId)
        {
            var bookingHists = await _bookingsHistoryRepository.Get(b => b.CabTypeId == cabTypeId);
            if (bookingHists.Count() == 0)
            {
                throw new Exception($"No Booking Histories Associated With Cab Type Id = {cabTypeId}.");
            }
            var bookingHistoriesModel = new List<BookingHistoryResponseModel>();
            foreach (var bookingHist in bookingHists)
            {
                bookingHistoriesModel.Add(new BookingHistoryResponseModel
                {
                    Id = bookingHist.Id,
                    Email = bookingHist.Email,
                    BookingDate = bookingHist.BookingDate,
                    BookingTime = bookingHist.BookingTime,
                    FromPlace = bookingHist.FromPlace,
                    FromPlaceName = bookingHist.From.PlaceName,
                    ToPlace = bookingHist.ToPlace,
                    ToPlaceName = bookingHist.To.PlaceName,
                    PickupAddress = bookingHist.PickupAddress,
                    Landmark = bookingHist.Landmark,
                    PickupDate = bookingHist.PickupDate,
                    PickupTime = bookingHist.PickupTime,
                    CabTypeId = bookingHist.CabTypeId,
                    CabTypeName = bookingHist.CabType.CabTypeName,
                    ContactNo = bookingHist.ContactNo,
                    Status = bookingHist.Status,
                    Comp_time = bookingHist.Comp_time,
                    Charge = bookingHist.Charge,
                    Feedback = bookingHist.Feedback
                });
            }
            return bookingHistoriesModel;
        }

        public async Task<BookingHistoryResponseModel> UpdateBookingHistory(BookingHistoryRequestModel requestModel)
        {
            var bookingHist = await _bookingsHistoryRepository.GetById(requestModel.Id.GetValueOrDefault());
            if (bookingHist == null)
            {
                throw new Exception($"Booking History With Id = {requestModel.Id} Does Not Exist.");
            }
            var fromPlace = await _placeRepository.GetById(requestModel.FromPlace.GetValueOrDefault());
            var toPlace = await _placeRepository.GetById(requestModel.ToPlace.GetValueOrDefault());
            var cabType = await _cabTypeRepository.GetById(requestModel.CabTypeId.GetValueOrDefault());

            var newBookingHist = new BookingsHistory
            {
                Email = requestModel.Email,
                BookingDate = requestModel.BookingDate,
                BookingTime = requestModel.BookingTime,
                FromPlace = requestModel.FromPlace,
                ToPlace = requestModel.ToPlace,
                PickupAddress = requestModel.PickupAddress,
                Landmark = requestModel.Landmark,
                PickupDate = requestModel.PickupDate,
                PickupTime = requestModel.PickupTime,
                CabTypeId = requestModel.CabTypeId,
                ContactNo = requestModel.ContactNo,
                Status = requestModel.Status,
                Comp_time = requestModel.Comp_time,
                Charge = requestModel.Charge,
                Feedback = requestModel.Feedback,
                CabType = cabType,
                From = fromPlace,
                To = toPlace
            };
            var updated = await _bookingsHistoryRepository.Update(newBookingHist);
            var updatedModel = new BookingHistoryResponseModel
            {
                Email = updated.Email,
                BookingDate = updated.BookingDate,
                BookingTime = updated.BookingTime,
                FromPlace = updated.FromPlace,
                ToPlace = updated.ToPlace,
                PickupAddress = updated.PickupAddress,
                Landmark = updated.Landmark,
                PickupDate = updated.PickupDate,
                PickupTime = updated.PickupTime,
                CabTypeId = updated.CabTypeId,
                ContactNo = updated.ContactNo,
                Status = updated.Status,
                Comp_time = updated.Comp_time,
                Charge = updated.Charge,
                Feedback = updated.Feedback
            };
            return updatedModel;
        }
    }
}
