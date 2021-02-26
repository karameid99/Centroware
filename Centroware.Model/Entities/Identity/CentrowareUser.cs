using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centroware.Model.Entities.Identity
{
    public class CentrowareUser : IdentityUser
    {
        public int FirstName { get; set; }
        public int LastName { get; set; }
    }
}
