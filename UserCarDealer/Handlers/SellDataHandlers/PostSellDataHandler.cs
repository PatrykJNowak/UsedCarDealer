using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using UserCarDealer.Command.SellDataCommand;
using UserCarDealer.DataModels;

namespace UserCarDealer.Handlers.SellDataHandlers
{
    public class PostSellDataHandler : IRequestHandler<PostSellDataCommand, int>
    {
        private readonly Context _context;
        public Context Context { get; }

        public PostSellDataHandler(Context context)
        {
            Context = context;
            _context = context;
        }

        public async Task<int> Handle(PostSellDataCommand request, CancellationToken cancellationToken)
        {
            var dbQuestForVehicle = _context.Vehicles
                .FirstOrDefault(x => x.Id == request.PostSellDataDto.VehicleId);

            var dbQuestForCustomer = _context.Customer
                .FirstOrDefault(x => x.Id == request.PostSellDataDto.CustomerId);

            if (dbQuestForCustomer != null && dbQuestForCustomer != null)
            {
                var resultQueryToDb = _context.SellData
                    .Where(x => x.CustomerId == request.PostSellDataDto.CustomerId)
                    .Where(y => y.VehicleId == request.PostSellDataDto.VehicleId)
                    .ToList();

                if (resultQueryToDb.Count == 0)
                {
                    var newSellData = new SellData()
                    {
                        CustomerId = request.PostSellDataDto.CustomerId,
                        VehicleId = request.PostSellDataDto.VehicleId,
                        Date = request.PostSellDataDto.Data,
                    };


                    var ownerCounter = _context.Vehicles
                        .FirstOrDefault(x => x.Id == request.PostSellDataDto.VehicleId);

                    //increment owner counter in vehicle entity (from  ownerCounter to _context.Update
                    ownerCounter.OwnerCount++;
                    _context.Update(ownerCounter);
                    var result = _context.Add(newSellData);
                    await _context.SaveChangesAsync(cancellationToken);
                    
                    return result.Entity.Id;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return 0;
            }
        }
    }
}