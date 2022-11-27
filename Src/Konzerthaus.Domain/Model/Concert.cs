using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konzerthaus.Domain.Model
{
    public class Concert
    {
       // public enum ConcertType { Classic = 0, Jaz = 1, Pop = 2, Rock = 3, Blus = 4 }
        public int Id { get; set; }
        public string Name { get; set; }
        //public ConcertType Concerttype { get; set; }
        public int Seat { get; set; }

        public Concert(string name,  int seat)
        {
            
            Name = name;
            //Concerttype = concerttype;
            Seat = seat;
        }

        protected Concert()
        {

        }
    }
}
