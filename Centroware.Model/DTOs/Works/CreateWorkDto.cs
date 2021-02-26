using Centroware.Model.DTOs.Opinions;
using System.Collections.Generic;
namespace Centroware.Model.DTOs.Works
{
    public class CreateWorkDto
    {
        public string MainImage { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string About { get; set; }
        public string OurPart { get; set; }
        public int CategoryId { get; set; }
        public List<CreateArticleDto> Articles { get; set; }
        public List<OpinionDto> Opinions { get; set; }
    }
}
