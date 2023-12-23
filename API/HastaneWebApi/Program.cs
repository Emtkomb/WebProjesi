using HastaneWeb.BusinessLayer.Abstract;
using HastaneWeb.BusinessLayer.Concrete;
using HastaneWeb.DataAccessLayer.Abstract;
using HastaneWeb.DataAccessLayer.Concrete;
using HastaneWeb.DataAccessLayer.EntityFramework;
using HastaneWeb.EntityLayer.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<Context>();

builder.Services.AddScoped<IDoktorDal,EfDoktorDal>();
builder.Services.AddScoped<IDoktorService,DoktorManager>();

builder.Services.AddScoped<IHastaneDal, EfHastaneDal>();
builder.Services.AddScoped<IHastaneService, HastaneManager>();

builder.Services.AddScoped<IHizmetDal, EfHizmetDal>();
builder.Services.AddScoped<IHizmetService, HizmetManager>();

builder.Services.AddScoped<IRandevuDal, EfRandevuDal>();
builder.Services.AddScoped<IRandevuService, RandevuManager>();

builder.Services.AddScoped<IBirimDal, EfBirimDal>();
builder.Services.AddScoped<IBirimService, BirimManager>();


builder.Services.AddAutoMapper(typeof(Program));


builder.Services.AddCors(opt =>
{
    opt.AddPolicy("HastaneApiCors", opts =>
    {
        opts.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("HastaneApiCors");

app.UseAuthorization();

app.MapControllers();

app.Run();
