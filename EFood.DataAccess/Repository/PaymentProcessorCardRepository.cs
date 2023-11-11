using EFood.DataAccess.Data;
using EFood.DataAccess.Repository.IRepository;
using EFood.models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFood.DataAccess.Repository
{
    public class PaymentProcessorCardRepository : Repository<PaymentProcessorCard>, IPaymentProcessorCardRepository
    {
        private readonly ApplicationDbContext _db;

        public PaymentProcessorCardRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(PaymentProcessorCard paymentProcessorCard)
        {
            var paymentProcessorCardBD = _db.PaymentProcessorCards.FirstOrDefault(c => c.Id == paymentProcessorCard.Id);
            if (paymentProcessorCardBD != null)
            {

                paymentProcessorCardBD.PaymentProcessorId = paymentProcessorCard.PaymentProcessorId;
                paymentProcessorCardBD.CardId = paymentProcessorCard.CardId;

                _db.SaveChanges();
            }
        }

        public IEnumerable<SelectListItem> GetCardList(string obj)
        {
            if (obj == "Card")
            {
                return _db.Cards.Select(i => new SelectListItem()
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

        public IEnumerable<SelectListItem> GetPaymentProcessorList(string obj)
        {
            if (obj == "PaymentProcessor")
            {
                return _db.PaymentProcessors.Select(i => new SelectListItem()
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
