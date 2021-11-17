using ApplicationCore.Entities;
using ApplicationCore.Models;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yifan_Wu.CabApp.Infrastructure.Services
{
    public class BookingsService : IBookingsService
    {
        private readonly IBookingsRepository _bookingsRepository;
        private readonly IPlaceRepository _placeRepository;
        private readonly ICabTypeRepository _cabTypeRepository;

        public BookingsService(IBookingsRepository bookingsRepository, IPlaceRepository placeRepository, ICabTypeRepository cabTypeRepository)
        {
            _bookingsRepository = bookingsRepository;
            _placeRepository = placeRepository;
            _cabTypeRepository = cabTypeRepository;
        }

        public async Task<BookingResponseModel> CreateBooking(BookingRequestModel requestModel)
        {
            var fromPlace = await _placeRepository.GetById(requestModel.FromPlace.GetValueOrDefault());
            var toPlace = await _placeRepository.GetById(requestModel.ToPlace.GetValueOrDefault());
            var cabType = await _cabTypeRepository.GetById(requestModel.CabTypeId.GetValueOrDefault());

            var booking = new Bookings
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
                CabType = cabType,
                From = fromPlace,
                To = toPlace
            };


            var dbBooking = await _bookingsRepository.Add(booking);


            var bookingModel = new BookingResponseModel
            {
                Id = dbBooking.Id,
                Email = dbBooking.Email,
                BookingDate = dbBooking.BookingDate,
                BookingTime = dbBooking.BookingTime,
                FromPlace = dbBooking.FromPlace,
                FromPlaceName = dbBooking.From.PlaceName,
                ToPlace = dbBooking.ToPlace,
                ToPlaceName = dbBooking.To.PlaceName,
                PickupAddress = dbBooking.PickupAddress,
                Landmark = dbBooking.Landmark,
                PickupDate = dbBooking.PickupDate,
                PickupTime = dbBooking.PickupTime,
                CabTypeId = dbBooking.CabTypeId,
                CabTypeName = dbBooking.CabType.CabTypeName,
                ContactNo = dbBooking.ContactNo,
                Status = dbBooking.Status
            };
            return bookingModel;

        }

        public async Task<BookingResponseModel> DeleteBooking(int id)
        {
            var booking = await _bookingsRepository.GetById(id);
            if (booking == null)
            {
                throw new Exception($"Booking With ID = {id} Does Not Exist.");
            }
            var deleted = await _bookingsRepository.Delete(booking);
            var deletedModel = new BookingResponseModel
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
                Status = deleted.Status
            };
            return deletedModel;
        }

        public async Task<List<BookingResponseModel>> GetAllBookings()
        {
            var bookings = await _bookingsRepository.GetAll();
            var models = new List<BookingResponseModel>();
            foreach (var booking in bookings)
            {
                models.Add(new BookingResponseModel
                {
                    Id = booking.Id,
                    Email = booking.Email,
                    BookingDate = booking.BookingDate,
                    BookingTime = booking.BookingTime,
                    FromPlace = booking.FromPlace,
                    FromPlaceName = booking.From.PlaceName,
                    ToPlace = booking.ToPlace,
                    ToPlaceName = booking.To.PlaceName,
                    PickupAddress = booking.PickupAddress,
                    Landmark = booking.Landmark,
                    PickupDate = booking.PickupDate,
                    PickupTime = booking.PickupTime,
                    CabTypeId = booking.CabTypeId,
                    CabTypeName = booking.CabType.CabTypeName,
                    ContactNo = booking.ContactNo,
                    Status = booking.Status

                });
            }
            return models;
        }

        public async Task<BookingResponseModel> GetBookingById(int id)
        {
            var booking = await _bookingsRepository.GetById(id);
            if (booking == null )
            {
                throw new Exception("Booking Does Not Exist.");
            }
            var model = new BookingResponseModel
            {
                Id = booking.Id,
                Email = booking.Email,
                BookingDate = booking.BookingDate,
                BookingTime = booking.BookingTime,
                FromPlace = booking.FromPlace,
                FromPlaceName = booking.From.PlaceName,
                ToPlace = booking.ToPlace,
                ToPlaceName = booking.To.PlaceName,
                PickupAddress = booking.PickupAddress,
                Landmark = booking.Landmark,
                PickupDate = booking.PickupDate,
                PickupTime = booking.PickupTime,
                CabTypeId = booking.CabTypeId,
                CabTypeName = booking.CabType.CabTypeName,
                ContactNo = booking.ContactNo,
                Status = booking.Status
            };

            return model;
        }

        public async Task<List<BookingResponseModel>> GetBookingsByCabType(int cabTypeId)
        {
            var bookings = await _bookingsRepository.Get(b => b.CabTypeId == cabTypeId);
            if (bookings.Count() == 0)
            {
                throw new Exception($"No Bookings Associated With Cab Type Id = {cabTypeId}.");
            }
            var bookingsModel = new List<BookingResponseModel>();
            foreach (var booking in bookings)
            {
                bookingsModel.Add(new BookingResponseModel
                {
                    Id = booking.Id,
                    Email = booking.Email,
                    BookingDate = booking.BookingDate,
                    BookingTime = booking.BookingTime,
                    FromPlace = booking.FromPlace,
                    FromPlaceName = booking.From.PlaceName,
                    ToPlace = booking.ToPlace,
                    ToPlaceName = booking.To.PlaceName,
                    PickupAddress = booking.PickupAddress,
                    Landmark = booking.Landmark,
                    PickupDate = booking.PickupDate,
                    PickupTime = booking.PickupTime,
                    CabTypeId = booking.CabTypeId,
                    CabTypeName = booking.CabType.CabTypeName,
                    ContactNo = booking.ContactNo,
                    Status = booking.Status
                });
            }
            return bookingsModel;
        }

        public async Task<BookingResponseModel> UpdateBooking(BookingRequestModel requestModel)
        {
            var booking = await _bookingsRepository.GetById(requestModel.Id.GetValueOrDefault());
            if (booking == null)
            {
                throw new Exception($"Booking With Id = {requestModel.Id} Does Not Exist.");
            }
            var fromPlace = await _placeRepository.GetById(requestModel.FromPlace.GetValueOrDefault());
            var toPlace = await _placeRepository.GetById(requestModel.ToPlace.GetValueOrDefault());
            var cabType = await _cabTypeRepository.GetById(requestModel.CabTypeId.GetValueOrDefault());

            var newBooking = new Bookings
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
                CabType = cabType,
                From = fromPlace,
                To = toPlace
            };
            var updated = await _bookingsRepository.Update(newBooking);
            var updatedModel = new BookingResponseModel
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
                Status = updated.Status
            };
            return updatedModel;
        }
    }
}
