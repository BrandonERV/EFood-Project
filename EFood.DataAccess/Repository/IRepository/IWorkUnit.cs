using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFood.DataAccess.Repository.IRepository
{
    public interface IWorkUnit : IDisposable
    {
        IUserRepository User { get;  }
        
        ICardRepository Card { get;  }

        IPaymentProcessorRepository PaymentProcessor { get;  }

        IPriceTypeRepository PriceType { get; }

        IFoodLineRepository FoodLine { get; }

        IProductRepository Product { get; }

        IProductPriceRepository ProductPrice { get; }

        IPaymentProcessorCardRepository PaymentProcessorCard { get; }

        IDiscountTicketRepository DiscountTicket { get;  }

        IUserDiscountTicketRepository UserDiscountTicket { get; }



        Task Save();

    }
}
