using Konzerthaus.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Konzerthaus.Domain.Model;


namespace Konzerthaus.Application
{
    public class TicketService
    {
        private readonly Context _dbContext;

        public TicketService(Context dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Ticket> ListAllTickets()
        {
            return _dbContext.Tickets.ToList();//Include(p => p.Performance).Include(s => s.Spectator).ToList();
        }
    }
}
