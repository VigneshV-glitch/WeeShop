using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using WeeShop.Infrastructure.DbContexts;
using WeeShop.Infrastructure;
using WeeShop.Application;
using Microsoft.AspNetCore.Identity;
using WeeShop.Application.Common;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddRepositoryService();
builder.Services.AddApplicationService();

#region  Cross Origin Resource Sharing
builder.Services.AddCors(options =>
{
    options.AddPolicy("WeeShopPolicy", x => x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});
#endregion

#region DBConnection

builder.Services.AddDbContext<ApplicationDbContext>(options=> 
    options.UseSqlServer(builder.Configuration.GetConnectionString("WeeShopConnectionString")));

builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options=>
{

}).AddEntityFrameworkStores<ApplicationDbContext>();
#endregion

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors("WeeShopPolicy");// This is From Croos Origin Resource Sharing

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
