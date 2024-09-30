using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("/v1/glucometer")]
public class GlucometerController : MyBaseController
{

    [Route("")]
    [HttpPost]
    public ActionResult<object> PostAddTest([FromBody] IAddTestAdapter adapter)
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
    public ActionResult<object> GetTests()
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
    public ActionResult<object> UpdateTest([FromRoute] string Id)
    {
        try
        {
            return Ok("Atualizado com sucesso!");
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex);
        }
    }

    [Route("{Id}")]
    [HttpDelete]
    public ActionResult<object> DeleteTest([FromRoute] string Id)
    {
        try
        {
            return Ok("Deletado com sucesso!");

        }
        catch (Exception ex)
        {
            return StatusCode(500, ex);
        }
    }
}