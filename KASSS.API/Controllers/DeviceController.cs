using KASSS.Core.DTOs.Device;
using KASSS.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KASSS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeviceController : CustomBaseController
    {
        private readonly IDeviceService<DeviceDto, DeviceDto> _deviceService;

        public DeviceController(IDeviceService<DeviceDto, DeviceDto> deviceService)
        {
            _deviceService = deviceService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return ActionResultInstance(await _deviceService.GetAllAsync());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return ActionResultInstance(await _deviceService.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create(DeviceDto createUserDto)
        {
            return ActionResultInstance(await _deviceService.AddAsync(createUserDto)); ;
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] DeviceDto updateDevice)
        {
            return ActionResultInstance(await _deviceService.Update(updateDevice, updateDevice.Id));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return ActionResultInstance(await _deviceService.Remove(id));
        }
    }
}
