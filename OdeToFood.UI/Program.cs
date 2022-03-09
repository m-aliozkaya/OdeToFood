using Microsoft.EntityFrameworkCore;
using OdeToFood.Data;
using OdeToFood.UI.Extensions;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContextPool<OdeToFoodDbContext>(options =>
{
    options.UseSqlServer(config.GetConnectionString("OdeToFoodDb"));
});
builder.Services.AddScoped<IRestaurantData, SqlRestaurantData>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

//app.Use(async (context, next) =>
//{
//    await context.Response.WriteAsync("Use baþladý");
//    await next.Invoke();
//    await context.Response.WriteAsync("Use bitti");
//});

//app.Run(async handler =>
//{
//    await handler.Response.WriteAsync("Run baþladý");
//});


app.UseStaticFiles();
app.UseNodeModules();
app.UseRouting();

app.UseAuthorization();
app.UseHello();

app.MapRazorPages();
app.MapControllers();

app.Run();