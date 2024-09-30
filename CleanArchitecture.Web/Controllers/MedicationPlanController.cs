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
    public ActionResult<object> PostAddMedication
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
    public ActionResult<object> GetMedications([FromServices] GetAllMedicationsHandler handler)
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
    public ActionResult<object> UpdateMedication([FromBody] PatchMedicationCommand command, [FromServices] PatchMedicationHandler handler)
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
    public ActionResult<object> DeleteMedication([FromServices] DeleteMedicationHandler handler, [FromRoute] string Id)
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