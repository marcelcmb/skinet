using System.Text.Json;
using Core.Entities;

namespace Infrastructure.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext context)
        {
            if (!context.ProductBrands.Any())
            {
                var brandsData = File.ReadAllText("../Infrastructure/Data/SeedData/brands.json");
                var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);
#pragma warning disable CS8604 // Possible null reference argument.
                context.ProductBrands.AddRange(brands);
#pragma warning restore CS8604 // Possible null reference argument.
            }

            if (!context.ProductTypes.Any())
            {
                var typesData = File.ReadAllText("../Infrastructure/Data/SeedData/types.json");
                var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);
#pragma warning disable CS8604 // Possible null reference argument.
                context.ProductTypes.AddRange(types);
#pragma warning restore CS8604 // Possible null reference argument.

            }
            if (!context.Products.Any())
            {
                var productData = File.ReadAllText("../Infrastructure/Data/SeedData/products.json");
                var products = JsonSerializer.Deserialize<List<Product>>(productData);
#pragma warning disable CS8604 // Possible null reference argument.
                context.Products.AddRange(products);
#pragma warning restore CS8604 // Possible null reference argument.
            }

            if (context.ChangeTracker.HasChanges())
            {
                await context.SaveChangesAsync();
            }
        }
    }
}
