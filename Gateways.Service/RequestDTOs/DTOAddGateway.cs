using System;
using System.Collections.Generic;
using System.Text;

namespace Gateways.Service.RequestDTOs
{
    public class DTOAddGateway
    {
        public string SerialNumber { get; set; }
        public string Name { get; set; }
        public string IPv4 { get; set; }
        public List<DTOAddPeripheral> AssociatedPeripherals { get; set; }
    }
}
