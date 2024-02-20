using DataAccess;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionsString = builder.Configuration.GetConnectionString("OatMealBookDb");


builder.Services.AddDbContext<OatMealDbContext>(options =>
{
    options.UseSqlServer(connectionsString);
});


// Add services to the container.

var app = builder.Build();





// Configure the HTTP request pipeline.

app.UseHttpsRedirection();



app.Run();


