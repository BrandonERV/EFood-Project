using EFood.DataAccess.Data;
using EFood.DataAccess.Repository.IRepository;
using EFood.models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFood.DataAccess.Repository
{
    public class UserDiscountTicketRepository : Repository<UserDiscountTicket>, IUserDiscountTicketRepository
    {
        private readonly ApplicationDbContext _db;

        public UserDiscountTicketRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(UserDiscountTicket userDiscountTicket)
        {
            var userDiscountTicketBD = _db.UserDiscountTickets.FirstOrDefault(c => c.Id == userDiscountTicket.Id);
            if (userDiscountTicketBD != null)
            {

                userDiscountTicketBD.UserId = userDiscountTicket.UserId;
                userDiscountTicketBD.TicketId = userDiscountTicket.TicketId;

                _db.SaveChanges();
            }
        }

        public IEnumerable<SelectListItem> GetDiscountTicketList(string obj)
        {
            if (obj == "DiscountTicket")
            {
                return _db.DiscountTickets.Select(i => new SelectListItem()
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

        public IEnumerable<SelectListItem> GetUserList(string obj)
        {
            if (obj == "User")
            {
                return _db.Users.Select(i => new SelectListItem()
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
    }
}

