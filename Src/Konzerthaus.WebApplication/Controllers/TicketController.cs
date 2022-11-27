using Konzerthaus.WebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.Extensions.Logging;
using Konzerthaus.Application;
using Konzerthaus.Domain.Model;

namespace Konzerthaus.WebApplication.Controllers
{
    public class TicketController : Controller
    {
        private readonly TicketService _ticketService;

        public TicketController(TicketService ticketService)
        {
            _ticketService = ticketService;
        }

        public IActionResult Index()
        {
            List<Ticket> tickets = _ticketService.ListAllTickets();
            return View(tickets);
        }
    }
}
