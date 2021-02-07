using KASSS.Core.Models;
using KASSS.Core.Repositories;
using KASSS.Core.Services;
using KASSS.Core.UnitOfWork;
using KASSS.Services.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KASSS.Services.Services
{
    public class SliderService<TDto> : Service<Slider, TDto, TDto>, ISliderService<TDto> where TDto : class 
    {
        public SliderService(IUnitOfWork unitOfWork, IRepository<Slider> genericRepository) : base(unitOfWork, genericRepository)
        {
        }
    }
}
