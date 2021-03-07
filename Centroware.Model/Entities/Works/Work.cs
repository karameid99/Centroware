using Centroware.Model.Entities.Sayings;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Centroware.Model.Entities.Works
{
    public class Work : BaseEntity
    {
        public string MainImage { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string About { get; set; }
        public string OurPart { get; set; }
        public string WorkStringId { get; set; }
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
        public List<Article> Articles { get; set; }
        public List<Opinion> Opinions { get; set; }
    }
}
