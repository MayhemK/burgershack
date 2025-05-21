namespace burgershack.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BurgersController : ControllerBase
{
  public BurgersController(BurgersService burgersService, Auth0Provider auth0Provider)
  {
    _burgersService = burgersService;
    _auth0Provider = auth0Provider;
  }
  private readonly BurgersService _burgersService;
  private readonly Auth0Provider _auth0Provider;

  [HttpGet]
  public ActionResult<List<Burger>> GetAll()
  {
    try
    {
      IEnumerable<Burger> burgers = _burgersService.GetBurgers();
      return Ok(burgers);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }

  [HttpGet("{burgerId}")]
  public ActionResult<Burger> GetBurgerById(int burgerId)
  {
    try
    {
      Burger burger = _burgersService.GetBurgerById(burgerId);
      return Ok(burgerId);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }

  // [Authorize]
  [HttpPost]
  public async Task<ActionResult<Burger>> Create([FromBody] Burger burgerData)
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      // FIXME ADD CREATOR ID
      Burger burger = _burgersService.CreateBurger(burgerData);
      return Ok(burger);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }

  // [Authorize]
  [HttpPut("{burgerId}")]
  public async Task<ActionResult<Burger>> Update(int burgerId, [FromBody] Burger burgerUpdateData)
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      Burger burger = _burgersService.UpdateBurger(burgerId, burgerUpdateData, userInfo);
      return Ok(burger);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }

  // [Authorize]
  [HttpDelete("{burgerId}")]
  public async Task<ActionResult<string>> Delete(int burgerId)
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      string message = _burgersService.Delete(burgerId, userInfo);
      return Ok(message);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }
}