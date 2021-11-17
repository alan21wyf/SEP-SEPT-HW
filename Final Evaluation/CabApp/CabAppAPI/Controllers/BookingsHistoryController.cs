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
    public class BookingsHistoryController : ControllerBase
    {
        private readonly IBookingsHistoryService _bookingsHistoryService;

        public BookingsHistoryController(IBookingsHistoryService bookingsHistoryService)
        {
            _bookingsHistoryService = bookingsHistoryService;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllBookingsHistory()
        {
            var bookingsHistory = await _bookingsHistoryService.GetAllBookingsHistories();
            if (!bookingsHistory.Any())
            {
                return NotFound("No Bookings Histories Found.");
            }
            return Ok(bookingsHistory);
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateNewBookingsHistory(BookingHistoryRequestModel bookingsHistoryRequestModel)
        {
            var newBookingHistory = await _bookingsHistoryService.CreateBookingHistory(bookingsHistoryRequestModel);
            if (newBookingHistory == null)
            {
                return BadRequest("Please Enter Valid Information.");
            }
            return Ok(newBookingHistory);
        }

        [HttpPost]
        [Route("update")]
        public async Task<IActionResult> UpdateBookingHistory(BookingHistoryRequestModel bookingHistoryRequestModel)
        {
            try
            {
                var updated = await _bookingsHistoryService.UpdateBookingHistory(bookingHistoryRequestModel);
                return Ok(updated);
            }
            catch (Exception)
            {
                throw new Exception("Update Fails.");
            }
        }

        [HttpPost]
        [Route("delete")]
        public async Task<IActionResult> DeleteBookingHistory(BookingHistoryRequestModel bookingHistoryRequestModel)
        {
            try
            {
                var deleted = await _bookingsHistoryService.DeleteBookingHistory(bookingHistoryRequestModel.Id.GetValueOrDefault());
                return Ok(deleted);
            }
            catch (Exception)
            {
                throw new Exception("Update Fails.");
            }
        }
    }
}
