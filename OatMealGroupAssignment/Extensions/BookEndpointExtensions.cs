
using DataAccess;
using DataAccess.Entities;

namespace OatMealGroupAssignment.Extensions;

public static class BookEndpointExtensions
{
    public static IEndpointRouteBuilder BookEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/book");

        group.MapPost("/", AddBook);
        group.MapGet("/", GetAllBooks);
        group.MapPut("/{id}", UpdateBook);

        return app;
    }

    private static void UpdateBook(OatMealDbContext context, Book book, int id)
    {
        book.Id = id;
        var updatedBook = context.Books.FirstOrDefault(i => i.Id == id);
        updatedBook.Title = book.Title;
        updatedBook.Price = book.Price;
        updatedBook.AuthorId = book.AuthorId;
        //context.Update(updatedBook); // Behövs ej.
        context.SaveChanges();
    }

    private static List<Book> GetAllBooks(OatMealDbContext context)
    {
        return context.Books.ToList();
    }

    private static void AddBook(OatMealDbContext context, Book book)
    {
        context.Add(book);
        context.SaveChanges();
    }
}