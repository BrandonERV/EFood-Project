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

        public IFoodLineRepository FoodLine { get; private set; }

        public IProductRepository Product { get; private set; }

        public IProductPriceRepository ProductPrice { get; private set; }

        public IPaymentProcessorCardRepository PaymentProcessorCard { get; private set; }


        public WorkUnit(ApplicationDbContext db)
        {
            _db = db;
            User = new UserRepository(_db);
            Card = new CardRepository(_db);
            PaymentProcessor = new PaymentProcessorRepository(_db);
            PriceType = new PriceTypeRepository(_db);
            FoodLine = new FoodLineRepository(_db);
            Product = new ProductRepository(_db);
            ProductPrice = new ProductPriceRepository(_db);
            PaymentProcessorCard = new PaymentProcessorCardRepository(_db);

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
