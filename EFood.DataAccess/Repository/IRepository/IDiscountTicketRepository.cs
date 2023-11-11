using EFood.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFood.DataAccess.Repository.IRepository
{
    public interface IDiscountTicketRepository : IRepository<DiscountTicket>
    {
        void Update(DiscountTicket discountTicket);
    }
}
