using KASSS.Core.Models.Contract;
using System;
using System.Collections.Generic;

namespace KASSS.Core.Models
{
    public class Device : IDeleteable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CustomerId { get; set; }
        public ICollection<Button> Buttons { get; set; }
        public ICollection<Slider> Sliders { get; set; }
        public Location Location { get; set; }
        public bool isDeleted { get; set; }
        public DateTime DeleteTime { get; set; }
    }
}
