using EFood.models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace EFood.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public  DbSet<Card> Cards { get; set; }

        public  DbSet<DiscountTicket> DiscountTickets { get; set; }

        public  DbSet<Error> Errors { get; set; }

        public  DbSet<FoodLine> FoodLines { get; set; }

        public  DbSet<Logbook> Logbooks { get; set; }

        public  DbSet<Order> Orders { get; set; }

        public  DbSet<OrdersProduct> OrdersProducts { get; set; }

        public  DbSet<PaymentProcessor> PaymentProcessors { get; set; }

        public  DbSet<PaymentProcessorCard> PaymentProcessorCards { get; set; }

        public  DbSet<Price> Prices { get; set; }

        public  DbSet<PriceType> PriceTypes { get; set; }

        public  DbSet<Product> Products { get; set; }

        public  DbSet<ProductPrice> ProductPrices { get; set; }

        public  DbSet<Status> Statuses { get; set; }

        public  DbSet<User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }

}