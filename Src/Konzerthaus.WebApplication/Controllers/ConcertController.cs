using Konzerthaus.WebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.Extensions.Logging;
using Konzerthaus.Application;
using Konzerthaus.Domain.Model;

namespace Konzerthaus.WebApplication.Controllers
{

        public class ConcertController : Controller
        {
            private readonly ConcertService _concertService;

            public ConcertController(ConcertService concertService)
            {
                _concertService = concertService;
            }

            public IActionResult Index()
            {
                List<Concert> concerts = _concertService.ListAllConcerts();
                return View(concerts);
            }
        }
    
}
