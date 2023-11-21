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
    public class OrdersProductRepository : Repository<OrdersProduct>, IOrdersProductRepository
    {
        private readonly ApplicationDbContext _db;

        public OrdersProductRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(OrdersProduct OrderProducto)
        {
           
            _db.Update(OrderProducto);
        }
    }
}
