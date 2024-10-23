using Api.Controllers;
using CleanArchitecture.UseCases.MedicationPlan.Commands;
using CleanArchitecture.UseCases.MedicationPlan.Handlers.Delete;
using CleanArchitecture.UseCases.MedicationPlan.Handlers.Get;
using CleanArchitecture.UseCases.MedicationPlan.Handlers.Post;
using CleanArchitecture.UseCases.MedicationPlan.Handlers.Put;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Web;

[ApiController]
[Route("/v1/medication")]
public class MedicationPlanController : MyBaseController
{

    [Route("")]
    [HttpPost]
    [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(object), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(object), StatusCodes.Status500InternalServerError)]
    public IActionResult PostAddMedication
        ([FromBody] AddMedicationCommand command, [FromServices] AddMedicationHandler handler)
    {
        try
        {
            if (!ModelState.IsValid || !command.Validate())
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
    [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(object), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(object), StatusCodes.Status500InternalServerError)]
    public IActionResult GetMedications([FromServices] GetAllMedicationsHandler handler)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var medications = handler.Handle(new GetMedicationsCommand());
            return Ok(medications);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex);
        }
    }

    [Route("")]
    [HttpPut]
    [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(object), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(object), StatusCodes.Status500InternalServerError)]
    public IActionResult UpdateMedication([FromBody] PatchMedicationCommand command, [FromServices] PatchMedicationHandler handler)
    {
        try
        {
            if (!ModelState.IsValid || !command.Validate())
                return BadRequest();

            handler.Handle(command);
            return Ok("Atualizado com sucesso");
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex);
        }
    }
    [Route("{Id}")]
    [HttpDelete]
    [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(object), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(object), StatusCodes.Status500InternalServerError)]
    public IActionResult DeleteMedication([FromServices] DeleteMedicationHandler handler, [FromRoute] string Id)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var id = Guid.Parse(Id);
            handler.Handle(new DeleteMedicationCommand() { Id = id });
            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex);
        }
    }
}