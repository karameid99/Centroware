namespace Centroware.Model.Entities.Teams
{
    public class Team : BaseEntity
    {
        public string Name { get; set; }
        public string Specialization { get; set; }
        public string StaticImage { get; set; }
        public string MovedImage { get; set; }
        public string Description { get; set; }
    }
}
