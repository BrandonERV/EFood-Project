using EFood.models;
using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFood.Models.ViewModels
{
    public class PaymentProcessorCardVM
    {
        public PaymentProcessorCard PaymentProcessorCard { get; set; }

        public IEnumerable<SelectListItem> CardList{ get; set; }
    }
}
