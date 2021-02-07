using KASSS.Core.DTOs.Button;
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
    public class ButtonController : CustomBaseController
    {
        private readonly IButtonService<ButtonDto> _userService;

        public ButtonController(IButtonService<ButtonDto> userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return ActionResultInstance(await _userService.GetAllAsync());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return ActionResultInstance(await _userService.GetByIdAsync(id));
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] ButtonDto updateButton)
        {
            return ActionResultInstance(await _userService.Update(updateButton,updateButton.Id));
        }
    }
}
