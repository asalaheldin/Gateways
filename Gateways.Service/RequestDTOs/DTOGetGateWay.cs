using System;
using System.Collections.Generic;
using System.Text;

namespace Gateways.Service.RequestDTOs
{
    public class DTOGetGateWay
    {
        public string SerialNumber { get; set; }
        public string Name { get; set; }
        public string IPv4 { get; set; }
        public List<DTOGetPeripheral> AssociatedPeripherals { get; set; }
    }
    
}

