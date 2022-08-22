using MediatR;
using UserCarDealer.DataModels;

namespace UserCarDealer.Queries.CustomerQueries
{
    public class GetCustomerByIdQuery: IRequest<Customer> 
    {
        public int Id { get; set; }
    }
}