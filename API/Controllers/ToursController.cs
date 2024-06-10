using API.Dtos;
using API.Errors;
using API.Extensions;
using AutoMapper;
using Core.Entities.TourAggregate;
using Core.Interfaces;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;

namespace API.Controllers
{

    [Authorize]
    public class ToursController : BaseApiController
    {
        private readonly ITourService _tourservice;
        private readonly IMapper _mapper;

        public ToursController(ITourService tourservice, IMapper mapper)
        {
            _tourservice = tourservice;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<Tour>> CreateTour(TourDto tourDto)
        {
            var email = HttpContext.User.RetreiveEmailFromPrincipal();

            var address = _mapper.Map<AddressDto, Address>(tourDto.UserData);

            var tour = await _tourservice.CreateTourAsync(email, tourDto.PlannerId, address);

            if (tour == null) return BadRequest(new ApiResponse(400, "Problem creating order"));

            return Ok(tour);

        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<TourToReturnDto>>> GetToursForUser()
        {
            var email = HttpContext.User.RetreiveEmailFromPrincipal();

            var tours = await _tourservice.GetToursForUserAsync(email);

            var filteredTours = tours.Where(t => t.Status != TourStatus.Completed).ToList();


            return Ok(_mapper.Map<IReadOnlyList<TourToReturnDto>>(filteredTours));
        }

        [HttpGet("completed")]
        public async Task<ActionResult<IReadOnlyList<TourToReturnDto>>> GetCompletedToursForUser()
        {
            var email = HttpContext.User.RetreiveEmailFromPrincipal();

            var tours = await _tourservice.GetToursForUserAsync(email);

            // Filter tours where the status is "Completed"
            var completedTours = tours.Where(t => t.Status == TourStatus.Completed).ToList();

            return Ok(_mapper.Map<IReadOnlyList<TourToReturnDto>>(completedTours));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TourToReturnDto>> GetTourByIdForUser(int id)
        {
            var email = HttpContext.User.RetreiveEmailFromPrincipal();

            var tour = await _tourservice.GetTourByIdAsync(id, email);

            if (tour == null) return NotFound(new ApiResponse(404));

            return _mapper.Map<TourToReturnDto>(tour);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TourToReturnDto>> UpdateTour(int id, TourToUpdateDto tourDto)
        {
            var email = HttpContext.User.RetreiveEmailFromPrincipal();

            // Fetch the existing tour from the database
            var existingTour = await _tourservice.GetTourByIdAsync(id, email);
            if (existingTour == null) return NotFound(new ApiResponse(404));

            // Update the existing tour entity with the new data
            _mapper.Map(tourDto, existingTour);

            // Save the changes to the database
            var updatedTour = await _tourservice.UpdateTourAsync(existingTour);
            if (updatedTour == null) return BadRequest(new ApiResponse(400, "Problem updating tour"));

            return _mapper.Map<TourToReturnDto>(updatedTour);
        }
        [HttpPut("{id}/updateTourDate")]
        public async Task<IActionResult> UpdateTourDate(int id, [FromBody] TourDateUpdateDto tourDateDto)
        {
            var userEmail = HttpContext.User.RetreiveEmailFromPrincipal();
            var tour = await _tourservice.GetTourByIdAsync(id, userEmail);

            if (tour == null)
            {
                return NotFound();
            }

            // Update the TourDate property with the new value
            tour.TourDate = tourDateDto.TourDate;

            try
            {
                // Save the changes to the database
                await _tourservice.UpdateTourAsync(tour);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Handle any errors that occur during the update process
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to update TourDate");
            }
        }


        [HttpPut("{id}/complete")]
        public async Task<IActionResult> CompleteTour(int id)
        {
            var userEmail = HttpContext.User.RetreiveEmailFromPrincipal();

            // Retrieve the tour by ID and user email
            var tour = await _tourservice.GetTourByIdAsync(id, userEmail);
            if (tour == null)
            {
                return NotFound(); // Tour not found or user not authorized
            }

            // Update tour status to Completed
            tour.Status = TourStatus.Completed;

            // Update the tour in the database
            var updatedTour = await _tourservice.UpdateTourAsync(tour);
            if (updatedTour == null)
            {
                return BadRequest("Failed to update tour status."); // Handle update failure
            }

            return Ok(updatedTour); // Return the updated tour
        }



    }
        
}
