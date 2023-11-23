using EFood.models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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


        public IEnumerable<string> ProcessorType { get; set; } = new List<string> { "Tarjeta de Crédito o Débito", "Efectivo", "Cheque Electrónico" };

        public IEnumerable<SelectListItem> CardList { get; set; }
    }
}
