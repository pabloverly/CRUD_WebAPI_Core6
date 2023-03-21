using Microsoft.EntityFrameworkCore;
using webapi.Data;
using webapi.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// configuração para apontar o appsettings.development.json onde esta a string de conexão com o banco de dados
builder.Services.AddDbContext<UserContext>(options => {
    options.UseNpgsql(builder.Configuration.GetConnectionString("Default"));
});
//adicionando injeção de dependencia
builder.Services.AddScoped<IUserRepository, UserRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
