using MediatR;
using Asani_Task0.Models;
using System.Threading.Tasks;
using System.Threading;
using System;
using Newtonsoft.Json;

public class Create
{
    public class Command : IRequest
    {
        [JsonProperty(PropertyName = "owner_id")]
        public int OwnerId { get; set; }
        public float Area { get; set; }
        public string Position { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        [JsonProperty(PropertyName = "userid_creator")]
        public int UserIdCreator { get; set; }
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
            var estate = new Estate
            {
                OwnerId = request.OwnerId,
                Area = request.Area,
                Position = request.Position,
                Address = request.Address,
                Description = request.Description,
                UserIdCreator = request.UserIdCreator, //Need Authentication System.
                Log = "Create",
                Timestamp = DateTime.Now
            };
            _context.Add(estate);
            var success = await _context.SaveChangesAsync() > 0;
            if (success) return Unit.Value;
            throw new Exception("problem saving change");


        }
    }
}