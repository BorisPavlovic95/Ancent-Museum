using API.Dtos;
using Core.Entities.TourAggregate;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using API.Extensions;
using Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers
{
    [Authorize]
    public class ExhibitRatings : BaseApiController
    {
        private readonly IExhibitRatingCommentRepository _repository;
        private readonly ITourService _tourService;
        private readonly IMapper _mapper;

        public ExhibitRatings(IExhibitRatingCommentRepository repository, ITourService tourService, IMapper mapper)
        {
            _repository = repository;
            _tourService = tourService;
            _mapper = mapper;
        }

        [HttpGet("{tourId}")]
        public async Task<ActionResult<IEnumerable<ExhibitRatingCommentDto>>> GetExhibitRatingsComments(int tourId)
        {
            var userEmail = HttpContext.User.RetreiveEmailFromPrincipal();
            var tour = await _tourService.GetTourByIdAsync(tourId, userEmail); // Use the correct tourId parameter here
            if (tour == null)
            {
                return BadRequest("Tour not found or user not authorized.");
            }

            // Implement logic to check if the tour has status "Completed"
            if (tour.Status != TourStatus.Completed)
            {
                return BadRequest("Tour must be completed to leave ratings and comments.");
            }

            try
            {
                // Retrieve exhibit ratings and comments for the given tour
                var ratingsComments = await _repository.GetExhibitRatingsCommentsAsync(tourId);
                var ratingsCommentsDto = _mapper.Map<IEnumerable<ExhibitRatingCommentDto>>(ratingsComments);
                return Ok(ratingsCommentsDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

        [HttpPost("{exhibitId}")]
        public async Task<ActionResult<ExhibitRatingCommentDto>> AddRatingComment(int exhibitId, ExhibitRatingCommentDto ratingCommentDto, int tourId)
        {
            var userEmail = HttpContext.User.RetreiveEmailFromPrincipal();
            //ovo sam dodao naknadno + proveru
            var userId = HttpContext.User.RetreiveEmailFromPrincipal();
            //var selectedTourId = tourId;
            // Check if user information is available
            if (string.IsNullOrEmpty(userEmail) || string.IsNullOrEmpty(userId))
            {
                // User is not authenticated or user information is missing
                return Unauthorized("User authentication failed.");
            }

            // Check if the comment is null or empty
            if (string.IsNullOrEmpty(ratingCommentDto.Comment))
            {
                return BadRequest("Comment is required.");
            }

            var tour = await _tourService.GetTourByIdAsync(tourId, userEmail);
            if (tour == null)
            {
                return BadRequest("Tour not found or user not authorized.");
            }

            // Implement logic to check if the tour has status "Completed"
            if (tour.Status != TourStatus.Completed)
            {
                return BadRequest("Tour must be completed to leave ratings and comments.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //i ovo
            // Create the ExhibitRatingComment object and assign user information
            var ratingComment = _mapper.Map<ExhibitRatingComment>(ratingCommentDto);
            ratingComment.ExhibitsId = exhibitId;
            ratingComment.UserId = userId;
            ratingComment.TourId = tour.Id;


            try
            {
                // Add the ExhibitRatingComment to the repository
                await _repository.AddExhibitRatingCommentAsync(ratingComment);

                // Map the created ExhibitRatingComment back to DTO and return
                var ratingCommentToReturn = _mapper.Map<ExhibitRatingCommentDto>(ratingComment);
                //return CreatedAtRoute("GetRatingComment", new { exhibitId, userId }, ratingCommentToReturn);
                return Ok(ratingCommentToReturn);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

        [HttpPut("{exhibitId}")]
        public async Task<ActionResult> UpdateExhibitRatingComment(int exhibitId, ExhibitRatingCommentDto ratingCommentDto)
        {
            var existingRatingComment = await _repository.GetExhibitRatingCommentAsync(exhibitId, ratingCommentDto.UserId);
            if (existingRatingComment == null)
            {
                return NotFound("Exhibit rating and comment not found.");
            }

            existingRatingComment.Rating = ratingCommentDto.Rating;
            existingRatingComment.Comment = ratingCommentDto.Comment;

            await _repository.UpdateExhibitRatingCommentAsync(existingRatingComment);
            return Ok("Exhibit rating and comment updated successfully.");
        }

        [HttpDelete("{exhibitId}")]
        public async Task<ActionResult> DeleteRatingComment(int exhibitId)
        {
            var userEmail = HttpContext.User.RetreiveEmailFromPrincipal();
            var tour = await _tourService.GetTourByIdAsync(exhibitId, userEmail);
            if (tour == null)
            {
                return BadRequest("Tour not found or user not authorized.");
            }

            // Implement logic to check if the tour has status "Completed"
            if (tour.Status != TourStatus.Completed)
            {
                return BadRequest("Tour must be completed to delete ratings and comments.");
            }

            var existingRatingComment = await _repository.GetExhibitRatingCommentAsync(exhibitId, userEmail);
            if (existingRatingComment == null)
            {
                return NotFound("Rating/comment not found.");
            }

            try
            {
                await _repository.DeleteExhibitRatingCommentAsync(exhibitId, userEmail);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

        [HttpGet("comment/{exhibitId}")]
        public async Task<ActionResult<IEnumerable<CommentsDto>>> GetCommentsByExhibitId(int exhibitId)
        {
            try
            {
                var comments = await _repository.FindAllCommentsByExhibitId(exhibitId);
                var commentsDto = _mapper.Map<IEnumerable<CommentsDto>>(comments);
                if (commentsDto == null || !comments.Any())
                {
                    return NotFound(); // No comments found for the exhibitId
                }
                return Ok(commentsDto); // Return the found comments
            }
            catch (Exception ex)
            {
                // Log or handle the exception
                Console.WriteLine($"An error occurred while fetching comments: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }

}
