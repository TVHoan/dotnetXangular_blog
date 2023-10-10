using System.ComponentModel.DataAnnotations;

namespace DotnetAngular.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Createdat { get; set; }
        public string Content { get; set; }
        public string Imageurl { get; set; }
        public int? PostTypeId { get; set; }
        public PostType? PostType { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
