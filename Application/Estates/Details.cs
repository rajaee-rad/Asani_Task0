using MediatR;
using Asani_Task0.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Asani_Task0.Application.Estates
{
    public class Details
    {
        public class Query : IRequest<Estate>
        {
            public int Id { get; set; }
        }
        public class Handler : IRequestHandler<Query, Estate>
        {
            private readonly Task0Context _context;
            public Handler(Task0Context context)
            {
                _context = context;
            }


            public async Task<Estate> Handle(Query request, CancellationToken cancellationToken)
            {
                var estate = await _context.Estates.Where(x => x.IsDeleted == false).FirstAsync();
                return estate;
            }
        }
    }
}