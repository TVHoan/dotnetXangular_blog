using DotnetAngular.Dto.Base;

namespace DotnetAngular.Dto;

public class PostDto
{   
    public string? Id { get; set; }
    public string Title { get; set; }
    public string Createdat { get; set; }
    public string Content { get; set; }
    public string Imageurl { get; set; }
}