using DotnetAngular.Dto.Base;

namespace DotnetAngular.Dto;

public class InputDto: PaginationDto
{
    public int? Skip { get; set; }
    public int? Take { get; set; }
}