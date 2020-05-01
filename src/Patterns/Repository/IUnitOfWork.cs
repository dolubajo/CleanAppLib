namespace AppLib.Patterns.Repository
{
  public interface IUnitOfWork
  {
    void Commit();
  }
}