using System.ComponentModel.DataAnnotations;

namespace DotnetAngular.Models
{
    public class PostType
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Post> Posts { get; set; }
    }
}
