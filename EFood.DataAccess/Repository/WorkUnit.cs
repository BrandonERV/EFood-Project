using EFood.DataAccess.Data;
using EFood.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFood.DataAccess.Repository
{
    public class WorkUnit : IWorkUnit
    {

        private readonly ApplicationDbContext _db;

        public IUserRepository User { get; private set; }

        public ICardRepository Card { get; private set; }

        public IPaymentProcessorRepository PaymentProcessor { get; private set; }
        public IPriceTypeRepository PriceType { get; private set; }

        public WorkUnit(ApplicationDbContext db)
        {
            _db = db;
            User = new UserRepository(_db);
            Card = new CardRepository(_db);
            PaymentProcessor = new PaymentProcessorRepository(_db);
            PriceType = new PriceTypeRepository(_db);
        }


        public void Dispose()
        {
            _db.Dispose();
        }

        public async Task Save()
        {
            await _db.SaveChangesAsync();    
        }
    }
}
