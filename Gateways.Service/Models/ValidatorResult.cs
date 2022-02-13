using System;
using System.Collections.Generic;
using System.Text;

namespace Gateways.Service.Models
{
    public class ValidatorResult
    {
        public ValidatorResult()
        {
            IsValid = true;
            Message = string.Empty;
        }
        public string Message { get; set; }
        public bool IsValid { get; set; }
        
    }
}
