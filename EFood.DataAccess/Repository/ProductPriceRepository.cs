using EFood.DataAccess.Data;
using EFood.DataAccess.Repository.IRepository;
using EFood.models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFood.DataAccess.Repository
{
    public class ProductPriceRepository : Repository<ProductPrice>, IProductPriceRepository
    {
        private readonly ApplicationDbContext _db;

        public ProductPriceRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(ProductPrice productPrice)
        {
            var productPriceBD = _db.ProductPrices.FirstOrDefault(c => c.Id == productPrice.Id);
            if (productPriceBD != null)
            {

                productPriceBD.ProductId = productPrice.ProductId;
                productPriceBD.PriceTypeId = productPrice.PriceTypeId;
                productPriceBD.Amount = productPrice.Amount;

                _db.SaveChanges();
            }
        }

        public IEnumerable<SelectListItem> GetPriceTypesListDropDown(string obj)
        {
            if (obj == "PriceType")
            {
                return _db.PriceTypes.Select(i => new SelectListItem()
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

        public IEnumerable<SelectListItem> GetProductsListDropDown(string obj)
        {
            if (obj == "Product")
            {
                return _db.Products.Select(i => new SelectListItem()
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

        public IEnumerable<SelectListItem> GetProductPricesListByIdDropDown(string obj, int productId)
        {
            if (obj == "ProductPrices")
            {
                var productPrices = _db.ProductPrices.Where(p => p.ProductId == productId).Select(i => new SelectListItem()
                {
                    Text = $"{i.PriceType.Name} - {i.Amount}",
                    Value = i.Amount.ToString() 
                }).ToList();

                return productPrices;
            }
            else
            {
                return null;
            }
        }

    }

    


}

