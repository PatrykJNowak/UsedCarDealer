using System.Linq;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using UserCarDealer.Command.CustomerCommand;
using UserCarDealer.DataModels;

namespace UserCarDealer.Handlers.CustomerHandlers
{
    public class PostCustomerHandler : IRequestHandler<PostCustomerCommand, int>
    {
        private readonly Context _context;
        public Context Context { get; }

        public PostCustomerHandler(Context context)
        {
            _context = context;
            Context = context;
        }

        public async Task<int> Handle(PostCustomerCommand request, CancellationToken cancellationToken)
        {
            var validPostUser = _context.Customer
                .FirstOrDefault(x => x.PresonalId == request.PostCustomerDto.PresonalId);

            if (validPostUser == null)
            {
                var postCustomer = new Customer()
                {
                    Name = request.PostCustomerDto.Name,
                    SurName = request.PostCustomerDto.SurName,
                    PresonalId = request.PostCustomerDto.PresonalId,
                };

                var result = _context.Customer.Add(postCustomer);
                await _context.SaveChangesAsync(cancellationToken);
                return result.Entity.Id;
            }
            return 0;
        }
    }
}