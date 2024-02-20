using DataAccess;
using Microsoft.EntityFrameworkCore;
using OatMealGroupAssignment.Extensions;

var builder = WebApplication.CreateBuilder(args);

var connectionsString = builder.Configuration.GetConnectionString("OatMealBookDb");


builder.Services.AddDbContext<OatMealDbContext>(options =>
{
    options.UseSqlServer(connectionsString);
});


// Add services to the container.

var app = builder.Build();

app.BookEndpoints();
app.AuthorEndPoints();
app.StoreEndpoints();



// Configure the HTTP request pipeline.

app.UseHttpsRedirection();



app.Run();


