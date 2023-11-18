using EFood.models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFood.DataAccess.Repository.IRepository
{
    public interface IUserDiscountTicketRepository : IRepository<UserDiscountTicket>
    {
        void Update(UserDiscountTicket userDiscountTicket);

        IEnumerable<SelectListItem> GetDiscountTicketList(string obj);

        IEnumerable<SelectListItem> GetUserList(string obj);

    }
}
