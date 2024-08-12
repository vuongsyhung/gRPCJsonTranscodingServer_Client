using GrpcServiceOnlineBanking.Models;
using GrpcServiceOnlineBanking.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddGrpc();
builder.Services.AddDbContext<HungDbContext>(db => db.UseSqlServer(builder.Configuration.GetConnectionString("HungConnectionString")));
builder.Services.AddGrpc().AddJsonTranscoding();


var app = builder.Build();

// Configure the HTTP request pipeline.

app.MapGrpcService<OnlineBankingService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client");

app.Run();
