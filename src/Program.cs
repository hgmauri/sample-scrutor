using Sample.Scrutor.Extensions;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
builder.AddSerilog(builder.Configuration, "Sample Scrutor");
Log.Information("Starting API");

builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddClassesMatchingInterfaces(nameof(Sample));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();