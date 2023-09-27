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
// TODO: logger isnt working. wtf msft
LoggerFactory loggerFactory = new();
ILogger _domainLogger = loggerFactory.CreateLogger<Program>();
builder.Services.AddSingleton(typeof(ILogger), _domainLogger);

builder.Services.AddBandService(builder.Configuration);

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
