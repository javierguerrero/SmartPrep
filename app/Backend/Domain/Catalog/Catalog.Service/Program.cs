using Catalog.Service.Infrastructure.Persistence.Extensions;
using Library.Service.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

string connectionString = builder.Configuration.GetConnectionString("CatalogConnectionString");

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddInfrastructure(opt => opt.ConnectionString = connectionString);

/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
var app = builder.Build();
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSeedData();
app.Run();