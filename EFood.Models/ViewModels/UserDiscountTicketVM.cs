using EFood.models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFood.Models.ViewModels
{
    public class UserDiscountTicketVM
    {
        public UserDiscountTicket UserDiscountTicket { get; set; }

        public IEnumerable<SelectListItem> UserList { get; set; }

        public IEnumerable<SelectListItem> DiscountTicketList { get; set; }
    }
}
