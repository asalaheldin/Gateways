using Gateways.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gateways.Data.CustomEntites
{
    public class GatewayListCount
    {
        public List<Gateway> Gateways { get; set; }
        public int Count { get; set; }
    }
}
