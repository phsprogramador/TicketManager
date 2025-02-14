using Autofac;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using TicketManager.Infrastructure.Data;
using Autofac.Extensions.DependencyInjection;
using TicketManager.CrossCutting.IoC;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(b => b.RegisterModule(new ModuleIoC()));


builder.Services.AddHttpContextAccessor();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Ticket Manager API", Version = "v1" });
});

builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();    
    app.UseSwagger();    
    app.UseSwaggerUI(c =>
    {   
        c.SwaggerEndpoint("v1/swagger.json", "Ticket Manager API");
        c.DefaultModelsExpandDepth(-1);
    });    
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

app.MapControllers();

app.Run();