﻿using Editoria.Application.Features.Categories.Commands.CreateCategory;
using Editoria.Application.Features.Categories.Commands.DeleteCategory;
using Editoria.Application.Features.Categories.Commands.UpdateCategory;
using Editoria.Application.Features.Categories.Queries.Dtos;
using Editoria.Application.Features.Categories.Queries.GetCategories;
using Editoria.Application.Features.Categories.Queries.GetCategoryById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Editoria.Web.Controllers;


[ApiController]
[Route("api/[controller]")]
public class CategoryController(ISender sender) : ControllerBase
{
    [HttpGet("{id}")] 
    [ProducesResponseType(typeof(CategoryDto), StatusCodes.Status200OK)]   
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get(int id, CancellationToken token)
    {
        var category = await sender.Send(new GetCategoryByIdQuery(id), token);
        return Ok(category);
    }
    
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<CategoryDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll(CancellationToken token)
    {
        var categories = await sender.Send(new GetCategoriesQuery(), token);
        return Ok(categories);
    }
    
    
    [HttpPost]
    [ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromBody] CreateCategoryCommand create,
        CancellationToken token)
    {
        var categoryId = await sender.Send(create, token);
        return CreatedAtAction(nameof(Get), new { id = categoryId }, categoryId);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Update([FromBody] UpdateCategoryCommand update,
        CancellationToken token)
    {
        await sender.Send(update, token);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Delete(int id, CancellationToken token)
    {
        await sender.Send(new DeleteCategoryCommand(id), token);
        return NoContent();
    }
}