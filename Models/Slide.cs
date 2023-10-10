using System.ComponentModel.DataAnnotations;

namespace DotnetAngular.Models
{
    public class Slide

    {
        [Key]
        public int Id { get; set; }
        public string Urlimage { get; set; }
        public bool Active { get; set; }
    }
}
