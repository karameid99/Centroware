namespace Centroware.Model.Entities.Works
{
    public class Article
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public int? WorkId { get; set; }
        public Work Work { get; set; }
        public string WorkStringId { get; set; }
    }
}
