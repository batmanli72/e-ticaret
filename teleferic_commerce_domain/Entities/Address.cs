using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace teleferic_commerce_domain.Entities
{

    public class Address : BaseEntity
    {
        public string UserId { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string District { get; set; } = string.Empty;
        public string Addressline{ get; set; } = string.Empty;
        public string Zipcode { get; set; } 

        public string IsDefault { get; set; } 
    }
}
