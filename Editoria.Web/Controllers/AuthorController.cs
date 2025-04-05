using Editoria.Application.Features.Authors.Commands.CreateAuthor;
using Editoria.Application.Features.Authors.Commands.DeleteAuthor;
using Editoria.Application.Features.Authors.Commands.UpdateAuthor;
using Editoria.Application.Features.Authors.Queries.Dtos;
using Editoria.Application.Features.Authors.Queries.GetAuthorById;
using Editoria.Application.Features.Authors.Queries.GetAuthors;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Editoria.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthorController(ISender sender) : Controller
{
    [HttpGet("{id}")] 
    [ProducesResponseType(typeof(AuthorDto), StatusCodes.Status200OK)]   
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get(int id, CancellationToken token)
    {
        var author = await sender.Send(new GetAuthorByIdQuery(id), token);
        return Ok(author);
    }
    
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<AuthorListDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll(CancellationToken token)
    {
        var categories = await sender.Send(new GetAuthorsQuery(), token);
        return Ok(categories);
    }
    
    [HttpPost]
    [ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromBody] CreateAuthorCommand create,
        CancellationToken token)
    {
        var authorId = await sender.Send(create, token);
        return CreatedAtAction(nameof(create), new { id = authorId }, authorId);
    }
    
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Update([FromBody] UpdateAuthorCommand update,
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
        await sender.Send(new DeleteAuthorCommand(id), token);
        return NoContent();
    }
}