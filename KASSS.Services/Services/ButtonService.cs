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
    public class ButtonService<TDto> : Service<Button, TDto, TDto>, IButtonService<TDto> where TDto : class
    {
        public ButtonService(IUnitOfWork unitOfWork, IRepository<Button> genericRepository) : base(unitOfWork, genericRepository)
        {
        }
    }
}
