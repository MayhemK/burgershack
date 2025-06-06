namespace burgershack.Repositories;

public interface IRepository<T>
{
  IEnumerable<T> GetAll();
  T GetById(int id);
  T Create(T data);
  bool Delete(int id);
  T Update(T updateData);

}