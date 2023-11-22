﻿using EFood.models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFood.Models.ViewModels
{
    public class ShoppingCartVM
    {

        public Product Product { get; set; }

        public IEnumerable<SelectListItem> ProductPrices { get; set; }

        public ShoppingCart ShoppingCart { get; set; }

        public IEnumerable<ShoppingCart> ShoppingCartList { get; set; }

        public Order Order { get; set; }
    }
}
