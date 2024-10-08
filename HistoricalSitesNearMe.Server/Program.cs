using HistoricalSitesNearMe.Server.Facades;
using HistoricalSitesNearMe.Server.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped(s => new PlacesApiFacade(s.GetRequiredService<IHttpClientFactory>(), builder.Configuration["ApiKey"]!));
builder.Services.AddScoped<PlacesApiService>();

builder.Services.AddHttpClient("PlacesApi", configureClient: c =>
{
    c.BaseAddress = new Uri("https://maps.googleapis.com/maps");
});

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

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
