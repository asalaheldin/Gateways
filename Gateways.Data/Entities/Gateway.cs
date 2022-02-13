using System;
using System.Collections.Generic;
using System.Text;

namespace Gateways.Data.Entities
{
    public class Gateway
    {
        public string SerialNumber { get; set; }
        public string Name { get; set; }
        public string IPv4 { get; set; }
        public virtual ICollection<Peripheral> AssociatedPeripherals { get; set; }
    }
}
