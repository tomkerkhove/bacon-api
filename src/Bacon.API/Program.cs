using Bacon.Factory;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IBaconRepository, BaconRepository>();
builder.Services.AddControllers();
builder.Services.AddProblemDetails();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Bacon API",
        Description = "An API to use in demos to get various flavors of bacon.",
        TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "GitHub",
            Url = new Uri("https://github.com/tomkerkhove/bacon-api")
        },
        License = new OpenApiLicense
        {
            Name = "MIT",
            Url = new Uri("https://github.com/tomkerkhove/bacon-api/blob/main/LICENSE")
        }
    });
});

var app = builder.Build();

// Configure Swagger
app.UseSwagger(o => o.RouteTemplate = "api/docs/{documentName}/swagger.json");
app.UseSwaggerUI(o =>
{
    o.ConfigObject.DocExpansion = DocExpansion.Full;
    o.DocumentTitle = "Bacon API";
    o.RoutePrefix = "api/docs";
});

// Configure the HTTP request pipeline.
app.UseExceptionHandler();
app.UseAuthorization();
app.MapControllers();

app.Run();
