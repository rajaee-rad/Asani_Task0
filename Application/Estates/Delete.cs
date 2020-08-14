using System;
using System.Threading;
using System.Threading.Tasks;
using Asani_Task0.Models;
using MediatR;
using Newtonsoft.Json;

namespace Asani_Task0.Application.Estates
{
    public class Delete
    {

        public class Command : IRequest
        {
            public int Id { get; set; }
            public bool IsDeleted { get; set; }
            [JsonProperty(PropertyName = "userid_modifer")]
            public int UserIdModifer { get; set; }
            public string Log { get; set; }
            public DateTime Timestamp { get; set; }
        }
        public class Handler : IRequestHandler<Command>
        {
            private readonly Task0Context _context;
            public Handler(Task0Context context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var estate = await _context.Estates.FindAsync(request.Id);
                if (estate == null)
                    throw new Exception("Estate not found!!");
                estate.IsDeleted = true;
                estate.Timestamp = DateTime.Now;
                estate.UserIdModifer = request.UserIdModifer; //Need Authentication System
                estate.Log = "Delete";

                var success = await _context.SaveChangesAsync() > 0;
                if (success) return Unit.Value;
                throw new Exception("problem saving change");
            }
        }
    }
}