using Centroware.Model.Entities.Works;
using System.ComponentModel.DataAnnotations.Schema;

namespace Centroware.Model.Entities.Sayings
{
    public class Opinion : BaseEntity
    {
        public string Name { get; set; }
        public string Specialty { get; set; }
        public string Image { get; set; }
        public string Logo { get; set; }
        public string Description { get; set; }
        public int? WorkId { get; set; }
        [ForeignKey("WorkId")]
        public Work Work { get; set; }
    }
}
