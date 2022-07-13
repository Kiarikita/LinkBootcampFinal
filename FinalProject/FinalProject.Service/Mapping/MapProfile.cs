using AutoMapper;
using FinalProject.Core.DTOs;
using FinalProject.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Service.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Customer, CustomerDto>().ReverseMap();
            CreateMap<CommercialActivity, CommercialActivityDto>().ReverseMap();
        }
    }
}
