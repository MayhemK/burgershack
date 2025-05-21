namespace burgershack.Services;

public class DessertsService
{
  private readonly DessertsRepository _repo;
  public DessertsService(DessertsRepository repo)
  {
    _repo = repo;
  }

  public IEnumerable<Dessert> GetDesserts()
  {
    return _repo.GetAll();
  }

  public Dessert GetDessertById(int id)
  {
    Dessert dessert = _repo.GetById(id);
    if (dessert == null) throw new Exception("invalid Dessert id");
    return dessert;
  }

  public Dessert CreateDessert(Dessert dessertData)
  {
    Dessert dessert = _repo.Create(dessertData);
    return dessert;
  }

  public string Delete(int dessertId, Account userInfo)
  {
    Dessert dessert = GetDessertById(dessertId);

    _repo.Delete(dessertId);
    return "Your Dessert has been deleted!";
  }

  public Dessert Update(int dessertId, Dessert dessertUpdateData, Account userInfo)
  {
    Dessert dessert = GetDessertById(dessertId);

    dessert.Name = dessertUpdateData.Name ?? dessert.Name;
    dessert.Price = dessertUpdateData.Price ?? dessert.Price;
    dessert.ImgUrl = dessertUpdateData.ImgUrl ?? dessert.ImgUrl;

    _repo.Update(dessert);
    return dessert;
  }
}