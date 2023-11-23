using EFood.models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFood.DataAccess.Repository.IRepository
{
    public interface IPaymentProcessorCardRepository : IRepository<PaymentProcessorCard>
    {
        void Update(PaymentProcessorCard paymentProcessorCard);

        IEnumerable<SelectListItem> GetCardList(string obj);

        IEnumerable<SelectListItem> GetPaymentProcessorList(string obj);

        IEnumerable<SelectListItem> GetCardNameList(string obj);

    }
}
