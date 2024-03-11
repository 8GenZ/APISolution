using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApplication6.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddIdentityApiEndpoints<IdentityUser>()
    .AddDefaultTokenProviders()
    .AddEntityFrameworkStores<ProductsAPIDbContext> ();

builder.Services.AddAuthorization();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddDbContext<ApplicationDbContext>(
//    options => options.UseInMemoryDatabase("AppDb"));

builder.Services.AddDbContext<ProductsAPIDbContext>(options => options.UseInMemoryDatabase("ProductsDb"));
//builder.Services.AddDbContext<ProductsAPIDbContext>(options => options.UseSqlServer(
//  builder.Configuration.GetConnectionString("ProductsApiConnectionString"))); 


var app = builder.Build();

app.MapIdentityApi<IdentityUser>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
