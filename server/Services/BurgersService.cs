namespace burgershack.Services;

public class BurgersService
{
  private readonly BurgersRepository _repo;
  public BurgersService(BurgersRepository repo)
  {
    _repo = repo;
  }

  public IEnumerable<Burger> GetBurgers()
  {
    return _repo.GetAll();
  }

  public Burger GetBurgerById(int id)
  {
    Burger burger = _repo.GetById(id);
    if (burger == null) throw new Exception("invalid Id");
    return burger;
  }

  public Burger CreateBurger(Burger burgerData)
  {
    Burger burger = _repo.Create(burgerData);
    return burger;
  }

  public Burger UpdateBurger(int burgerId, Burger burgerUpdateData, Account userInfo)
  {
    Burger burger = GetBurgerById(burgerId);

    //FIXME - NEED TO ADD CREATOR ID

    burger.Name = burgerUpdateData.Name ?? burger.Name;
    burger.Price = burgerUpdateData.Price ?? burger.Price;
    burger.ImgUrl = burgerUpdateData.ImgUrl ?? burger.ImgUrl;

    _repo.Update(burger);
    return burger;
  }

  public string Delete(int burgerId, Account userInfo)
  {
    Burger burger = GetBurgerById(burgerId);

    //FIXME - NEED TO ADD CREATOR ID

    _repo.Delete(burgerId);
    return "Your Burger has been deleted!";
  }
}