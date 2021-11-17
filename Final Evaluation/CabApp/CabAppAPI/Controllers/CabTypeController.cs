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
    public class CabTypeController : ControllerBase
    {
        private readonly ICabTypeService _cabTypeService;
        private readonly IBookingsService _bookingsService;
        private readonly IBookingsHistoryService _bookingsHistoryService;

        public CabTypeController(ICabTypeService cabTypeService, IBookingsService bookingsService, IBookingsHistoryService bookingsHistoryService)
        {
            _cabTypeService = cabTypeService;
            _bookingsService = bookingsService;
            _bookingsHistoryService = bookingsHistoryService;
        }


        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllCabTypes()
        {
            var cabs = await _cabTypeService.GetAllCabTypes();
            if (!cabs.Any())
            {
                return NotFound("No Cab Types Found.");
            }
            return Ok(cabs);
        }


        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetCabTypeById(int id)
        {
            var cabType = await _cabTypeService.GetCabTypeById(id);
            if (cabType == null)
            {
                return NotFound("No Bookings Associated With This Cab Type.");
            }
            return Ok(cabType);
        }


        [HttpGet]
        [Route("{id:int}/Bookings")]
        public async Task<IActionResult> GetBookingsByCabType(int id)
        {
            var bookings = await _bookingsService.GetBookingsByCabType(id);
            if (!bookings.Any())
            {
                return NotFound("No Bookings Associated With This Cab Type.");
            }
            return Ok(bookings);
        }

        [HttpGet]
        [Route("{id:int}/BookingsHistories")]
        public async Task<IActionResult> GetBookingsHistoriesByCabType(int id)
        {
            var bookingsHist = await _bookingsHistoryService.GetBookingsHistoriesByCabType(id);
            if (!bookingsHist.Any())
            {
                return NotFound("No Bookings Histories Associated With This Cab Type.");
            }
            return Ok(bookingsHist);
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateNewCabType(CabTypeRequestModel cabTypeRequestModel)
        {
            var newCabType = await _cabTypeService.CreateCabType(cabTypeRequestModel);
            if (newCabType == null)
            {
                return BadRequest("Please Enter Valid Information.");
            }
            return Ok(newCabType);
        }

        [HttpPost]
        [Route("update")]
        public async Task<IActionResult> UpdateCabType(CabTypeUpdateRequestModel cabTypeUpdateRequestModel)
        {
            var updated = await _cabTypeService.UpdateCabType(cabTypeUpdateRequestModel);
            return Ok(updated);
        }

        [HttpPost]
        [Route("delete")]
        public async Task<IActionResult> DeleteCabType(CabTypeRequestModel cabTypeRequestModel)
        {
            await _cabTypeService.DeleteCabType(cabTypeRequestModel.Id.GetValueOrDefault());
            return Ok();
        }
    }
}
