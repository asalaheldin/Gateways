using Gateways.Ground;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gateways.Service.Models
{
    public interface IServiceResult<T> where T : class
    {
        List<string> Messages { get; set; }
        bool IsValid { get; set; }
        ValidationStatus? Status { get; set; }
    }
    public class ServiceResultDetail<T> : IServiceResult<T> where T : class
    {
        public ServiceResultDetail()
        {
            IsValid = true;
        }
        /// <summary>
        ///  Return Single Error Message, With Not Valid Flag
        /// </summary>
        public ServiceResultDetail(string validationMsg, ValidationStatus? status = null)
        {
            IsValid = false;
            Messages = new List<string>() { validationMsg };
            Status = status;
        }
        public bool IsValid { get; set; }
        public List<string> Messages { get; set; }
        public T Model { get; set; }
        public long SubTotalCount { get; set; }
        public ValidationStatus? Status { get; set; }
    }
    public class ServiceResultList<T> : IServiceResult<T> where T : class
    {
        public ServiceResultList()
        {
            IsValid = true;
        }
        /// <summary>
        ///  Return Single Error Message, With Not Valid Flag
        /// </summary>
        public ServiceResultList(string validationMsg, ValidationStatus? status = null)
        {
            IsValid = false;
            Messages = new List<string>() { validationMsg };
            Status = status;
        }
        public bool IsValid { get; set; }
        public List<string> Messages { get; set; }
        public List<T> Model { get; set; }
        public long Count { get; set; }
        public ValidationStatus? Status { get; set; }
    }
}
