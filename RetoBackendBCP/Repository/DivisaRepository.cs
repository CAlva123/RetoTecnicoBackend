using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RetoBackendBCP.Data;
using RetoBackendBCP.Entity.DTO;
using RetoBackendBCP.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetoBackendBCP.Repository
{
    public class DivisaRepository
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public DivisaRepository(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<List<Divisa>> all()
        {
            var result = await context.Divisas.ToListAsync();
            var mapped = mapper.Map<List<Divisa>>(result);
            return mapped;
        }
        public async Task<DivisaResponse> find(DivisaRequest divisa)
        {
            var result = await context.Divisas.Where(x => x.MonedaOrigen == divisa.MonedaOrigen
            && x.MonedaDestino == divisa.MonedaDestino).FirstOrDefaultAsync();
            if (result == null)
                throw new Exception("No se tienen registros del cambio de divisas solicitado.");

            var mapped = mapper.Map<DivisaResponse>(result);
            mapped.MontoInicial = divisa.MontoInicial;
            mapped.MontoFinal = decimal.Round((mapped.MontoInicial * mapped.TipoCambio), 2, MidpointRounding.AwayFromZero).ToString("#.00", System.Globalization.CultureInfo.InvariantCulture); ;

            return mapped;
        }
        public async Task update(UpdateRequest request)
        {
            var result = (from p in context.Divisas
                          where p.MonedaOrigen == request.MonedaOrigen && p.MonedaDestino == request.MonedaDestino
                          select p).SingleOrDefault();

            if (result == null)
                throw new Exception("No se tienen registros de las divisas ingresadas.");

            result.TipoCambio = request.TipoCambio;

            await context.SaveChangesAsync();
        }
    }
}
