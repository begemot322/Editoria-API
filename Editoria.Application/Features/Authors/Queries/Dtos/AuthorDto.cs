namespace Editoria.Application.Features.Authors.Queries.Dtos;

public class AuthorDto
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public string Surname { get; set; }
    
    public string PhoneNumber { get; set; }
    
    public string Biography { get; set; }
    
    public List<int> ArtilesIds { get; init; } = new();
}