namespace Editoria.Application.Features.Categories.Queries.GetCategoryById;

public class CategoryDto
{
    public int Id { get; set; }        
    public string Name { get; set; }
    public string Description { get; set; }
    
    public List<ArticleShortDto> Articles { get; set; } = new();
}
public class ArticleShortDto
{   
    public int Id { get; set; }        
    public string Title { get; set; } 
    public DateTime PublicationDate { get; set; }
}