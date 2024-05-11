using AVBooksStore.Extension;
using AVBooksStore.Models.ServiceModel;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.AddDomainServices().Build();

// Configure the HTTP request pipeline.
app.WebApplicationPipeline();

app.Run();
