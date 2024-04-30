using Discount.Application.Abstractions;
using Discount.Application.UseCases.DiscountCases.Queries;
using Discount.Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discount.Application.UseCases.DiscountCases.Handlers.QueryHandlers
{
    public class GetAllDiscountsQueryHandler : IRequestHandler<GetAllDiscountsQuery, IEnumerable<ProductDiscount>>
    {
        private readonly IDiscountDbContext _context;

        public GetAllDiscountsQueryHandler(IDiscountDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductDiscount>> Handle(GetAllDiscountsQuery request, CancellationToken cancellationToken)
        {
            var discounts = await _context.Discounts.ToListAsync();

            return discounts;
        }
    }
}
