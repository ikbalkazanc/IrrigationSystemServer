using KASSS.API.Controllers;
using KASSS.Core.DTOs.Device;
using KASSS.Core.Services;
using KASSS.Shared.DTOs;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace KASSS.UnitTest
{
    public class DeviceApiControllerTest
    {
        private List<DeviceDto> customers;
        private readonly DeviceController _controller;
        private readonly Mock<IDeviceService<DeviceDto, DeviceDto>> _mockService;
        public DeviceApiControllerTest()
        {
            _mockService = new Mock<IDeviceService<DeviceDto, DeviceDto>>();
            _controller = new DeviceController(_mockService.Object);
            customers = new List<DeviceDto>() { new DeviceDto { Id =1,CustomerId=1  }, new DeviceDto { Id = 2, CustomerId = 1 } };
        }
        [Fact]
        public async void GetDevices_ActionExecutes_ReturnResultWithCustomersDto()
        {
            _mockService.Setup(x => x.GetAllAsync()).ReturnsAsync(Response<IEnumerable<DeviceDto>>.Success(customers, 200));
            var result = await _controller.GetAll();
            Assert.IsType<ObjectResult>(result);
        }
        [Theory]
        [InlineData(1)]
        public async void GetDeviceByMail_ActionExecutes_ReturnResultWithDeviceDto(int id)
        {
            _mockService.Setup(x => x.GetByIdAsync(id)).ReturnsAsync(Response<DeviceDto>.Success(customers.Find(x => x.Id == id), 200));
            var result = await _controller.GetById(id);
            Assert.IsType<ObjectResult>(result);
        }
        [Fact]
        public async void CreateUser_ActionExecutes_ReturnResultWithDeviceDto()
        {
            DeviceDto newCustomer = new DeviceDto() { Id = 3, CustomerId = 1 };
            _mockService.Setup(x => x.AddAsync(newCustomer)).ReturnsAsync(Response<DeviceDto>.Success(customers.Find(x => x.Id == 1), 200));
            var result = await _controller.Create(newCustomer);
            Assert.IsType<ObjectResult>(result);
        }
        [Fact]
        public async void UpdateDevice_ActionExecutes_ReturnResultWithDeviceDto()
        {
            DeviceDto updatedUser = customers.Find(x => x.Id == 1);
            _mockService.Setup(x => x.Update(updatedUser, 1)).ReturnsAsync(Response<NoDataDto>.Success(200));
            var result = await _controller.Update(updatedUser);
            Assert.IsType<ObjectResult>(result);
        }
        [Theory]
        [InlineData(1)]
        public async void DeleteDevice_ActionExecutes_ReturnResultWithDeviceDto(int id)
        {
            DeviceDto updatedUser = customers.Find(x => x.Id == id);
            _mockService.Setup(x => x.Update(updatedUser, id)).ReturnsAsync(Response<NoDataDto>.Success(200));
            var result = await _controller.Update(updatedUser);
            Assert.IsType<ObjectResult>(result);
        }
    }
}
