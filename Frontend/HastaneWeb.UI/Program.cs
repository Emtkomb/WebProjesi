using HastaneWeb.BusinessLayer.Abstract;
using HastaneWeb.BusinessLayer.Concrete;
using HastaneWeb.DataAccessLayer.Abstract;
using HastaneWeb.DataAccessLayer.Concrete;
using HastaneWeb.DataAccessLayer.EntityFramework;
using HastaneWeb.EntityLayer.Concrete;

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
builder.Services.AddHttpClient();
builder.Services.AddControllersWithViews();
builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
