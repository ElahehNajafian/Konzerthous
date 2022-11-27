using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konzerthaus.Domain.Model
{
    public class Performance : BaseEntity
    {
        public virtual Saal Saal { get; private set; }
        public DateTime Datum { get; set; }
        public virtual Concert Concert { get; private set; }

        protected List<Price> _price = new(); 

        public virtual IReadOnlyList<Price> Price => _price;
        public void AddPrice(Price price)
        {
            if (price is not null)
            {
                _price.Add(price);
            }
        }

        public void AddPrice(List<Price> price)
        {
            _price.AddRange(price);
        }

        protected List<Singer> _singer = new(); 
        public virtual IReadOnlyList<Singer> Singer => _singer;  



        public int SaalId { get; internal set; }  
        public int ConcertId { get; internal set; }


        public Performance(Saal saal , DateTime datum, Concert concert)
        {
            Saal = saal;
            Datum = datum;
            Concert = concert;

        }
        //protected Performance(Saal.SaalType grossersaal)
        //{

        //}

        protected Performance()
        {
        }

        public void AddSinger(Singer singer)     
        {
            if (singer is not null)
            {

                _singer.Add(singer);
            }
        }

        public void AddSinger(List<Singer> singer)     
        {
            _singer.AddRange(singer);
        }

        public void RemoveSinger(Singer singer)
        {
            if (singer is not null)
            {
                _singer.Remove(singer);
            }

        }
    }

}

