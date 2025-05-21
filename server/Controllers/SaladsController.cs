namespace burgershack.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SaladsController : ControllerBase
{
  private readonly SaladsService _saladsService;
  private readonly Auth0Provider _auth0Provider;

  public SaladsController(SaladsService saladsService, Auth0Provider auth0Provider)
  {
    _saladsService = saladsService;
    _auth0Provider = auth0Provider;
  }

  [HttpGet]
  public ActionResult<List<Salad>> GetAll()
  {
    try
    {
      IEnumerable<Salad> salads = _saladsService.GetSalads();
      return Ok(salads);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }

  [HttpGet("{saladId}")]
  public ActionResult<Salad> GetSaladById(int saladId)
  {
    try
    {
      Salad salad = _saladsService.GetSaladById(saladId);
      return Ok(salad);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }

  [HttpPost]
  public async Task<ActionResult<Salad>> Create([FromBody] Salad saladData)
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);

      Salad salad = _saladsService.CreateSalad(saladData);
      return Ok(salad);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }

  [HttpPut("{saladId}")]
  public async Task<ActionResult<Salad>> Update(int saladId, [FromBody] Salad saladUpdateData)
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      Salad salad = _saladsService.Update(saladId, saladUpdateData, userInfo);
      return Ok(salad);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }
}