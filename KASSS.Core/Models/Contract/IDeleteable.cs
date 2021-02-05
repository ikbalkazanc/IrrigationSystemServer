using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KASSS.Core.Models.Contract
{
    public interface IDeleteable
    {
        public bool isDeleted { get; set; }
        public DateTime DeleteTime { get; set; }
    }
}
