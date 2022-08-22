using System.Collections.Generic;
using MediatR;
using UserCarDealer.DataModels;

namespace UserCarDealer.Queries.SellDataQueries
{
    public class GetSellDataQuery : IRequest<IEnumerable<SellData>>, IRequest<IEnumerator<SellData>>
    {}
}