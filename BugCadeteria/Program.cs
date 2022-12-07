using AutoMapper;
using Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//Inyección de repositorios
builder.Services.AddSingleton<IConnectionString,ConnectionString>();
builder.Services.AddSingleton<ICadeteRepository,CadeteRepository>();
builder.Services.AddSingleton<IClienteRepository,ClienteRepository>();
builder.Services.AddSingleton<IPedidoRepository,PedidoRepository>();

var mapperConfig = new MapperConfiguration (mp => {
    mp.AddProfile(new MappingProfile());
});

/* var mapperConfig = new MapperConfiguration (mp => {
    mp.AddProfile(new MappingProfile());
}); */
IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Cadetes}/{action=Index}/{id?}");

app.Run();
