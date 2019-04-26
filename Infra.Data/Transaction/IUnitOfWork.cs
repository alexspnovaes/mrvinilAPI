namespace Data.Transaction
{
    public interface IUnitOfWork
    {
        void Commit();
        void RollBack();
    }
}
