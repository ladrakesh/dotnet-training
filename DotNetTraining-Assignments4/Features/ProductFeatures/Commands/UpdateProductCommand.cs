using DotNetTraining_Assignments4.DbContexts;
using DotNetTraining_Assignments4.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DotNetTraining_Assignments4.Features.ProductFeatures.Commands
{
    public class UpdateProductCommand :Product, IRequest<int>
    {
        public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, int>
        {
            private readonly IApplicationDbContext _context;

            public UpdateProductCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
            {
                var product = await _context.Products.Where(u => u.ProductId == request.ProductId).FirstOrDefaultAsync();

                if (product == null) return default;

                product.Name = request.Name;
                product.Price = request.Price;
                product.Description = request.Description;
                product.CategoryId = request.CategoryId;

                await _context.SaveChanges();

                return product.ProductId;
            }
        }
    }
}
