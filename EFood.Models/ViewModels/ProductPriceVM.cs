using EFood.models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFood.Models.ViewModels
{
    public class ProductPriceVM
    {
        public ProductPrice ProductPrice { get; set; }

        public IEnumerable<SelectListItem> PriceTypeList { get; set; }

        public IEnumerable<SelectListItem> ProductList { get; set; }


    }
}
