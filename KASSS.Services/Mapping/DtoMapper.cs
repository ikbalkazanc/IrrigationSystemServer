using AutoMapper;
using KASSS.Core.DTOs.Customer;
using KASSS.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KASSS.Services.Mapping
{
    internal class DtoMapper : Profile
    {
        public DtoMapper()
        {
            CreateMap<CustomerDto, Customer>().ReverseMap();
        }
    }
}
