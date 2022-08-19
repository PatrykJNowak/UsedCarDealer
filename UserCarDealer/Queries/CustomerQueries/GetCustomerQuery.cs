using System.Collections.Generic;
using MediatR;
using UserCarDealer.DataModels;

namespace UserCarDealer.Queries.CustomerQueries
{
    public class GetCustomerQuery : IRequest<IEnumerable<Customer>> {}
}