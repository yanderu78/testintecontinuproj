using System;
using GoodtimeApi.Models;
using Swashbuckle.AspNetCore.Filters;

namespace GoodtimeApi.SwaggerExamples
{
    public class BarResponseExample : IExamplesProvider
    {
        public object GetExamples()
        {
            return new Bar
            {
                id = new Random().Next(),
                name = "test name",
                phone = "0123456789",
                lat = float.Parse("3572"),
                lon = float.Parse("3572"),
                cheaper_pint = float.Parse("3,5"),
                adress = "52 rue margoulin 75016 Paris"
            };
        }
    }
}