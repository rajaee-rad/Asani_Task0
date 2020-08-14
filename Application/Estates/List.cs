using MediatR;
using Asani_Task0.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;

namespace Asani_Task0.Application.Estates
{
    public class List
    {
        public class Query : IRequest<List<Estate>>
        {

        }
        public class Handler : IRequestHandler<Query, List<Estate>>
        {
            private readonly Task0Context _context;
            public Handler(Task0Context context)
            {
                _context = context;
            }

            public async Task<List<Estate>> Handle(Query request, CancellationToken cancellationToken)
            {
                try
                {
                    var estates = await _context.Estates.Where(x => x.IsDeleted == false).ToListAsync();

                    return estates;
                }
                catch (Exception)
                {
                    throw new Exception("problem");
                }
            }
        }
    }
}