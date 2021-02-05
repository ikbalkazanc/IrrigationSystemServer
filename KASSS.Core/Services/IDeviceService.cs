using KASSS.Core.Models;
using KASSS.Core.Services.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KASSS.Core.Services
{
    public interface IDeviceService<TDto> : IService<Device,TDto> where TDto : class
    {
        Task<IEnumerable<Device>> GetAllPropertiesOfDeviceByDeviceIdAsync(int Id);
    }
}
