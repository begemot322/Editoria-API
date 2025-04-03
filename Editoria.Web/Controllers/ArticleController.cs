using Editoria.Application.Common;
using Editoria.Application.Features.Articles.Commands.CreateArticle;
using Editoria.Application.Features.Articles.Commands.DeleteArticle;
using Editoria.Application.Features.Articles.Commands.UpdateArticle;
using Editoria.Application.Features.Articles.Queries.Dtos;
using Editoria.Application.Features.Articles.Queries.GetArticleById;
using Editoria.Application.Features.Articles.Queries.GetPagedArticles;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Editoria.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ArticleController(ISender sender) : Controller
{
    [HttpGet("{id}")] 
    [ProducesResponseType(typeof(ArticleDto), StatusCodes.Status200OK)]   
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get(int id, CancellationToken token)
    {
        var category = await sender.Send(new GetArticleByIdQuery(id), token);
        return Ok(category);
    }
    
    [HttpGet]
    [ProducesResponseType(typeof(PaginatedList<ArticleDto>), StatusCodes.Status200OK)] 
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

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update([FromBody] UpdateArticleCommand update,
        CancellationToken token)
    {
        await sender.Send(update, token);
        return NoContent();
    }
    
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id, CancellationToken token)
    {
        await sender.Send(new DeleteArticleCommand(id), token);
        return NoContent();
    }

}