using Algorithms.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//Registering services which end after a transaction?
builder.Services.AddScoped<IAlgorithmRepo, MockAlgorithmRepo>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var sqlConBuilder = new SqlConnectionStringBuilder();
sqlConBuilder.ConnectionString = builder.Configuration.GetConnectionString("AlgorithmDatabaseConnection");
sqlConBuilder.UserID = builder.Configuration["User ID"];
sqlConBuilder.Password = builder.Configuration["Password"];
sqlConBuilder.InitialCatalog = builder.Configuration["Initial Catalog"];

builder.Services.AddDbContext<AlgorithmsContext>(opt =>
{
    opt.UseSqlServer(sqlConBuilder.ConnectionString);
});

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
