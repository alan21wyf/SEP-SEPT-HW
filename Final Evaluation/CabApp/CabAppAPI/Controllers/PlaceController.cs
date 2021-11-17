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
    public class PlaceController : ControllerBase
    {
        private readonly IPlaceService _placeService;

        public PlaceController(IPlaceService placeService)
        {
            _placeService = placeService;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllPlaces()
        {
            var places = await _placeService.GetAllPlaces();
            if (!places.Any())
            {
                return NotFound("No Places Found.");
            }
            return Ok(places);
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateNewPlace(PlaceRequestModel placeRequestModel)
        {
            var newPlace = await _placeService.CreatePlace(placeRequestModel);
            if (newPlace == null)
            {
                return BadRequest("Please Enter Valid Information.");
            }
            return Ok(newPlace);
        }

        [HttpPost]
        [Route("update")]
        public async Task<IActionResult> UpdatePlace(PlaceUpdateRequestModel placeRequestModel)
        {
            var updated = await _placeService.UpdatePlace(placeRequestModel);
            return Ok(updated);
        }

        [HttpPost]
        [Route("delete")]
        public async Task<IActionResult> DeletePlace(PlaceRequestModel placeRequestModel)
        {
            var deleted = await _placeService.DeletePlace(placeRequestModel.Id.GetValueOrDefault());
            return Ok(deleted);
        }
    }
}
