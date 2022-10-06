using DotNetTraining_Assignments4.DbContexts;
using MediatR;

namespace DotNetTraining_Assignments4.Features.CategoryFeatures.Queries
{
    public class GetCategoryIdByNameQuery : IRequest<int>
    {
        public string CategoryName { get; set; }

        public class GetCategoryIdByNameQueryHandler : IRequestHandler<GetCategoryIdByNameQuery, int>
        {

            private readonly IApplicationDbContext _context;
            public GetCategoryIdByNameQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(GetCategoryIdByNameQuery request, CancellationToken cancellationToken)
            {
                var category = _context.Categories.Where(a => a.Name == request.CategoryName).FirstOrDefault();
                if (category == null) return 0;

                return category.Id;
            }
        }
    }
}
