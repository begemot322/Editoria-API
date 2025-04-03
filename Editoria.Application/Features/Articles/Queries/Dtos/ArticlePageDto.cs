namespace Editoria.Application.Features.Articles.Queries.Dtos;

public class ArticlePageDto
{
    public int Id { get; init; }
    public string Title { get; init; } 
    public string Text { get; init; } 
    public DateTime PublicationDate { get; init; }
    public string Status { get; init; } 

}