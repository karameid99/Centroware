using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centroware.Model.ViewModels.Teams
{
   public class TeamVm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Specialization { get; set; }
        public string StaticImage { get; set; }
        public string MovedImage { get; set; }
        public string Description { get; set; }
    }
}
