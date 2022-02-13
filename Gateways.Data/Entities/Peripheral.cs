using Gateways.Ground;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gateways.Data.Entities
{
    public class Peripheral
    {
        public int UID { get; set; }
        public string Vendor { get; set; }
        public DateTime CreateAt { get; set; }
        public PeripheralStatus Status { get; set; }
        public string GatewaySerialNumber { get; set; }
        public virtual Gateway Gateway { get; set; }
    }
}
