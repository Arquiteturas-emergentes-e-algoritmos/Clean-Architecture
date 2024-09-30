using Api.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Web;

[ApiController]
[Route("/v1/medication")]
public class MedicationPlanController : MyBaseController
{

    [Route("")]
    [HttpPost]
    public ActionResult<object> PostAddMedication()
    {
        try
        {
            return Ok("Adicionado com sucesso");
        }

        catch (Exception ex)
        {
            return StatusCode(500, ex);
        }
    }
    [Route("")]
    [HttpGet]
    public ActionResult<object> GetMedications()
    {
        try
        {
            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex);
        }
    }

    [Route("{Id}")]
    [HttpPut]
    public ActionResult<object> UpdateMedication()
    {
        try
        {
            return Ok("Atualizado com sucesso");
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex);
        }
    }
    [Route("{Id}")]
    [HttpDelete]
    public ActionResult<object> DeleteMedication([FromRoute] string Id)
    {
        try
        {
            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex);
        }
    }
}