namespace burgershack.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BurgersController : ControllerBase
{
  [HttpGet("test")]
  public ActionResult<string> GetTest()
  {
    return Ok("🍔 test success!");
  }
}