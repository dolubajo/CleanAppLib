using System.Linq;

namespace AppLib.Patterns.Repository
{
  public interface IEntityRepository<E> where E : IAggregateRoot
  {
    IQueryable<E> Entities { get; }

    void Add(E entity);

    void Remove(E entity);

    void Update(E entity);
  }
}