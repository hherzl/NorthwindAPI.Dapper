using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NorthwindApi.Dapper.Models;
using NorthwindApi.Responses;

namespace NorthwindApi.Dapper.Controllers
{
    [Route("api/[controller]")]
    public class NorthwindController : Controller
    {
        protected ILogger Logger;
        protected INorthwindRepository Repository;

        public NorthwindController(ILogger logger, INorthwindRepository repository)
        {
            Logger = logger;
            Repository = repository;
        }

        // GET: api/values
        [HttpGet("Product")]
        public async Task<IListResponse<Product>> GetProductsAsync()
        {
            Logger?.LogDebug("'{0}' has been invoked", nameof(GetProductsAsync));

            var response = new ListResponse<Product>();

            try
            {
                response.Model = (await Repository.GetProductsAsync()).ToList();
            }
            catch (Exception ex)
            {
                response.SetError(Logger, ex);
            }

            return response;
        }

        // GET: api/values
        [HttpGet("Product/{id}")]
        public async Task<ISingleResponse<Product>> GetProductAsync(int id)
        {
            Logger?.LogDebug("'{0}' has been invoked", nameof(GetProductAsync));

            var response = new SingleResponse<Product>();

            try
            {
                response.Model = await Repository.GetProductAsync(new Product { ProductID = id });
            }
            catch (Exception ex)
            {
                response.SetError(Logger, ex);
            }

            return response;
        }
    }
}
