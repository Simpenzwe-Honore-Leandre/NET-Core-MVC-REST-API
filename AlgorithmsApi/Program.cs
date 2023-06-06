using Algorithms.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().AddNewtonsoftJson( s=> {
    s.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();});

//Registering services whose lifetime ends after a request
//Repositoires to decouple implementation from interface, can be swapped out when needed
builder.Services.AddScoped<IAlgorithmRepo, SqlAlgorithmRepo>();

//mock repository with hardcoded values for testing endpoints
// builder.Services.AddScoped<IAlgorithmRepo, MockAlgorithmRepo>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//make mapper available for dependency injection. 
//Imapper resolved while attempting to activate controller 
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//building connection string
var sqlConBuilder = new SqlConnectionStringBuilder();
sqlConBuilder.ConnectionString = builder.Configuration.GetConnectionString("AlgorithmDatabaseConnection");
sqlConBuilder.UserID = builder.Configuration["User ID"];
sqlConBuilder.Password = builder.Configuration["Password"];
sqlConBuilder.InitialCatalog = builder.Configuration["Initial Catalog"];

//adding dbcontext
builder.Services.AddDbContext<AlgorithmsContext>(options =>
{
    options.UseSqlServer(sqlConBuilder.ConnectionString);
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
