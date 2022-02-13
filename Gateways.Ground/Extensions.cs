using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gateways.Ground
{
    public static class Extensions
    {
        public static string SerializeModelObject<T>(this T model)
        {
            return JsonConvert.SerializeObject(model);
        }
    }
}
