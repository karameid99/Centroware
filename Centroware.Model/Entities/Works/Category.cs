using System.Collections.Generic;
namespace Centroware.Model.Entities.Works
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public List<Work> Works { get; set; }
    }
}
