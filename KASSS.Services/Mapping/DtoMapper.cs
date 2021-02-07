using AutoMapper;
using KASSS.Core.DTOs.Button;
using KASSS.Core.DTOs.Customer;
using KASSS.Core.DTOs.Device;
using KASSS.Core.DTOs.Location;
using KASSS.Core.DTOs.Slider;
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
            CreateMap<CreateCustomerDto, Customer>().ReverseMap();

            CreateMap<DeviceDto, Device>().ReverseMap();

            CreateMap<Button, ButtonDto>().ReverseMap();

            CreateMap<Location, LocationDto>().ReverseMap();

            CreateMap<Slider, SliderDto>().ReverseMap();
        }
    }
}
