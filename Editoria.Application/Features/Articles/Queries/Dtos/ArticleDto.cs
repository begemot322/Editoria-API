namespace Editoria.Application.Features.Articles.Queries.Dtos;

public class ArticleDto
{
    public int Id { get; init; }
    public string Title { get; init; } 
    public string Text { get; init; } 
    public DateTime PublicationDate { get; init; }
    public string Status { get; init; } 
    
    public int AuthorId { get; init; }
    public List<int> CategoryIds { get; init; } = new();
}