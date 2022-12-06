using Zay.ApplicationCore;
using Zay.Infrastructure;
using Zay.Infrastructure.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddApplicationCore();
builder.Services.AddIdentity<ApplicationUser, ApplicationRole>()
                    .AddMongoDbStores<ApplicationUser, ApplicationRole, Guid>
                    (
                        builder.Configuration.GetSection("MongoDB:ConnectionString").Value,
                        builder.Configuration.GetSection("MongoDB:Database").Value
                    );

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
