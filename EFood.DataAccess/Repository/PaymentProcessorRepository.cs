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
    public class PaymentProcessorRepository : Repository<PaymentProcessor>, IPaymentProcessorRepository
    {
        private readonly ApplicationDbContext _db;

        public PaymentProcessorRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(PaymentProcessor paymentProcessor)
        {
           var paymentProcessorBD = _db.PaymentProcessors.FirstOrDefault(p => p.Id == paymentProcessor.Id);
            if (paymentProcessorBD != null)
            {
                paymentProcessorBD.Name = paymentProcessor.Name;
                paymentProcessorBD.Type = paymentProcessor.Type;
                paymentProcessorBD.Status = paymentProcessor.Status;
                paymentProcessorBD.Processor = paymentProcessor.Processor;
                paymentProcessorBD.Verification = paymentProcessor.Verification;
                paymentProcessorBD.Method = paymentProcessor.Method;

                _db.SaveChanges();
            }
        }
    }
}
