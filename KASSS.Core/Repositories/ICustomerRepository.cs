using KASSS.Core.DTOs.Customer;
using KASSS.Core.Models;
using KASSS.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace KASSS.Core.Repositories
{
    public interface ICustomerRepository 
    {
        Task<IEnumerable<Device>> GetAllCustomerPropertiesByCustomerIdAsync(int Id);
        Task<Response<CustomerDto>> GetByIdAsync(int id);
        Task<Response<IEnumerable<CustomerDto>>> GetAllAsync();
        Response<IEnumerable<CustomerDto>> Where(Expression<Func<Customer, bool>> predicate);
        Task<Response<CustomerDto>> AddAsync(CreateCustomerDto entity);
        Task<Response<NoDataDto>> Remove(int id);
        Task<Response<NoDataDto>> Update(CustomerDto entity, string id);
    }
}
