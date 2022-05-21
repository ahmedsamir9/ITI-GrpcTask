using Grpc.Core;
using InentoryService.model;
using InentoryService.Protos;
using static InentoryService.Protos.InventoryService;

namespace InentoryService.Services
{
    public class ProductsService :InventoryServiceBase
    {
        public static List<Product> products = new List<Product>()
        {
            new Product(){Id = 1, Name ="a",NumInStock = 2,Price= 45},
            new Product(){Id = 2, Name ="b",NumInStock = 3,Price= 45},
            new Product(){Id = 3, Name ="c",NumInStock = 2,Price= 45},
            new Product(){Id = 4, Name ="d",NumInStock = 0,Price= 45},
        };
        public override Task<ItemAValibleResponse> checkItemAvaliabilty(ItemData request, ServerCallContext context)
        {
            var product = products.FirstOrDefault(p => p.Id == request.ItemId);
            if (product == null) return Task.FromResult(new ItemAValibleResponse { IsAvaliable = false });
            if (product.NumInStock < request.ItemQuantity) return Task.FromResult(new ItemAValibleResponse { });
            product.NumInStock -= request.ItemQuantity;
            return Task.FromResult(new ItemAValibleResponse { IsAvaliable = true });
        }
    }
}
