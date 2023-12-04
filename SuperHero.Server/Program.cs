using Microsoft.EntityFrameworkCore;
using SuperHero.Server.Data;
using SuperHero.Server.EndPoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy=>
        {
            policy
            .AllowAnyOrigin() 
            .AllowAnyMethod()
            .AllowAnyHeader();
        });
});

var  ConnectionString= builder.Configuration.GetConnectionString("Conn");
builder.Services.AddDbContext<Contexto>(options=>{
    options.UseMySql(ConnectionString, ServerVersion.AutoDetect(ConnectionString));
});

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();
app.ConfigureHeroesEndpoints();

//app.UseHttpsRedirection();

  

app.Run();

 
