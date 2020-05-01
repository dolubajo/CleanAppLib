
using System;
using AppLib.Primitives;

namespace AppLib.Identity
{
  public interface IGetCurrentUserPrincipal
  {
    UserPrincipal Execute();
  }

  public class UserPrincipal
  {
    public Guid Id;
    public string Name;
    public string Email;

    public UserPrincipal(Guid id, string name, string email)
    {
      this.Id = Guard.NotEmptyOrDefault(id, nameof(id));
      this.Name = Guard.NotNullOrWhiteSpace(name, nameof(name));
      this.Email = Guard.NotNullOrWhiteSpace(email, nameof(email));
    }
  }
}