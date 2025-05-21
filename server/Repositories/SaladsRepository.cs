namespace burgershack.Repositories;

public class SaladsRepository : IRepository<Salad>
{
  private readonly IDbConnection _db;
  public SaladsRepository(IDbConnection db)
  {
    _db = db;
  }

  public IEnumerable<Salad> GetAll()
  {
    return _db.Query<Salad>("SELECT * FROM salads;");
  }

  public Salad GetById(int id)
  {
    return _db.QueryFirstOrDefault<Salad>("SELECT * FROM salads WHERE id = @id;", new { id });
  }

  public Salad Create(Salad salad)
  {
    string sql = "INSERT INTO salads (name, price, img_url) VALUES (@Name, @Price, @ImgUrl); SELECT LAST_INSERT_ID();";
    int id = _db.ExecuteScalar<int>(sql, salad);
    salad.Id = id;
    return salad;
  }

  public bool Delete(int id)
  {
    string sql = "DELETE FROM salads WHERE id = @Id LIMIT 1;";
    return _db.Execute(sql, new { id }) > 0;
  }

  public Salad Update(Salad updateData)
  {
    string sql = "UPDATE salads SET name = @Name, price = @Price, img_url = @ImgUrl WHERE id = @Id;";
    _db.Execute(sql, updateData);
    return updateData;
  }
}