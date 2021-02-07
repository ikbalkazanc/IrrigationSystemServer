using KASSS.Core.Models;
using KASSS.Core.Services.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KASSS.Core.Services
{
    public interface IButtonService<TDto> : IService<Button, TDto, TDto> where TDto : class
    {
    }
}
