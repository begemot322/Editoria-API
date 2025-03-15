namespace Editoria.Domain.Entities;

public class Author
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public string Surname { get; set; }
    
    public string PhoneNumber { get; set; }
    
    public string Biography { get; set; }
    
    // Связь со статьями
    public ICollection<Article> Articles { get; set; } = new List<Article>();
}