using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RetoBackendBCP.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RetoBackendBCP.Data
{
    public class AddTestData
    {
        private readonly ApplicationDbContext context;

        public AddTestData(ApplicationDbContext context)
        {
            this.context = context;
        }
        public static void InsertTestData(IServiceProvider serviceProvider)
        {
            using var context = new ApplicationDbContext(
                      serviceProvider
                      .GetRequiredService<DbContextOptions<ApplicationDbContext>>());

            if (context.Divisas.Any()) { return; }

            var insert = new List<Divisa>
            {
                new Divisa{ Id = 1, MonedaOrigen = "PEN", MonedaDestino ="USD",TipoCambio =0.27m },
                new Divisa{ Id = 2, MonedaOrigen = "USD" ,MonedaDestino ="PEN",TipoCambio =3.77m },
                new Divisa{ Id = 3, MonedaOrigen = "PEN", MonedaDestino ="EUR",TipoCambio =0.24m },
                new Divisa{ Id = 4, MonedaOrigen = "EUR" ,MonedaDestino ="PEN",TipoCambio =4.11m },
                new Divisa{ Id = 5, MonedaOrigen = "PEN", MonedaDestino ="JPY",TipoCambio =32.70m },
                new Divisa{ Id = 6, MonedaOrigen = "JPY" ,MonedaDestino ="PEN",TipoCambio =0.03m },
                new Divisa{ Id = 7, MonedaOrigen = "PEN", MonedaDestino ="BRL",TipoCambio =1.27m },
                new Divisa{ Id = 8, MonedaOrigen = "BRL" ,MonedaDestino ="PEN",TipoCambio =0.79m },
            };

           context.Divisas.AddRange(insert);
           context.SaveChanges();

        }
    }
}
