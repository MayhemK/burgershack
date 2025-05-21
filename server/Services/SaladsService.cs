namespace burgershack.Services;

public class SaladsService
{
  private readonly SaladsRepository _repo;
  public SaladsService(SaladsRepository repo)
  {
    _repo = repo;
  }

  public IEnumerable<Salad> GetSalads()
  {
    return _repo.GetAll();
  }

  public Salad GetSaladById(int id)
  {
    Salad salad = _repo.GetById(id);
    if (salad == null) throw new Exception("Invalid Salad ID");
    return salad;
  }

  public Salad CreateSalad(Salad saladData)
  {
    Salad salad = _repo.Create(saladData);
    return salad;
  }

  public string Delete(int saladId, Account userInfo)
  {
    Salad salad = GetSaladById(saladId);

    _repo.Delete(saladId);
    return "Your Salad has been Deleted!";
  }

  public Salad Update(int saladId, Salad saladUpdateData, Account userInfo)
  {
    Salad salad = GetSaladById(saladId);

    salad.Name = saladUpdateData.Name ?? salad.Name;
    salad.Price = saladUpdateData.Price ?? salad.Price;
    salad.ImgUrl = saladUpdateData.ImgUrl ?? salad.ImgUrl;

    _repo.Update(salad);
    return salad;
  }
}