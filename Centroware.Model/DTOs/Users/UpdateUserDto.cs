using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centroware.Model.DTOs.Users
{
    public class UpdateUserDto : CreateUserDto
    {
        public string Id { get; set; }
    }
}
