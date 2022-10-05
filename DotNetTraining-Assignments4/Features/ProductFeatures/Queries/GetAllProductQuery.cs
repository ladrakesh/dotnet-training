using DotNetTraining_Assignments4.DbContexts;
using DotNetTraining_Assignments4.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DotNetTraining_Assignments4.Features.ProductFeatures.Queries
{
    public class GetAllProductQuery : IRequest<IEnumerable<Product>>
    {
        public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQuery, IEnumerable<Product>>
        {
            private readonly IApplicationDbContext _context;
            public GetAllProductQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<IEnumerable<Product>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
            {
                var products = await _context.Products.ToListAsync();

                if (products == null) return new List<Product>();

                return products.AsReadOnly();
            }
        }
    }
}
