using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KASSS.Core.Models
{
    public class Location
    {
        public int Id { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        [ForeignKey("Device")]
        public int DeviceId { get; set; }
        public Device Device { get; set; }

    }
}
