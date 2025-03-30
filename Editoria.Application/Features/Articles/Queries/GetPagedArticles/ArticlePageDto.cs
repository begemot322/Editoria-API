using Editoria.Domain.Enums;

namespace Editoria.Application.Features.Articles.Queries.GetPagedArticles;

public class ArticlePageDto
{
    public int Id { get; set; }
    
    public string Title { get; set; }
    
    public string Text { get; set; }
    
    public DateTime PublicationDate { get; set; }

    public string Status { get; set; }
}