using System;
using AppLib.Patterns.Cqs;

namespace AppLib.Identity
{
  public class UserWithPrincipalIdNotFound : AResponseErrorMessage
  {
    public UserWithPrincipalIdNotFound(Guid id)
    {
      Message = $"User with {id} not found";
    }
    public override string Message { get; }
  }
}