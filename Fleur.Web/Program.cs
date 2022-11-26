using Fleur.Web;
using Fleur.Web.Services;
using Fleur.Web.Services.IServices;
using Microsoft.AspNetCore.Authentication;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(options => {
    options.DefaultScheme = "Cookies";
    options.DefaultChallengeScheme = "oidc";
}).AddCookie("Cookies", c=>c.ExpireTimeSpan = TimeSpan.FromMinutes(10))
.AddOpenIdConnect("oidc", options => { 
    options.Authority = builder.Configuration["ServiceUrls:IdentityAPI"];
    options.GetClaimsFromUserInfoEndpoint = true;
    options.ClientId = "fleur";
    options.ClientSecret = "secret";
    options.ResponseType = "code";
    options.ClaimActions.MapJsonKey("role", "role", "role");
    options.ClaimActions.MapJsonKey("sub", "sub", "sub");
    options.TokenValidationParameters.NameClaimType = "name";
    options.TokenValidationParameters.RoleClaimType = "role";
    options.Scope.Add("fleur");
    options.SaveTokens = true;
    options.RequireHttpsMetadata = false;
});

//Adding My Service
builder.Services.AddHttpClient<IProductService, ProductService>();
builder.Services.AddHttpClient<ICartService, CartService>();
builder.Services.AddHttpClient<ICouponService, CouponService>();

SD.ProductAPIBase = builder.Configuration["ServiceUrls:ProductAPI"];
SD.ShoppingCartAPIBase = builder.Configuration["ServiceUrls:ShoppingCartAPI"];
SD.CouponAPIBase = builder.Configuration["ServiceUrls:CouponAPI"];
SD.OrderAPIBase = builder.Configuration["ServiceUrls:OrderAPI"];

builder.Services.AddScoped<IProductService,ProductService>();
builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddScoped<ICouponService, CouponService>();


// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
