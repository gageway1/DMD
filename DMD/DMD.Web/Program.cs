using DMD.Domain;
using DMD.Domain.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add mediatr
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(DomainMarker).Assembly));

// services

// TODO: remember how to automate this. there's a way to do this quick with mediatr using reflection or something, 
// i just don't remember how to do it right now
builder.Services.AddSingleton<IBandService, BandService>();

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
