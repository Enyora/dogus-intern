using System.Collections.Generic;
using System.Threading.Tasks;
using VideoGamesWeb.Data.Entities;

namespace VideoGamesWeb.Data.Repositories
{
    public interface IVideoGamesRepository
    {
        Task<List<VideoGame>> GetGamesAsync();
    }
}
