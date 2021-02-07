using KASSS.Core.DTOs.Customer;
using KASSS.Core.Services;
using Microsoft.AspNetCore.Authorization;
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
    public class CustomersController : CustomBaseController
    {
        private readonly ICustomerService<CustomerDto,CreateCustomerDto> _userService;

        public CustomersController(ICustomerService<CustomerDto, CreateCustomerDto> userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return ActionResultInstance(await _userService.GetAllAsync());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByMail(string mail)
        {
            return ActionResultInstance(await _userService.GetUserByMailAsync(mail));
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Create(CreateCustomerDto createUserDto)
        {
            return ActionResultInstance(await _userService.CreateUserAsync(createUserDto));
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] CustomerDto updateUser)
        {
            return ActionResultInstance(await _userService.Update(updateUser,1));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            return ActionResultInstance(await _userService.Remove(id));
        }
    }
}
