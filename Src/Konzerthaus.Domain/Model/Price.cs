using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konzerthaus.Domain.Model
{
    public class Price : BaseEntity
    {
        protected Price() { }

        public Price(decimal nett, int tax, string category, Performance performance)
        {
            Nett = nett;
            Tax = tax;
            Category = category;
            PerformanceNavigation = performance;

        }

        public virtual Performance PerformanceNavigation { get; private set; } 

        public string Category { get; set; }
        public decimal Nett { get; set; }
        public int Tax { get; set; }
        public decimal Gross { get { return Nett * ((Tax / 100) + 1); } }

    }
}
