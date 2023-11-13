using EFood.models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFood.DataAccess.Repository.IRepository
{
    public interface IProductPriceRepository : IRepository<ProductPrice>
    {
        void Update(ProductPrice productPrice);

        IEnumerable<SelectListItem> GetPriceTypesListDropDown(string obj);

        IEnumerable<SelectListItem> GetProductsListDropDown(string obj);

    }
}
