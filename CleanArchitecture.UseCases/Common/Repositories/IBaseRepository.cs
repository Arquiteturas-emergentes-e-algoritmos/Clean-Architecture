namespace CleanArchitecture.UseCases.Common.Repositories;

public interface IBaseRepository<T>
{
    void Add(T entity);
    void Delete(T entity);
    void Update(T entity);
    List<T> GetAll();
    T GetById(string id);
}
