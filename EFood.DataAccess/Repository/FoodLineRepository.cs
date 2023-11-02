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
    public class FoodLineRepository : Repository<FoodLine>, IFoodLineRepository
    {
        private readonly ApplicationDbContext _db;

        public FoodLineRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(FoodLine foodLine)
        {
           var foodLineBD = _db.FoodLines.FirstOrDefault(c => c.Id == foodLine.Id);
            if (foodLineBD != null)
            {
                foodLineBD.Name = foodLine.Name;

                _db.SaveChanges();
            }
        }
    }
}
