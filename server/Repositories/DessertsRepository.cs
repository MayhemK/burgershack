namespace burgershack.Repositories;

public class DessertsRepository : IRepository<Dessert>
{
  private readonly IDbConnection _db;
  public DessertsRepository(IDbConnection db)
  {
    _db = db;
  }

  public IEnumerable<Dessert> GetAll()
  {
    return _db.Query<Dessert>("SELECT * FROM desserts;");
  }

  public Dessert GetById(int id)
  {
    return _db.QueryFirstOrDefault<Dessert>("SELECT * FROM desserts WHERE id = @id;", new { id });
  }

  public Dessert Create(Dessert dessert)
  {
    string sql = "INSERT INTO desserts (name, price, img_url) VALUES (@Name, @Price, @ImgUrl); SELECT LAST_INSERT_ID();";
    int id = _db.ExecuteScalar<int>(sql, dessert);
    dessert.Id = id;
    return dessert;
  }

  public bool Delete(int id)
  {
    string sql = "DELETE FROM desserts WHERE id = @Id LIMIT 1;";
    return _db.Execute(sql, new { id }) > 0;
  }

  public Dessert Update(Dessert updateData)
  {
    string sql = "UPDATE desserts SET name = @Name, price = @Price, img_url = @ImgUrl WHERE id = @Id;";
    _db.Execute(sql, updateData);
    return updateData;
  }
}