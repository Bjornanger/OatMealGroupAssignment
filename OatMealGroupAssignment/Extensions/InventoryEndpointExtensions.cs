using DataAccess;
using DataAccess.Entities;

namespace OatMealGroupAssignment.Extensions
{
    public static class InventoryEndpointExtensions
    {
        public static IEndpointRouteBuilder InventoryEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("api/inventory");

            group.MapPost("/", AddInventory);
            //group.MapGet("/", GetAllBooks);
            //group.MapPut("/{id}", UpdateBook);
            //group.MapPut("/{id}", DeleteBook);

            return app;
        }

        private static void AddInventory(OatMealDbContext context, Inventory inventory)
        {
            context.Inventories.Add(inventory);
            context.SaveChanges();
        }
    }
}
