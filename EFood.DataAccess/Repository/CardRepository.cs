using EFood.DataAccess.Data;
using EFood.DataAccess.Repository.IRepository;
using EFood.models;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFood.DataAccess.Repository
{
    public class CardRepository : Repository<Card>, ICardRepository
    {
        private readonly ApplicationDbContext _db;

        public CardRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(Card card)
        {
           var cardBD = _db.Cards.FirstOrDefault(c => c.Id == card.Id);
            if (cardBD != null)
            {
                cardBD.Name = card.Name;

                _db.SaveChanges();
            }
        }
    }
}
