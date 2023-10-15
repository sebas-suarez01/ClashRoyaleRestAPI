using ClashRoyaleRestAPI.Infrastructure;
using ClashRoyaleRestAPI.Infrastructure.Persistance;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers();
    builder.Services.AddInfrastructure();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

}

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle



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
