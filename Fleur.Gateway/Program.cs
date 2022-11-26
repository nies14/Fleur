using Microsoft.IdentityModel.Tokens;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

//Add Authentication
builder.Services.AddAuthentication("Bearer").AddJwtBearer("Bearer", options => {
    options.Authority = builder.Configuration["IdentityAPI"]; //"https://acmeidentity.com";//"https://localhost:7054/";
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateAudience = false
    };
});
builder.Services.AddOcelot(builder.Configuration);


var app = builder.Build();

//app.MapGet("/", () => "Hello World!");
if (app.Environment.IsProduction())
{
    await app.UseOcelot();
}

app.Run();
