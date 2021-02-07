using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KASSS.Core.DTOs.Location
{
    public class LocationDto
    {
        public int Id { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public int DeviceId { get; set; }
    }
}
