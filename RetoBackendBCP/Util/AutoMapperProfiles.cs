using AutoMapper;
using RetoBackendBCP.Entity.DTO;
using RetoBackendBCP.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetoBackendBCP.Util
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Divisa, DivisaRequest>().ReverseMap();
            CreateMap<Divisa, DivisaResponse>().ReverseMap();
            CreateMap<Divisa, UpdateRequest>().ReverseMap();
        }
    }
}
