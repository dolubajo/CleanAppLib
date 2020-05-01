
namespace AppLib.Patterns.Cqs
{
  public interface IQueryFor<P> : IRequest<QueryResponse<P>> where P : class { }
  public interface IQueryHandler<Q, P> : IRequestHandler<Q, QueryResponse<P>> where Q
  : IQueryFor<P> where P : class
  { }
}