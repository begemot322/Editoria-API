namespace Editoria.Application.Features.Articles.Queries.GetArticleById;

public class ArticleDto
{
    public int Id { get; init; }
    public string Title { get; init; }
    public string Text { get; init; }
    public DateTime PublicationDate { get; init; }
    public string Status { get; init; }
    public AuthorShortDto Author { get; init; }
    public List<CategoryShortDto> Categories { get; init; } = new();
}

public class AuthorShortDto
{
    public int Id { get; init; }
    public string Name { get; init; }
    public string Surname { get; init; }
}

public class CategoryShortDto
{
    public int Id { get; init; }
    public string Name { get; init; }
}