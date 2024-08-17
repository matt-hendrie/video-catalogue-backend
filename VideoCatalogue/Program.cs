using Asp.Versioning;
using Microsoft.EntityFrameworkCore;
using VideoCatalogue.EfCore;
using VideoCatalogue.Interfaces;
using VideoCatalogue.Repositories;
using VideoCatalogue.Services;
using VideoCatalogue.Utils;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddDbContext<VideoDbContext>(options =>
{
    options.UseSqlite("Data Source=VideoCatalogue.db");
});

builder.Services.AddScoped<ChannelRepository>();
builder.Services.AddScoped<VideoDataRepository>();
builder.Services.AddScoped<IVideoDataService, VideoDataService>();
builder.Services.AddScoped<IChannelDataService, ChannelDataService>();
builder.Services.AddScoped<ModelConverter>();
builder.Services.AddScoped<IYtdlService, YtdlService>();

builder.Services.AddControllers();

//Configure Versioning
builder.Services.AddApiVersioning(option =>
{
    option.AssumeDefaultVersionWhenUnspecified = true;
    option.DefaultApiVersion = new ApiVersion(1, 0);
    option.ReportApiVersions = true;
    
    //------------------------------------------------//
    option.ApiVersionReader = ApiVersionReader.Combine(
        new QueryStringApiVersionReader("api-version"),
        new HeaderApiVersionReader("X-Version"),
        new MediaTypeApiVersionReader("ver"));
}).AddApiExplorer(options => {
    options.GroupNameFormat = "'v'VVV";
    options.SubstituteApiVersionInUrl = true;
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


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

//Run Migrations
using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
var context = services.GetRequiredService<VideoDbContext>();
context.Database.Migrate();

app.Run();
