namespace Editoria.Domain.Entities;

public class Category
{
    public int Id { get; set; }
    
    public string Name { get; set; }

    public string Description { get; set; }
    
    // Связь со статьями 
    public ICollection<ArticleCategory> ArticleCategories { get; set; } = new List<ArticleCategory>();
}