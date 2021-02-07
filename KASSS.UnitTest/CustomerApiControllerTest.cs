using KASSS.API.Controllers;
using KASSS.Core.DTOs.Customer;
using KASSS.Core.Models;
using KASSS.Core.Repositories;
using KASSS.Core.Services;
using KASSS.Shared.DTOs;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace KASSS.UnitTest
{
    public class CustomerApiControllerTest
    {
        private List<CustomerDto> customers;
        private readonly CustomersController _controller;
        private readonly Mock<ICustomerService<CustomerDto, CreateCustomerDto>> _mockService;
        public CustomerApiControllerTest()
        {
            _mockService = new Mock<ICustomerService<CustomerDto, CreateCustomerDto>>();
            _controller = new CustomersController(_mockService.Object);
            customers = new List<CustomerDto>() { new CustomerDto { Id = "ses", UserName = "Ali",Email="Mail1" }, new CustomerDto { Id = "ses2", UserName = "Ali2",Email="Mail2" } };
        }
        [Fact]
        public async void GetCustomers_ActionExecutes_ReturnResultWithCustomersDto()
        {
            _mockService.Setup(x => x.GetAllAsync()).ReturnsAsync(Response<IEnumerable<CustomerDto>>.Success(customers,200));
            var result = await _controller.GetAll();
            Assert.IsType<ObjectResult>(result);
        }
        [Theory]
        [InlineData("Mail1")]
        public async void GetCustomersByMail_ActionExecutes_ReturnResultWithCustomerDto(string mail)
        {
            _mockService.Setup(x => x.GetUserByMailAsync(mail)).ReturnsAsync(Response<CustomerDto>.Success(customers.Find(x=>x.Email == mail), 200));
            var result = await _controller.GetByMail(mail);
            Assert.IsType<ObjectResult>(result);
        }
        [Fact]
        public async void CreateUser_ActionExecutes_ReturnResultWithCustomerDto()
        {
            CreateCustomerDto newCustomer = new CreateCustomerDto() {Email="mail3",UserName="Halil",Password="55422" }; 
            _mockService.Setup(x => x.CreateUserAsync(newCustomer)).ReturnsAsync(Response<CustomerDto>.Success(customers.Find(x => x.Id == "ses"), 200));
            var result = await _controller.Create(newCustomer);
            Assert.IsType<ObjectResult>(result);
        }
        [Fact]
        public async void UpdateUser_ActionExecutes_ReturnResultWithCustomerDto()
        {
            CustomerDto updatedUser = customers.Find(x=>x.Id == "ses");
            _mockService.Setup(x => x.Update(updatedUser,1)).ReturnsAsync(Response<NoDataDto>.Success(200));
            var result = await _controller.Update(updatedUser);
            Assert.IsType<ObjectResult>(result);
        }
        [Theory]
        [InlineData("Mail1")]
        public async void DeleteUser_ActionExecutes_ReturnResultWithCustomerDto(string id)
        {
            CustomerDto updatedUser = customers.Find(x => x.Id == "ses");
            _mockService.Setup(x => x.Update(updatedUser, 1)).ReturnsAsync(Response<NoDataDto>.Success(200));
            var result = await _controller.Update(updatedUser);
            Assert.IsType<ObjectResult>(result);
        }
    }
}
