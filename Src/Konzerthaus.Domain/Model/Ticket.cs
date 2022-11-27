using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konzerthaus.Domain.Model
{
    public class Ticket : BaseEntity
    {
        public virtual Performance Performance { get; private set; }
        public virtual Spectator Spectator { get; private set; }

        public int PerformanceId { get; internal set; }
        public int SpectatorId { get; internal set; }
        public decimal PriceId { get; set; }
        public object Price { get; internal set; }

        public Ticket(Performance performance, Spectator spectator)
        {
            Performance = performance;
            Spectator = spectator;
        }


        protected Ticket()
        { }

    }
}
