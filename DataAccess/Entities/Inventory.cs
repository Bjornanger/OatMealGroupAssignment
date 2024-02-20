using Microsoft.EntityFrameworkCore;

namespace DataAccess.Entities;

[PrimaryKey(nameof(BookId), (nameof(StoreId)))]
public class Inventory
{

    
    public int Quantity { get; set; }
   
    public int BookId { get; set; }

    public int StoreId { get; set; }
    
}