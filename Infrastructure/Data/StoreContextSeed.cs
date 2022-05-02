using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext context, ILoggerFactory loggerfactory)
        {
            try
            {

                #region Product brands
                if (!context.ProductBrands.Any())
                {
                    var brandsData = File.ReadAllText("../Infrastructure/Data/SeedData/brands.json");
                    var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);

                    foreach (var item in brands)
                    {
                        context.ProductBrands.Add(item);
                    }
                }
                #endregion Product brands
                 

                #region Product Types
                if (!context.ProductTypes.Any())
                {
                    var productTypesData = File.ReadAllText("../Infrastructure/Data/SeedData/types.json");
                    var productTypes = JsonSerializer.Deserialize<List<ProductType>>(productTypesData);

                    foreach (var item in productTypes)
                    {
                        context.ProductTypes.Add(item);
                    }
                }
                #endregion Product Types 

                #region Products
                if (!context.Products.Any())
                {
                    var productData = File.ReadAllText("../Infrastructure/Data/SeedData/products.json");
                    var products = JsonSerializer.Deserialize<List<Product>>(productData);

                    foreach (var item in products)
                    {
                        context.Products.Add(item);
                    }
                }
                #endregion Products

                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                var logger = loggerfactory.CreateLogger<StoreContextSeed>();
                logger.LogError(ex.Message);
            }
        }
    }
}