using Centroware.Model.DTOs.Works;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centroware.Model.ViewModels.Works
{
    public class WorkVm
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string MainImage { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string About { get; set; }
        public string OurPart { get; set; }
        public string Category { get; set; }
        public string CreatedAt { get; set; }
        public List<CreateArticleDto> Articles { get; set; }
    }
}
