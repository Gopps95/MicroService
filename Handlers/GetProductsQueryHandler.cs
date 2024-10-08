﻿using MicroService.Interfaces;
using MicroService.Models;
using MicroService.Queries.Query_Model;


namespace MicroService.Handlers
{
   
        public class GetProductsQueryHandler : IQueryHandler<GetProductsQuery, IEnumerable<GetAllProductCommand>>
        {
            private readonly IRepository<Product> _repository; // Inject repository or database context

            public GetProductsQueryHandler(IRepository<Product> repository)
            {
                _repository = repository;
            }

            public async Task<IEnumerable<GetAllProductCommand>> Handle(GetProductsQuery query)
            {
                var products = await _repository.GetAllAsync(); // Implement repository method
                                                                // Map products to ProductViewModel
                return products.Select(p => new GetAllProductCommand
                {
                    Id = p.ProductID,
                    Name = p.ProductName,
                    Price = p.UnitPrice
                });
            }
        }

    
}
