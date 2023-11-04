using EFood.DataAccess.Data;
using EFood.DataAccess.Repository.IRepository;
using EFood.models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFood.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext _db;

        public ProductRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Product product)
        {
            var productBD = _db.Products.FirstOrDefault(c => c.Id == product.Id);
            if (productBD != null)
            {
                if (product.Image != null)
                {
                    productBD.Image = product.Image;
                }
                productBD.Name = product.Name;
                productBD.Description = product.Description;
                productBD.FoodLineId = product.FoodLineId;

                _db.SaveChanges();
            }
        }

        public IEnumerable<SelectListItem> GetFoodLineListDropDown(string obj)
        {
            if (obj == "FoodLine")
            {
                return _db.FoodLines.Select(i => new SelectListItem()
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                });
            }
            else
            {
                return null;
            }
        }
    }
}
