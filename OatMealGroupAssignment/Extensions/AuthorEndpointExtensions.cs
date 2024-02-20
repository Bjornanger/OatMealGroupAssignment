using DataAccess;
using DataAccess.Entities;

namespace OatMealGroupAssignment.Extensions;

public static class AuthorEndpointExtensions
{
    public static IEndpointRouteBuilder AuthorEndPoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/author");

        group.MapPost("/{bookId}", AddAuthor);
        group.MapGet("/", GetAllAuthors);
        group.MapPut("/{id}", UpdateAuthor);
        group.MapDelete("/{id}", DeleteBook);

        return app;
    }

    private static void DeleteBook(OatMealDbContext context, int id)
    {
        var author = context.Authors.FirstOrDefault(a => a.Id == id);
        context.Authors.Remove(author);
        context.SaveChanges();
    }

    private static void UpdateAuthor(OatMealDbContext context, int id, Author author)
    {
        //
        var updatedAuthor = context.Authors.FirstOrDefault(i => i.Id == id);
        updatedAuthor.Name = author.Name;
        updatedAuthor.Books = author.Books;
        context.SaveChanges();
    }

    private static List<Author> GetAllAuthors(OatMealDbContext context)
    {
        return context.Authors.Select(a => new Author
        {
            Id = a.Id,
            Name = a.Name,
            Books = a.Books
        }).ToList();
    }

    private static void AddAuthor(OatMealDbContext context, Author author, int bookId)
    {
        var book = context.Books.FirstOrDefault(b => b.Id == bookId);
        author.Books.Add(book);
        context.Authors.Add(author);
        context.SaveChanges();

        //var author = context.Authors.FirstOrDefault(a => a.Id == authorId);
        //book.Authors.Add(author);
        //context.Add(book);
    }


}