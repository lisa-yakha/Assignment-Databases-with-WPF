using System.Data.SqlClient;
using NeigbourhoodManagementAPI;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddSingleton(new SqlConnection(connectionString));

builder.Services.AddScoped<DataServices>();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

