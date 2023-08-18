using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDAspNetCoreWebAPI.Models
{
    public class Response
    {
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }
        public Employee Employee { get; set; }
        public List<Employee> Listemployee { get; set; }
    }
}
