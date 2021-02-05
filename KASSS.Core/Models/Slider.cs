using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KASSS.Core.Models
{
    public class Slider
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [ForeignKey("Device")]
        public int DeviceId { get; set; }
        public Device Device { get; set; }
    }
}
