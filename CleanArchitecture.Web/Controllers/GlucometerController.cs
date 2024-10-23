using CleanArchitecture.UseCases.Glucometer.Commands;
using CleanArchitecture.UseCases.Glucometer.Handlers.Delete;
using CleanArchitecture.UseCases.Glucometer.Handlers.Get;
using CleanArchitecture.UseCases.Glucometer.Handlers.Post;
using CleanArchitecture.UseCases.Glucometer.Handlers.Put;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("/v1/glucometer")]
public class GlucometerController : MyBaseController
{

    [Route("")]
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult PostAddTest([FromBody] AddTestCommand command, [FromServices] AddTestHandler handler)
    {
        try
        {
            if (!command.Validate() || !ModelState.IsValid)
                return BadRequest();
            handler.Handle(command);
            return Ok("Adicionado com sucesso");
        }

        catch (Exception ex)
        {
            return StatusCode(500, ex);
        }
    }

    [Route("")]
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult GetTests([FromServices] GetTestsHandler handler)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var tests = handler.Handle(new GetTestsCommand());
            return Ok(tests);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex);
        }
    }

    [Route("")]
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult UpdateTest([FromBody] PatchTestCommand command, PatchTestHandler handler)
    {
        try
        {
            if (!command.Validate() || !ModelState.IsValid)
                return BadRequest();
            handler.Handle(command);
            return Ok("Atualizado com sucesso!");
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex);
        }
    }

    [Route("{Id}")]
    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult DeleteTest([FromRoute] string Id, [FromServices] DeleteTestHandler handler)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var id = Guid.Parse(Id);
            handler.Handle(new DeleteTestCommand() { Id = id });
            return Ok("Deletado com sucesso!");
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex);
        }
    }
}