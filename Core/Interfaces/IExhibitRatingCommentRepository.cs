using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Core.Interfaces
{
    public interface IExhibitRatingCommentRepository
    {
        Task<IEnumerable<ExhibitRatingComment>> GetExhibitRatingsCommentsAsync(int exhibitId);
        Task<ExhibitRatingComment> GetExhibitRatingCommentAsync(int exhibitId, string userId);
        Task AddExhibitRatingCommentAsync(ExhibitRatingComment ratingCommentDto);
        Task UpdateExhibitRatingCommentAsync(ExhibitRatingComment ratingCommentDto);
        Task DeleteExhibitRatingCommentAsync(int exhibitId, string userId);
        Task<IEnumerable<ExhibitRatingComment>> FindAllCommentsByExhibitId(int exhibitId);

    }
}
