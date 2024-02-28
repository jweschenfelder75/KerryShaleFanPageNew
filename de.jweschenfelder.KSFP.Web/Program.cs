using BlazorStrap;
using de.jweschenfelder.KSFP.Shared.Configuration;
using de.jweschenfelder.KSFP.Shared.Objects;
using de.jweschenfelder.KSFP.Web.Areas.Identity;
using de.jweschenfelder.KSFP.Web.Data;
using de.jweschenfelder.KSFP.Web.Interfaces.BusinessLogic;
using de.jweschenfelder.KSFP.Web.Interfaces.MailAndSmsServices;
using de.jweschenfelder.KSFP.Web.Interfaces.Security;
using de.jweschenfelder.KSFP.Web.Services.Security;
using KerryShaleFanPage.Server.Services.MailAndSmsServices;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile("newssettings.json", optional: true, reloadOnChange: true);
builder.Configuration.AddJsonFile("gallerysettings.json", optional: true, reloadOnChange: true);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    {
        options.UseSqlServer(connectionString);
    });
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.Configure<NewsSettings>(builder.Configuration.GetSection("NewsSettings"));
builder.Services.Configure<GallerySettings>(builder.Configuration.GetSection("GallerySettings"));
builder.Services.AddDefaultIdentity<IdentityUser>(options =>
    {
        options.SignIn.RequireConfirmedAccount = true;
    })
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddRazorPages();
builder.Services.AddBlazorBootstrap();
builder.Services.AddBlazorStrap();
builder.Services.AddServerSideBlazor().AddCircuitOptions(options => 
{
    options.DetailedErrors = true;
    options.DisconnectedCircuitMaxRetained = 100;
    options.DisconnectedCircuitRetentionPeriod = TimeSpan.FromMinutes(1);
    options.JSInteropDefaultCallTimeout = TimeSpan.FromMinutes(1);
});

builder.Services.AddServerSideBlazor(options =>
{
    options.DetailedErrors = true;
    options.DisconnectedCircuitMaxRetained = 100;
    options.DisconnectedCircuitRetentionPeriod = TimeSpan.FromMinutes(3);
    options.JSInteropDefaultCallTimeout = TimeSpan.FromMinutes(1);
    options.MaxBufferedUnacknowledgedRenderBatches = 10;
}).AddHubOptions(options =>
{
    options.ClientTimeoutInterval = TimeSpan.FromSeconds(30);
    options.EnableDetailedErrors = false;
    options.HandshakeTimeout = TimeSpan.FromSeconds(30);
    options.KeepAliveInterval = TimeSpan.FromSeconds(2);
    options.MaximumParallelInvocationsPerClient = 1;
    options.StreamBufferCapacity = 10;

});

builder.Services.AddSignalR(e =>
{
    e.MaximumReceiveMessageSize = 102400000;
    e.KeepAliveInterval = TimeSpan.FromSeconds(5);
});

builder.Services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>();
builder.Services.AddScoped<WeatherForecastService>();
builder.Services.AddScoped<ISecuredConfigurationService, SecuredConfigurationService>();
builder.Services.AddScoped<IGmailMailAndSmsService, GmailMailAndSmsService>();
builder.Services.AddScoped<IGenericService<NewsItemDto>, NewsService>();
builder.Services.AddScoped<IGenericService<GalleryItemDto>, GalleryService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    //app.UseResponseCompression();  // Throws an error: Unable to resolve service for type 'Microsoft.AspNetCore.ResponseCompression.IResponseCompressionProvider' while attempting to activate 'Microsoft.AspNetCore.ResponseCompression.ResponseCompressionMiddleware'.
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.MapBlazorHub(options =>
{
    options.AllowStatefulReconnects = true;
    options.TransportSendTimeout = TimeSpan.FromSeconds(30);
});

app.MapFallbackToPage("/_Host");

app.Run();
