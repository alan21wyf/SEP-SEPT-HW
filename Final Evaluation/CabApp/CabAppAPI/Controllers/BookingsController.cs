using ApplicationCore.Models;
using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Yifan_Wu.CabApp.CabAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly IBookingsService _bookingsService;

        public BookingsController(IBookingsService bookingsService)
        {
            _bookingsService = bookingsService;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllBookings()
        {
            var bookings = await _bookingsService.GetAllBookings();
            if (!bookings.Any())
            {
                return NotFound("No Bookings Found.");
            }
            return Ok(bookings);
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateNewBookings(BookingRequestModel bookingsRequestModel)
        {
            var newBooking = await _bookingsService.CreateBooking(bookingsRequestModel);
            if (newBooking == null)
            {
                return BadRequest("Please Enter Valid Information.");
            }
            return Ok(newBooking);
        }

        [HttpPost]
        [Route("update")]
        public async Task<IActionResult> UpdateBooking(BookingRequestModel bookingRequestModel)
        {
            try
            {
                var updated = await _bookingsService.UpdateBooking(bookingRequestModel);
                return Ok(updated);
            }
            catch (Exception)
            {
                throw new Exception("Update Fails.");
            }
        }

        [HttpPost]
        [Route("delete")]
        public async Task<IActionResult> DeleteBooking(BookingRequestModel bookingRequestModel)
        {
            try
            {
                var deleted = await _bookingsService.DeleteBooking(bookingRequestModel.Id.GetValueOrDefault());
                return Ok(deleted);
            }
            catch (Exception)
            {
                throw new Exception("Update Fails.");
            }
        }
    }
}
