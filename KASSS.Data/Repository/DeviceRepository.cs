using KASSS.Core.Models;
using KASSS.Core.Repositories;
using KASSS.Data.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KASSS.Data.Repository
{
    public class DeviceRepository : Repository<Device>, IDeviceRepository
    {
        private AppDbContext appDbContext { get => _context as AppDbContext; }
        public DeviceRepository(AppDbContext context) : base(context)
        {
        }
        public Task<IEnumerable<Device>> GetAllPropertiesOfDeviceByDeviceIdAsync(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
