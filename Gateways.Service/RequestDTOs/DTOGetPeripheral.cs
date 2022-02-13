using Gateways.Ground;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gateways.Service.RequestDTOs
{
    public class DTOGetPeripheral
    {
        public int UID { get; set; }
        public string Vendor { get; set; }
        public PeripheralStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
