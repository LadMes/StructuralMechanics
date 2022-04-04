using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StructuralMechanics.Models;

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
//builder.Services.AddAuthorization();
builder.Services.AddScoped<IProjectService, SQLServerProjectService>();
builder.Services.AddScoped<IStructureService, SQLServerStructureService>();



var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    //Do not use status code pages for development
    app.UseStatusCodePagesWithReExecute("/Error/{0}");
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

app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllerRoute(
                              name: "structure",
                              pattern: "Structure/{structureId}/{controller=Overview}/{action=Index}/{id?}");
                    endpoints.MapControllerRoute(
                              name: "default",
                              pattern: "{controller=Home}/{action=Index}/{id?}");
                });
                 

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
