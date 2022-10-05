using DotNetTraining_Assignments4.DbContexts;
using DotNetTraining_Assignments4.Models;
using DotNetTraining_Assignments4.Models.Dtos;
using MediatR;

namespace DotNetTraining_Assignments4.Features.ProductFeatures.Commands
{
    public class CreateProductCommand : Product, IRequest<int>
    {
        public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
        {
            private readonly ApplicationDbContext _context;

            public CreateProductCommandHandler(ApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
            {   
                var product = new Product();
                product.Name = request.Name;
                product.Price = request.Price;
                product.Description = request.Description;
                product.CategoryId = request.CategoryId;                  
                _context.Products.Add(product);
                await _context.SaveChanges();
                return product.ProductId;
            }
        }
    }
}
