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


        Task Save();

    }
}
