namespace DotnetAngular.Dto;

public class CommentDto
{
    public string Id { get; set; }
    public string PostId { get; set; }
    public string Name { get; set; }
    public DateTime Createdat { get; set; }
    public string Content { get; set; }
}
