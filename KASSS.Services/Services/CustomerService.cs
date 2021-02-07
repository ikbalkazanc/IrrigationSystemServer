using KASSS.Core.DTOs.Customer;
using KASSS.Core.Models;
using KASSS.Core.Repositories;
using KASSS.Core.Services;
using KASSS.Core.UnitOfWork;
using KASSS.Services.Mapping;
using KASSS.Services.Service.Common;
using KASSS.Shared.DTOs;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace KASSS.Services.Service
{
    public class CustomerService<TDto,TCreateDto> :  ICustomerService<TDto, TCreateDto> where TDto : class where TCreateDto : class
    {
        private readonly UserManager<Customer> _userManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Customer> _genericRepository;
        public CustomerService(UserManager<Customer> userManager, IUnitOfWork unitofwork, IRepository<Customer> repository) 
        {
            _userManager = userManager;
            _unitOfWork = unitofwork;
            _genericRepository = repository;
        }

        public Task<Response<TDto>> AddAsync(TCreateDto entity)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<TDto>> CreateUserAsync(CreateCustomerDto createUserDto)
        {
            var user = new Customer { Email = createUserDto.Email, UserName = createUserDto.UserName };

            var result = await _userManager.CreateAsync(user, createUserDto.Password);

            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(x => x.Description).ToList();

                return Response<TDto>.Fail(new ErrorDto(errors, true), 400);
            }
            return Response<TDto>.Success(ObjectMapper.Mapper.Map<TDto>(user), 200);
        }

        public Task<Response<TDto>> CreateUserAsync(TCreateDto createUserDto)
        {
            throw new NotImplementedException();
        }

        public Task<Response<IEnumerable<TDto>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Device>> GetAllCustomerPropertiesByCustomerIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<Response<TDto>> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<TDto>> GetUserByMailAsync(string mail)
        {
            var user = await _userManager.FindByEmailAsync(mail);

            if (user == null)
            {
                return Response<TDto>.Fail("UserName not found", 404, true);
            }

            return Response<TDto>.Success(ObjectMapper.Mapper.Map<TDto>(user), 200);
        }

        public Task<Response<NoDataDto>> Remove(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Response<NoDataDto>> Update(TDto entity, int id)
        {
            throw new NotImplementedException();
        }

        public Response<IEnumerable<TDto>> Where(Expression<Func<TDto, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
