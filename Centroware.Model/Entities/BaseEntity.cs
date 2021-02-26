using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centroware.Model.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public string CreatedByUserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public BaseEntity()
        {
            CreatedAt = DateTime.Now;
        }
    }
}
