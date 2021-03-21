using Centroware.Model.Entities.Works;
using Centroware.Model.ViewModels.Blogs;
using Centroware.Model.ViewModels.Works;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centroware.Model.ViewModels.HomeVms
{
    public class WorksVm
    {
        public List<BlogCategoryVm> Categories { get; set; }
        public List<WorkVm> Works { get; set; }
    }
}
