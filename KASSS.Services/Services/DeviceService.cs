using KASSS.Core.Models;
using KASSS.Core.Repositories;
using KASSS.Core.Services;
using KASSS.Core.UnitOfWork;
using KASSS.Services.Service.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KASSS.Services.Service
{
    public class DeviceService<TDto, TCreateDto> : Service<Device, TDto, TCreateDto>, IDeviceService<TDto, TCreateDto> where TDto : class where TCreateDto : class
    {
        public DeviceService(IUnitOfWork unitOfWork, IRepository<Device> genericRepository) : base(unitOfWork, genericRepository)
        {
        }

        public Task<IEnumerable<Device>> GetAllPropertiesOfDeviceByDeviceIdAsync(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
