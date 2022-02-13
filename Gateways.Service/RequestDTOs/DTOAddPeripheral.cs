using Gateways.Ground;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gateways.Service.RequestDTOs
{
    public class DTOAddPeripheral
    {
        public string Vendor { get; set; }
        public PeripheralStatus Status { get; set; }
    }
    public class DTOAddPeripheralWithGatewaySerialNumber : DTOAddPeripheral
    {
        public string SerialNumber { get; set; }
    }

    public class DTODeletePeripheralWithSerialNumber
    {
        public string SerialNumber { get; set; }
        public int UID { get; set; }
    }
}
