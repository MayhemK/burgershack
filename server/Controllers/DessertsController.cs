namespace burgershack.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DessertsController : ControllerBase
{
  private readonly DessertsService _dessertsService;
  private readonly Auth0Provider _auth0Provider;

  public DessertsController(DessertsService dessertsService, Auth0Provider auth0Provider)
  {
    _dessertsService = dessertsService;
    _auth0Provider = auth0Provider;
  }

  [HttpGet]
  public ActionResult<List<Dessert>> GetAll()
  {
    try
    {
      IEnumerable<Dessert> desserts = _dessertsService.GetDesserts();
      return Ok(desserts);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }

  [HttpGet("{dessertId}")]
  public ActionResult<Dessert> GetDessertById(int dessertId)
  {
    try
    {
      Dessert dessert = _dessertsService.GetDessertById(dessertId);
      return Ok(dessert);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }

  // [Authorize]
  [HttpPost]
  public async Task<ActionResult<Dessert>> Create([FromBody] Dessert dessertData)
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      // FIXME ADD CREATOR ID 
      Dessert dessert = _dessertsService.CreateDessert(dessertData);
      return Ok(dessert);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }

  // [Authorize]
  [HttpPut("{dessertId}")]
  public async Task<ActionResult<Dessert>> Update(int dessertId, [FromBody] Dessert dessertUpdateData)
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      Dessert dessert = _dessertsService.Update(dessertId, dessertUpdateData, userInfo);
      return Ok(dessert);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }

  // [Authorize]
  [HttpDelete("{dessertId}")]
  public async Task<ActionResult<string>> Delete(int dessertId)
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      string message = _dessertsService.Delete(dessertId, userInfo);
      return Ok(message);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }
}