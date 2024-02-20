
using DataAccess;
using DataAccess.Entities;

namespace OatMealGroupAssignment.Extensions;
public static class BookEndpointExtensions
{
    public static IEndpointRouteBuilder BookEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/book");

        group.MapPost("/{authorId}", AddBook);
        group.MapGet("/", GetAllBooks);
        group.MapPut("/{id}", UpdateBook);
        group.MapPut("/{id}", DeleteBook);

        return app;
    }

    private static void DeleteBook(OatMealDbContext context, int id)
    {
        var book = context.Books.FirstOrDefault(b => b.Id == id);
        context.Books.Remove(book);
        context.SaveChanges();
    }

    private static void UpdateBook(OatMealDbContext context, Book book, int id)
    {
        book.Id = id;
        var updatedBook = context.Books.FirstOrDefault(i => i.Id == id);
        updatedBook.Title = book.Title;
        updatedBook.Price = book.Price;
        updatedBook.Authors = book.Authors;
        //context.Update(updatedBook); // Behövs ej.
        context.SaveChanges();
    }

    private static List<Book> GetAllBooks(OatMealDbContext context)
    {
        return context.Books.Select(b => new Book
        {
            Id = b.Id,
            Title = b.Title,
            Price = b.Price,
            Authors = b.Authors

        }).ToList();
    }

    private static void AddBook(OatMealDbContext context, Book book, int authorId)
    {
        var author = context.Authors.FirstOrDefault(a => a.Id == authorId);
        book.Authors.Add(author);
        context.Add(book);
        context.SaveChanges();

    }
}