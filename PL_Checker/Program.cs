using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PL_Checker.Data.Context;
using PL_Checker.Data.SeedData;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();
//builder.Services.AddAutoMapper(new[] { System.Reflection.Assembly.GetExecutingAssembly() }, ServiceLifetime.Scoped);

// Add an In-memory database context to the project, with a localised scope
builder.Services.AddDbContext<PharmaDbContext>(options =>
{
    options.UseInMemoryDatabase("PharmaDatabase");
}, ServiceLifetime.Scoped);

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

var app = builder.Build();

// Add seed data of pharmaceuticals into the In Memory database
using (var scope = app.Services.CreateScope())
{
    var scopedServices = scope.ServiceProvider;
    SeedData_Pharma.Initialise(scopedServices);

    var context = scopedServices.GetRequiredService<PharmaDbContext>();
    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage();
    app.UseMigrationsEndPoint();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

