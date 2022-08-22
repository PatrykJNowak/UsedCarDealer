using System.Collections.Generic;
using MediatR;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using UserCarDealer.DataModels;
using UserCarDealer.Handlers.SellDataHandlers.Dto;

namespace UserCarDealer.Command.SellDataCommand
{
    public class PostSellDataCommand : IRequest<int>
    {
        public PostSellDataDto PostSellDataDto { get; set; }
    }
}