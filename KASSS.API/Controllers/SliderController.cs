using KASSS.Core.DTOs.Slider;
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
    public class SliderController : CustomBaseController
    {
        private readonly ISliderService<SliderDto> _userService;

        public SliderController(ISliderService<SliderDto> userService)
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
        public async Task<IActionResult> Update([FromBody] SliderDto updateSlider)
        {
            return ActionResultInstance(await _userService.Update(updateSlider, 1));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return ActionResultInstance(await _userService.Remove(id));
        }
    }
}
