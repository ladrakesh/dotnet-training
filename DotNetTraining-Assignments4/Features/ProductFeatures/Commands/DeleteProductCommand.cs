using DotNetTraining_Assignments4.DbContexts;
using DotNetTraining_Assignments4.Features.ProductFeatures.Queries;
using DotNetTraining_Assignments4.Models;
using MediatR;

namespace DotNetTraining_Assignments4.Features.ProductFeatures.Commands
{
    public class DeleteProductCommand:IRequest<int>
    {
        public int ProductId { get; set; }

        public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Product>
        {

            private readonly IApplicationDbContext _context;
            public GetProductByIdQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
            {
                var products = _context.Products.Where(a => a.ProductId == request.ProductId).FirstOrDefault();
                if (products == null) return default;

                return products;
            }
        }
    }
}
