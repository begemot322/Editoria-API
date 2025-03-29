using Editoria.Application.Features.Articles.Commands.CreateArticle;
using Editoria.Application.Features.Articles.Queries.GetPagedArticles;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Editoria.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ArticleController(ISender sender) : Controller
{
    [HttpGet]
    public async Task<IActionResult> GetPaged([FromQuery] int pageNumber, [FromQuery] int pageSize )
    {
        var articlesList = await sender.Send(new GetPagedArticlesQuery(pageNumber, pageSize));
        return Ok(articlesList);
    }
    
    [HttpPost]
    [ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromBody] CreateArticleCommand create,
        CancellationToken token)
    {
        var articleId = await sender.Send(create, token);
        return CreatedAtAction(nameof(create), new { id = articleId }, articleId);
    }
}