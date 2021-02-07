using KASSS.Core.Models;
using KASSS.Core.Services.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KASSS.Core.Services
{
    public interface ISliderService<TDto> : IService<Slider, TDto, TDto> where TDto : class
    {
    }
}
