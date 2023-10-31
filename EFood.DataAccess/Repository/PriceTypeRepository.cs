using EFood.DataAccess.Data;
using EFood.DataAccess.Repository.IRepository;
using EFood.models;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFood.DataAccess.Repository
{
    public class PriceTypeRepository : Repository<PriceType>, IPriceTypeRepository
    {
        private readonly ApplicationDbContext _db;

        public PriceTypeRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(PriceType priceType)
        {
           var priceTypeBD = _db.PriceTypes.FirstOrDefault(c => c.Id == priceType.Id);
            if (priceTypeBD != null)
            {
                priceTypeBD.Name = priceType.Name;

                _db.SaveChanges();
            }
        }
    }
}
