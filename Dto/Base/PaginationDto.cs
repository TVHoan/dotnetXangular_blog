namespace DotnetAngular.Dto.Base;

public interface PaginationDto
{
    public int? Skip { get; set; }
    public int? Take { get; set; }
}