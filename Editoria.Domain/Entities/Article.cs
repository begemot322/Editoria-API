using Editoria.Domain.Enums;

namespace Editoria.Domain.Entities;

public class Article
{
    public int Id { get; set; }
    
    public string Title { get; set; }
    
    public string Text { get; set; }
    
    public DateTime PublicationDate { get; set; }

    public ArticleStatus Status { get; set; } = ArticleStatus.Draft;
    
    // Связь с автором
    public int AuthorId { get; set; }
    public Author? Author { get; set; }
    
    // Связь с категориями
    public ICollection<ArticleCategory> ArticleCategories { get; set; } = new List<ArticleCategory>();
}