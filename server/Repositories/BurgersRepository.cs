namespace burgershack.Repositories;

public class BurgersRepository : IRepository<Burger>
{
  private readonly IDbConnection _db;
  public BurgersRepository(IDbConnection db)
  {
    _db = db;
  }

  public IEnumerable<Burger> GetAll()
  {
    return _db.Query<Burger>("SELECT * FROM burgers;");
  }

  public Burger GetById(int id)
  {
    return _db.QueryFirstOrDefault<Burger>("SELECT * FROM burgers WHERE id = @id;", new { id });
  }

  public Burger Create(Burger burger)
  {
    string sql = "INSERT INTO burgers (name, price, img_url) VALUES (@Name, @Price, @ImgUrl); SELECT LAST_INSERT_ID();";
    int id = _db.ExecuteScalar<int>(sql, burger);
    burger.Id = id;
    return burger;
  }

  public bool Delete(int id)
  {
    string sql = "DELETE FROM burgers WHERE id = @Id LIMIT 1;";
    return _db.Execute(sql, new { id }) > 0;
  }

  public Burger Update(Burger updateData)
  {
    string sql = "UPDATE burgers SET name = @Name, price = @Price, img_url = @ImgUrl WHERE id = @Id;";
    _db.Execute(sql, updateData);
    return updateData;
  }
}