using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konzerthaus.Domain.Model
{
    public class Saal : BaseEntity
    {
        //public enum SaalType { Grossersaal = 0, Mozartsaal = 1, Schubert = 2 }
        public string Name { get; set; }
        public int Seat { get; set; }
        //public SaalType SaalType { get; private set; }

        public Saal(string name , int seat)
        {
            Name = name;
            Seat = seat;

        }

        protected Saal()
        {

        }
    }

    
}
