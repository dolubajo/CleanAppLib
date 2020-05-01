using System;

namespace AppLib.Patterns.Repository
{
  public interface IEntity
  {
    Guid Id { get; set; }
    DateTime CreatedAt { get; }
  }

  public interface IAggregateRoot : IEntity { }
}
