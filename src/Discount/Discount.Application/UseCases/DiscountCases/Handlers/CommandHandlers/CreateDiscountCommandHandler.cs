using Discount.Application.Abstractions;
using Discount.Application.UseCases.DiscountCases.Commands;
using Discount.Domain.Entities;
using Discount.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discount.Application.UseCases.DiscountCases.Handlers.CommandHandlers
{
    public class CreateDiscountCommandHandler : IRequestHandler<CreateDiscountCommand, ResponseModel>
    {
        private readonly IDiscountDbContext _context;

        public CreateDiscountCommandHandler(IDiscountDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel> Handle(CreateDiscountCommand request, CancellationToken cancellationToken)
        {
            var discunt = new ProductDiscount
            {
                ProductId = request.ProductId,
                CuponCode = request.CuponCode,
                StartDate = request.StartDate,
                EndDate = request.EndDate
            };

            await _context.Discounts.AddAsync(discunt, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return new ResponseModel
            {
                Message = "Discount Created",
                IsSuccess = true,
                StatusCode = 201
            };

        }
    }
}
