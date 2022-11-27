using Konzerthaus.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Konzerthaus.Domain.Model;

namespace Konzerthaus.Application
{
    public class ConcertService
    {
        private readonly Context _dbContext;

        public ConcertService(Context dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Concert> ListAllConcerts()
        {
            return _dbContext.Concerts.ToList();
        }
    }
}
