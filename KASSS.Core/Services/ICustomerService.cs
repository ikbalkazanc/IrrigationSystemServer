using KASSS.Core.DTOs.Customer;
using KASSS.Core.Models;
using KASSS.Core.Services.Common;
using KASSS.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KASSS.Core.Services
{
    public interface ICustomerService<TDto> : IService<Customer,TDto> where TDto : class
    {
        Task<Response<TDto>> CreateUserAsync(CreateCustomerDto createUserDto);
        Task<Response<TDto>> GetUserByMailAsync(string mail);
        Task<IEnumerable<Device>> GetAllCustomerPropertiesByCustomerIdAsync(int Id);

    }
}
