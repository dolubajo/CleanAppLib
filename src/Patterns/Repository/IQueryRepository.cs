using System.Linq;

namespace AppLib.Patterns.Repository
{
  public interface IQueryRepository<E> where E : IAggregateRoot
  {
    IQueryable<E> Entities { get; }
  }
}