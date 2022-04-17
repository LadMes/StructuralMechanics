using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StructuralMechanics.Utilities;

var builder = WebApplication.CreateBuilder(args);

// Services
builder.Services.AddDbContextPool<AppDbContext>(options => 
                                                options.UseSqlServer(builder.Configuration.GetConnectionString("StructuralMechanicsDbConnection")));
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
                                                            {
                                                                options.SignIn.RequireConfirmedEmail = false;
                                                            }).AddEntityFrameworkStores<AppDbContext>()
                                                              .AddDefaultTokenProviders();
builder.Services.AddControllersWithViews();
builder.Services.AddProjectServices();
builder.Services.AddModelServices();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseStatusCodePagesWithReExecute("/Error/{0}");
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapAreaControllerRoute(
    name: "AreaProject",
    areaName: "Project",
    pattern: "Project/{projectId}/{controller}/{action}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
