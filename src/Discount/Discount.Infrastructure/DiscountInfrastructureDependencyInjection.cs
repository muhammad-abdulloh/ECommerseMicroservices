using Discount.Application.Abstractions;
using Discount.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discount.Infrastructure
{
    public static class DiscountInfrastructureDependencyInjection
    {
        public static IServiceCollection AddDIscountInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<IDiscountDbContext, DiscountDBContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("ECommerceLessonDiscountConnectionString"));
            });

            return services;
        }
    }
}
