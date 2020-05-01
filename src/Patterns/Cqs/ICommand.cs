using System.Collections.Generic;

namespace AppLib.Patterns.Cqs
{
  public interface ICommand : IRequest<Response> { }

  public interface ICommandValidator<C> where C : ICommand
  {
    IEnumerable<IResponseMessage> Validate(C command);
  }

  public interface ICommandHandler<C> : IRequestHandler<C, Response> where C : ICommand
  {
  }
}
