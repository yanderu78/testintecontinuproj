using GoodtimeApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoodtimeApi.SwaggerExamples
{
    public class ReservationsResponseExemple : IExamplesProvider
    {

        public object GetExamples()
        {
            Reservations res = new Reservations();
            res.accepted.Add(new Reservation
            {
                id = new Random().Next(),
                name = "John Johns",
                number = "0987456123",
                email = "jj@jjmail.com",
                nb_persons = 10,
                date = DateTime.ParseExact("2019-07-25T19:00", "yyyy-MM-ddTHH:mm", null)
            });
            res.accepted.Add(new Reservation
            {
                id = new Random().Next(),
                name = "Jessica Johns",
                number = "0987456123",
                email = "jj@hellskitchen.ny",
                nb_persons = 4,
                date = DateTime.ParseExact("2019-07-28T20:00", "yyyy-MM-ddTHH:mm", null)
            });
            res.waiting.Add(new Reservation
            {
                id = new Random().Next(),
                name = "Johnny jess",
                number = "0111111111",
                email = "jjns@jjmail.com",
                nb_persons = 5,
                date = DateTime.ParseExact("2019-08-15T21:30", "yyyy-MM-ddTHH:mm", null)
            });
            res.denied.Add(new Reservation
            {
                id = new Random().Next(),
                name = "Sauron",
                number = "0666666666",
                email = "monstre@lodr.nz",
                nb_persons = 666,
                date = DateTime.ParseExact("2019-07-15T15:00", "yyyy-MM-ddTHH:mm", null)
            });
            res.denied.Add(new Reservation
            {
                id = new Random().Next(),
                name = "Palpatine",
                number = "0999999999",
                email = "palpatheboss@starmail.ds",
                nb_persons = 2,
                date = DateTime.ParseExact("2019-07-22T23:45", "yyyy-MM-ddTHH:mm", null)
            });
            return res;
        }
    }
}
