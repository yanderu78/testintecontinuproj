using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoodtimeApi.Models
{
    public class Reservation
    {
        public int id;
        public string name;
        public string number;
        public string email;
        public int nb_persons;
        public DateTime date;
    }
}
