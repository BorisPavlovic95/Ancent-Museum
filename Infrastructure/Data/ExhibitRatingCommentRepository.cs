using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Infrastructure.Data
{
    public class ExhibitRatingCommentRepository : IExhibitRatingCommentRepository
    {
        private readonly MuseumContext _context;

        public ExhibitRatingCommentRepository(MuseumContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ExhibitRatingComment>> GetExhibitRatingsCommentsAsync(int exhibitId)
        {
            return await _context.ExhibitRatingComments
                .Where(e => e.ExhibitsId == exhibitId)
                .ToListAsync();
        }

        public async Task<ExhibitRatingComment> GetExhibitRatingCommentAsync(int exhibitId, string userId)
        {
            return await _context.ExhibitRatingComments
                .FirstOrDefaultAsync(e => e.ExhibitsId == exhibitId && e.UserId == userId);
        }


        public async Task AddExhibitRatingCommentAsync(ExhibitRatingComment ratingComment)
        {
            _context.ExhibitRatingComments.Add(ratingComment);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateExhibitRatingCommentAsync(ExhibitRatingComment ratingComment)
        {
            _context.ExhibitRatingComments.Update(ratingComment);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteExhibitRatingCommentAsync(int exhibitId, string userId)
        {
            var ratingComment = await _context.ExhibitRatingComments
                .FirstOrDefaultAsync(e => e.ExhibitsId == exhibitId && e.UserId == userId);

            if (ratingComment != null)
            {
                _context.ExhibitRatingComments.Remove(ratingComment);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<ExhibitRatingComment>> FindAllCommentsByExhibitId(int exhibitId)
        {
            try
            {
                // Retrieve all comments for the given exhibitId
                var comments = await _context.ExhibitRatingComments
                    .Where(comment => comment.ExhibitsId == exhibitId)
                    .ToListAsync();

                return comments;
            }
            catch (Exception ex)
            {
                // Handle any exceptions
                Console.WriteLine($"An error occurred while fetching comments: {ex.Message}");
                throw; // You can choose to handle or log the exception based on your requirements
            }
        }

    }
}
