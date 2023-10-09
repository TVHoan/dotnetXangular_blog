using DotnetAngular.Dto.Base;

namespace DotnetAngular.Dto;

public class CommentInputDto: PaginationDto
{
    public int? Skip { get; set; }
    public int? Take { get; set; }
}