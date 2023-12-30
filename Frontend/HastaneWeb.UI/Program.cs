using HastaneWeb.BusinessLayer.Abstract;
using HastaneWeb.BusinessLayer.Concrete;
using HastaneWeb.DataAccessLayer.Abstract;
using HastaneWeb.DataAccessLayer.Concrete;
using HastaneWeb.DataAccessLayer.EntityFramework;
using HastaneWeb.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<Context>();

builder.Services.AddScoped<IDoktorDal, EfDoktorDal>();
builder.Services.AddScoped<IDoktorService, DoktorManager>();

builder.Services.AddScoped<IHastaneDal, EfHastaneDal>();
builder.Services.AddScoped<IHastaneService, HastaneManager>();

builder.Services.AddScoped<IHizmetDal, EfHizmetDal>();
builder.Services.AddScoped<IHizmetService, HizmetManager>();

builder.Services.AddScoped<IRandevuDal, EfRandevuDal>();
builder.Services.AddScoped<IRandevuService, RandevuManager>();

builder.Services.AddScoped<IBirimDal, EfBirimDal>();
builder.Services.AddScoped<IBirimService, BirimManager>();

builder.Services.AddIdentity<AppUser,AppRole>().AddEntityFrameworkStores<Context>();

builder.Services.AddMvc(config =>
{
    var policy=new AuthorizationPolicyBuilder()
    .RequireAuthenticatedUser()
    .Build();
    config.Filters.Add(new AuthorizeFilter(policy));
});

builder.Services.Configure<IdentityOptions>(options =>
{
    // Þifre karmaþýklýðý ayarý
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredLength = 2;

    // Diðer ayarlar
   
    
    options.Lockout.AllowedForNewUsers = false;

    // Diðer özelleþtirmeler
    // ...
});
builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan= TimeSpan.FromMinutes(10);
    options.LoginPath = "/Login/Index/";
}
);
builder.Services.AddHttpClient();
builder.Services.AddControllersWithViews();
//builder.Services.AddMvc(config=>
//{
//    var policy = new AuthorizationPolicyBuilder()
//    .RequireAuthenticatedUser()
//    .Build();
//    config.Filters.Add(new AuthorizeFilter(policy));

//});
builder.Services.AddMvc();
//builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(x =>
//{
//    x.LoginPath = "/Login/Index/";
//}
//);
builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseAuthentication();



app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
//using (var scope=app.Services.CreateScope())
//{
//    var roleManager = scope.ServiceProvider.GetRequiredService<AppRole<IdentityRole>>();
//}

app.Run();
