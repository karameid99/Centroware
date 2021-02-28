using Centroware.Model.ViewModels.Blogs;
using Centroware.Model.ViewModels.Teams;
using System.Collections.Generic;


namespace Centroware.Model.ViewModels
{
    public class DashboardVm
    {
        public int ContactCount { get; set; }
        public int ArticleCount { get; set; }
        public int TeamsCount { get; set; }
        public List<TeamVm> Teams { get; set; }
        public List<BlogVm> Blogs { get; set; }
    }
}
