using KASSS.API.Controllers;
using KASSS.Core.DTOs.Button;
using KASSS.Core.DTOs.Slider;
using KASSS.Core.Services;
using KASSS.Shared.DTOs;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace KASSS.UnitTest
{
    public class SliderAndButtonApiControllerTest
    {
        private List<ButtonDto> Buttons;
        private List<SliderDto> Sliders;

        private readonly SliderController _sliderController;
        private readonly ButtonController _buttonController;

        private readonly Mock<IButtonService<ButtonDto>> _mockButtonService;
        private readonly Mock<ISliderService<SliderDto>> _mockSliderService;
        public SliderAndButtonApiControllerTest()
        {
            _mockButtonService = new Mock<IButtonService<ButtonDto>>();
            _mockSliderService = new Mock<ISliderService<SliderDto>>();

            _sliderController = new SliderController(_mockSliderService.Object);
            _buttonController = new ButtonController(_mockButtonService.Object);

            Buttons = new List<ButtonDto>() { new ButtonDto {  Id=1}, new ButtonDto { Id=2 } };
            Sliders = new List<SliderDto>() { new SliderDto { Id=1}, new SliderDto {Id=2 } };
        }
        [Fact]
        public async void GetDevices_ActionExecutes_ReturnResultWithCustomersDto()
        {
            _mockSliderService.Setup(x => x.GetAllAsync()).ReturnsAsync(Response<IEnumerable<SliderDto>>.Success(Sliders, 200));
            var result = await _sliderController.GetAll();
            Assert.IsType<ObjectResult>(result);

            _mockButtonService.Setup(x => x.GetAllAsync()).ReturnsAsync(Response<IEnumerable<ButtonDto>>.Success(Buttons, 200));
            var resultButton = await _buttonController.GetAll();
            Assert.IsType<ObjectResult>(result);
        }
        [Theory]
        [InlineData(1)]
        public async void GetDeviceByMail_ActionExecutes_ReturnResultWithDeviceDto(int id)
        {
            _mockSliderService.Setup(x => x.GetByIdAsync(id)).ReturnsAsync(Response<SliderDto>.Success(Sliders.Find(x => x.Id == id), 200));
            var result = await _sliderController.GetById(id);
            Assert.IsType<ObjectResult>(result);

            _mockButtonService.Setup(x => x.GetByIdAsync(id)).ReturnsAsync(Response<ButtonDto>.Success(Buttons.Find(x => x.Id == id), 200));
            var resultButton = await _buttonController.GetById(id);
            Assert.IsType<ObjectResult>(resultButton);
        }
        [Fact]
        public async void UpdateDevice_ActionExecutes_ReturnResultWithDeviceDto()
        {
            SliderDto deletedData = Sliders.Find(x => x.Id == 1);
            _mockSliderService.Setup(x => x.Update(deletedData, 1)).ReturnsAsync(Response<NoDataDto>.Success(200));
            var result = await _sliderController.Update(deletedData);
            Assert.IsType<ObjectResult>(result);

            ButtonDto deletedButtonData = Buttons.Find(x => x.Id == 1);
            _mockButtonService.Setup(x => x.Update(deletedButtonData, 1)).ReturnsAsync(Response<NoDataDto>.Success(200));
            var resultButton = await _buttonController.Update(deletedButtonData);
            Assert.IsType<ObjectResult>(resultButton);
        }
        [Theory]
        [InlineData(1)]
        public async void DeleteDevice_ActionExecutes_ReturnResultWithDeviceDto(int id)
        {
            SliderDto deletedData = Sliders.Find(x => x.Id == id);
            _mockSliderService.Setup(x => x.Update(deletedData, id)).ReturnsAsync(Response<NoDataDto>.Success(200));
            var result = await _sliderController.Update(deletedData);
            Assert.IsType<ObjectResult>(result);

            ButtonDto deletedButtonData = Buttons.Find(x => x.Id == id);
            _mockButtonService.Setup(x => x.Update(deletedButtonData, id)).ReturnsAsync(Response<NoDataDto>.Success(200));
            var resultButton = await _buttonController.Update(deletedButtonData);
            Assert.IsType<ObjectResult>(resultButton);
        }
    }
}
