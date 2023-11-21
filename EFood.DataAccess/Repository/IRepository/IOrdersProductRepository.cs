using EFood.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFood.DataAccess.Repository.IRepository
{
    public interface IOrdersProductRepository : IRepository<OrdersProduct>
    {
        void Update(OrdersProduct OrderProduct);
    }
}
