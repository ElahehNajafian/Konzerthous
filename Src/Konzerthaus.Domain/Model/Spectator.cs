using System;
using System.Collections.Generic;
using System.Linq;
using Konzerthaus.Domain.Model;
using System.Threading.Tasks;

namespace Konzerthaus.Domain.Model
{
    public class Spectator : BaseEntity
    {
        public enum GenderTypes { NA = 0, FEMALE = 1, MALE = 2 }

        protected Spectator() { }

        public GenderTypes Gender { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EMail { get; set; }
        public Address Address { get; set; }  
        public string Phone { get; set; }
        public Spectator(GenderTypes gender, string firstName, string lastName, string eMail, Address address, string phone)  
        {
            Gender = gender;
            FirstName = firstName;
            LastName = lastName;
            EMail = eMail;
            Address = address;
            Phone = phone;
        }

        //internal static void AddRange(List<Spectator> spectators)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
