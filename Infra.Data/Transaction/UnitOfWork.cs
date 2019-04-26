using Data.Context;

namespace Data.Transaction
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MrVinilContext _context;

        public UnitOfWork(MrVinilContext context)
        {
            _context = context;
        }

        void IUnitOfWork.Commit()
        {
            _context.SaveChanges();
        }


        void IUnitOfWork.RollBack()
        {
            // entity encerra automaticamente a transação
        }
    }
}
