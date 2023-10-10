using System.ComponentModel.DataAnnotations;

namespace DotnetAngular.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        public int PostId { get; set; }
        public string Name { get; set; }
        public DateTime Createdat { get; set; }
        public string Content { get; set; }
        public Post Post { get; set; }
    }
}
