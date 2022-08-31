using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using VideoGamesWeb.Data.Repositories;
using VideoGamesWeb.Models;

namespace VideoGamesWeb.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class VideoGamesController : Controller
    {
        private readonly IVideoGamesRepository _videoGamesRepository;

        public VideoGamesController(IVideoGamesRepository videoGamesRepository)
        {
            _videoGamesRepository = videoGamesRepository;
        }
        [HttpGet]
        public async Task<IActionResult> Index()

        {
            var vgames = await _videoGamesRepository.GetGamesAsync();

            return View(vgames);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
