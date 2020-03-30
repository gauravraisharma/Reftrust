using RefTrust.Repository.Entities;
using RefTrust.Repository.Infrastructure.Contract;
using System.Data.Entity;
using System.Transactions;

namespace RefTrust.Repository.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private TransactionScope _transaction;
        private readonly RefTrustDBContext _db;


        public UnitOfWork()
        {
            _db = new RefTrustDBContext();

        }

        public void Dispose()
        {

        }

        public void StartTransaction()
        {
            _transaction = new TransactionScope();
        }

        public void Commit()
        {
            _db.SaveChanges();
            _transaction.Complete();
        }

        public DbContext Db
        {
            get { return _db; }
        }



    }
}
