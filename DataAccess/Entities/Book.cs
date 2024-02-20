using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Entities;

public class Book
{
    [Key]
    public int Id { get; set; }
    public string Title { get; set; }
    public double Price { get; set; }

    public List<Author> AuthorId { get; set; } = new List<Author>();
}