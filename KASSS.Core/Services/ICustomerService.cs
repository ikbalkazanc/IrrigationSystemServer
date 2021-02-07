using KASSS.Core.DTOs.Customer;
using KASSS.Core.Models;
using KASSS.Core.Services.Common;
using KASSS.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace KASSS.Core.Services
{
    public interface ICustomerService<TDto,TCreateDto> where TDto : class where TCreateDto : class
    {
        Task<Response<TDto>> CreateUserAsync(TCreateDto createUserDto);
        Task<Response<TDto>> GetUserByMailAsync(string mail);
        Task<IEnumerable<Device>> GetAllCustomerPropertiesByCustomerIdAsync(int Id);
        Task<Response<TDto>> GetByIdAsync(int id);
        Task<Response<IEnumerable<TDto>>> GetAllAsync();
        Response<IEnumerable<TDto>> Where(Expression<Func<TDto, bool>> predicate);
        Task<Response<TDto>> AddAsync(TCreateDto entity);
        Task<Response<NoDataDto>> Remove(string id);
        Task<Response<NoDataDto>> Update(TDto entity, int id);

    }
}
