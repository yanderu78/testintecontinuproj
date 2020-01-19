using System;
using System.Collections.Generic;
using GoodtimeApi.Models;
using Swashbuckle.AspNetCore.Filters;

namespace GoodtimeApi.SwaggerExamples
{
    public class BarListResponseExample : IExamplesProvider
    {
        public object GetExamples()
        {
            return new List<Bar>
            {
                new Bar {
                id = new Random().Next(),
                name = "Le Moonshiner",
                phone = "0123456789",
                lat = float.Parse("3572,2"),
                lon = float.Parse("3572,1"),
                cheaper_pint = float.Parse("3,5"),
                adress = "52 rue margoulin 75016 Paris"
                },
                new Bar {
                id = new Random().Next(),
                name = "Francis's place",
                phone = "0987654321",
                lat = float.Parse("3412,9"),
                lon = float.Parse("2712,2"),
                cheaper_pint = float.Parse("4,5"),
                adress = "59 rue bargon 75012 Paris"
                }
            };
        }
    }
}