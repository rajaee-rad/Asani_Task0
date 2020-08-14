using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Asani_Task0.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Asani_Task0.Application.Owners
{
    public class List
    {
        public class Query : IRequest<List<Owner>>
        {

        }
        public class Handler : IRequestHandler<Query, List<Owner>>
        {
            private readonly Task0Context _context;
            public Handler(Task0Context context)
            {
                _context = context;
            }
            public async Task<List<Owner>> Handle(Query request, CancellationToken cancellationToken)
            {
                var owners = await _context.Owners.ToListAsync();
                return owners;
            }
        }
    }
}