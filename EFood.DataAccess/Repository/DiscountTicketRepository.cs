using EFood.DataAccess.Data;
using EFood.DataAccess.Repository.IRepository;
using EFood.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFood.DataAccess.Repository
{
    public class DiscountTicketRepository : Repository<DiscountTicket>, IDiscountTicketRepository
    {
        private readonly ApplicationDbContext _db;

        public DiscountTicketRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(DiscountTicket discountTicket)
        {
            var discountTicketBD = _db.DiscountTickets.FirstOrDefault(c => c.Id == discountTicket.Id);
            if (discountTicketBD != null)
            {
                discountTicketBD.Name = discountTicket.Name;
                discountTicketBD.Availabletickets = discountTicket.Availabletickets;
                discountTicketBD.Discount = discountTicket.Discount;

                _db.SaveChanges();
            }
        }
    }
}
