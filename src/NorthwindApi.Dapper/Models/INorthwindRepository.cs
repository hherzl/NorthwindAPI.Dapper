﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace NorthwindApi.Dapper.Models
{
    public interface INorthwindRepository
    {
        Task<IEnumerable<Product>> GetProductsAsync();

        Task<Product> GetProductAsync(Product entity);

        Task<int> CreateProductAsync(Product entity);

        Task<int> UpdateProductAsync(Product entity);

        Task<int> DeleteProductAsync(Product entity);
    }
}
