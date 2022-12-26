using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PorfolioDB.Models;
using PortfolioDB.Services;

namespace GeneralDB.Controllers;

// the [controller] in api/[controller] gets replaced with the name of your class for in this case if we
// run this app locally in postman, then we would append /api/PortfolioContact/ and add what we need to
// add to get this working
[Route("api/[controller]")]
[ApiController]
public class BookController : ControllerBase
{
    private readonly BookService service;

    public BookController(BookService service)
    {
        this.service = service;
    }


    [HttpGet]
    public async Task<List<BookModel>> Get()
    {
        return await service.Get();
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] BookModel model)
    {
        System.Console.WriteLine(model);
        await service.Create(model);
        return CreatedAtAction(nameof(Get), null);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(string id, [FromBody] BookModel model)
    {
        var doc = await service.Get(id);
        if (doc is null)
        {
             return NotFound($"cant find {model}");
        }

        // update doesn't include the object id, so we must update it manually
        model.Id = doc.Id;
        await service.Update(id, model);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        await service.Remove(id);
        return NoContent();
    }
}
