using System;
using System.Collections.Generic;
using GoodtimeApi.Models;
using Swashbuckle.AspNetCore.Filters;

namespace GoodtimeApi.SwaggerExamples
{
    public class MenuListResponseExample : IExamplesProvider
    {
        public object GetExamples()
        {
            return new List<MenuItem>
            {
                new MenuItem {
                id = new Random().Next(),
                name = "Pelforth pinte",
                price = float.Parse("5,5")
                },
                new MenuItem {
                id = new Random().Next(),
                name = "Tapas fromage",
                price = float.Parse("7,2")
                },
                new MenuItem {
                id = new Random().Next(),
                name = "Soda",
                price = float.Parse("2,00")
                },
                new MenuItem {
                id = new Random().Next(),
                name = "Jules de Suavez (Bouteille de vin rouge)",
                price = float.Parse("15,8")
                }
            };
        }
    }
}