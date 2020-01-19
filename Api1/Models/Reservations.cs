using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoodtimeApi.Models
{
    public class Reservations
    {
        public Reservations()
        {
            waiting = new List<Reservation>();
            accepted = new List<Reservation>();
            denied = new List<Reservation>();
        }

        public List<Reservation> waiting;
        public List<Reservation> accepted;
        public List<Reservation> denied;
    }
}
