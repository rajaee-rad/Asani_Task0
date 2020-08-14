using MediatR;
using Asani_Task0.Models;
using System.Threading.Tasks;
using System.Threading;
using System;
using Newtonsoft.Json;
namespace Asani_Task0.Application.Estates
{
    public class Edit
    {
        public class Command : IRequest
        {
            public int Id { get; set; }

            [JsonProperty(PropertyName = "owner_id")]
            public int OwnerId { get; set; }
            public float Area { get; set; }
            public string Position { get; set; }
            public string Address { get; set; }
            public string Description { get; set; }
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
            public async Task<MediatR.Unit> Handle(Command request, CancellationToken cancellationToken)
            {

                var estate = await _context.Estates.FindAsync(request.Id);
                if (estate == null)
                    throw new Exception("plant not found!");

                estate.OwnerId = request.OwnerId;
                estate.Area = request.Area;
                estate.Position = request.Position ?? estate.Position;
                estate.Address = request.Address ?? estate.Address;
                estate.Description = request.Description ?? estate.Description;
                estate.Timestamp = DateTime.Now;
                estate.UserIdModifer = request.UserIdModifer; //Need Authentication System
                estate.Log = "Edit";

                var success = await _context.SaveChangesAsync() > 0;
                if (success) return Unit.Value;
                throw new Exception("problem saving change");
            }

        }

    }
}