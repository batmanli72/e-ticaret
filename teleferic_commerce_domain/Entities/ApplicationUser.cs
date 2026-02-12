using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace teleferic_commerce_domain.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public String firstName { get; set; } = string.Empty;   
        public String lastName { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;


    }
}
