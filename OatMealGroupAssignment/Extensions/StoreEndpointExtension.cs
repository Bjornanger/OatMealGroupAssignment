using DataAccess;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace OatMealGroupAssignment.Extensions;

public static class StoreEndpointExtension
{
    public static IEndpointRouteBuilder StoreEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/store");

        group.MapPost("/", AddStore);
        group.MapGet("/", GetAllStores);
        group.MapPut("/{id}", UpdateStore);
        group.MapDelete("/{id}", DeleteStore);

        return app;
    }

    private static void DeleteStore(OatMealDbContext context, int id)
    {
        var deleteStore = context.Stores.FirstOrDefault(s => s.Id == id);
        context.Stores.Remove(deleteStore);
        context.SaveChanges();
    }

    private static void UpdateStore(OatMealDbContext context, Store store, int id)
    {
        var updateStore = context.Stores.FirstOrDefault(s => s.Id == id);
        updateStore.Name = store.Name;
        updateStore.Address = store.Address;
        context.SaveChanges();
    }

    private static List<Store> GetAllStores(OatMealDbContext context)
    {
        return context.Stores.ToList();
    }

    private static void AddStore(OatMealDbContext context, Store store)
    {
        context.Stores.Add(store);
        context.SaveChanges();
    }
}