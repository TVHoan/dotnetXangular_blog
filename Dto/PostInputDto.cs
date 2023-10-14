namespace DotnetAngular.Dto
{
    public class PostInputDto
    {
        public int? Id { get; set; }
        public string Title { get; set; }
        public DateTime Createdat { get; set; }
        public string Content { get; set; }
        public string Imageurl { get; set; }
        public int? PostTypeId { get; set; }
    }
}
