using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoodtimeApi.Models
{
    public class BarPro : Bar
    {
        public bool hasNewReservations { get
            {
                return reservations.waiting.Count == 0? false : true;
            }}
        public Reservations reservations;
    }
}
