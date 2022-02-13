using Gateways.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gateways.Presistance.DBContext
{
    public class GatewaysContextSeed
    {
        public static void Initialize(GatewaysContext context)
        {
            if (context.Gateways.Any())
            {
                return; //Db has been already seeded
            }
            SeedData(context);
        }
        public static void SeedData(GatewaysContext context)
        {
            var createDate = DateTime.UtcNow;
            var data = new List<Gateway>()
            {
                new Gateway(){
                SerialNumber = "G1",
                Name = "Gateway1",
                IPv4 = "127.0.0.1",
                AssociatedPeripherals = new List<Peripheral>(){
                    new Peripheral(){
                        Vendor = "PHP",
                        Status = Ground.PeripheralStatus.Online,
                        CreateAt = createDate,
                    },
                    new Peripheral(){
                        Vendor = "Intel",
                        Status = Ground.PeripheralStatus.Online,
                        CreateAt = createDate,
                    },
                    new Peripheral(){
                        Vendor = "Lenovo",
                        Status = Ground.PeripheralStatus.Online,
                        CreateAt = createDate,
                    },

                    },
                },
                new Gateway(){
                SerialNumber = "G2",
                Name = "Gateway2",
                IPv4 = "127.0.0.2",
                AssociatedPeripherals = new List<Peripheral>(){
                    new Peripheral(){
                        Vendor = "ASUS",
                        Status = Ground.PeripheralStatus.Online,
                        CreateAt = createDate,
                    },
                    new Peripheral(){
                        Vendor = "Toshiba",
                        Status = Ground.PeripheralStatus.Online,
                        CreateAt = createDate,
                    },
                },
                },
            };

            context.Gateways.AddRange(data);
            context.SaveChanges();

        }
    }
}
