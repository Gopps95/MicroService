using MicroService.Interfaces;
using MicroService.Models;
using MicroService.Queries.Command_Model;

namespace MicroService.Handlers
{
    
        public class CreateProductCommandHandler : ICommandHandler<CreateProductCommand>
        {
            private readonly IRepository<Product> _repository;

            public CreateProductCommandHandler(IRepository<Product> repository)
            {
                _repository = repository;
            }

            public async Task Handle(CreateProductCommand command)
            {
                var product = new Product
                {
                    ProductName = command.Name,
                    UnitPrice = command.Price
                };

                await _repository.AddAsync(product);
                await _repository.SaveAsync();
            }
        }

    
}
