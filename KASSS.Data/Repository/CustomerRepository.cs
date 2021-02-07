using KASSS.Core.DTOs.Customer;
using KASSS.Core.Models;
using KASSS.Core.Repositories;
using KASSS.Data.Repository.Common;
using KASSS.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace KASSS.Data.Repository
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        private AppDbContext appDbContext { get => _context as AppDbContext; }
        public CustomerRepository(AppDbContext context) : base(context)
        {
        }
        public Task<IEnumerable<Device>> GetAllCustomerPropertiesByCustomerIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        Task<Response<CustomerDto>> ICustomerRepository.GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<Response<IEnumerable<CustomerDto>>> ICustomerRepository.GetAllAsync()
        {
            throw new NotImplementedException();
        }

        Response<IEnumerable<CustomerDto>> ICustomerRepository.Where(Expression<Func<Customer, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<Response<CustomerDto>> AddAsync(CreateCustomerDto entity)
        {
            throw new NotImplementedException();
        }

        public Task<Response<NoDataDto>> Remove(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Response<NoDataDto>> Update(CustomerDto entity, string id)
        {
            throw new NotImplementedException();
        }
    }
}
