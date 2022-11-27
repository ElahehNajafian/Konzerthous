using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konzerthaus.Domain.Model
{
    public class Singer : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime GebDat { get; set; }

        public virtual Performance PerformanceNavigation { get; private set; } 

        public Singer(string firstName, string lastName, DateTime gebDat, Performance performance)
        {
            FirstName = firstName;
            LastName = lastName;
            GebDat = gebDat;
            PerformanceNavigation = performance;
        }

        protected Singer()
        {
        }

        //internal static void AddRange(List<Singer> singers)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
