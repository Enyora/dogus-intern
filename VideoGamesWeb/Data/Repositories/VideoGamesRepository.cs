using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using VideoGamesWeb.Data.Entities;

namespace VideoGamesWeb.Data.Repositories
{
    public class VideoGamesRepository : IVideoGamesRepository
    {
        private readonly VideoGamesDbContext _context;

        public VideoGamesRepository(VideoGamesDbContext context)
        {
            _context = context;
        }

        public async Task<List<VideoGame>> GetGamesAsync()
        {
            return await _context.VideoGames.ToListAsync();

        }
    }
}
