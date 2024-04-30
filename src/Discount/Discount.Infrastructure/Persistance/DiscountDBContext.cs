using Discount.Application.Abstractions;
using Discount.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discount.Infrastructure.Persistance
{
    public class DiscountDBContext : DbContext, IDiscountDbContext
    {
        public DiscountDBContext(DbContextOptions<DiscountDBContext> options) : base (options)
        {
            
        }

        public DbSet<ProductDiscount> Discounts { get; set; }

    }
}
