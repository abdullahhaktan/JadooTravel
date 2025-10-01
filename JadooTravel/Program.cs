using JadooTravel.Models;
using JadooTravel.Services;
using JadooTravel.Services.CategoryServices;
using JadooTravel.Services.DestinationServices;
using JadooTravel.Services.FeatureServices;
using JadooTravel.Services.LanguageServices;
using JadooTravel.Services.ReservationService;
using JadooTravel.Services.ReservationServices;
using JadooTravel.Services.Services;
using JadooTravel.Services.TestimonialServices;
using JadooTravel.Services.TripPlanServices;
using JadooTravel.Settings;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Options;
using System.Globalization;
using System.Reflection;
using SharedResource = JadooTravel.Services.LanguageServices.SharedResource;

var builder = WebApplication.CreateBuilder(args);


#region Localizer
builder.Services.AddSingleton<LanguageService>();
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");
builder.Services.AddMvc().AddViewLocalization().AddDataAnnotationsLocalization(options =>
            options.DataAnnotationLocalizerProvider = (type, factory) =>
            {
                var assemblyName = new AssemblyName(typeof(SharedResource).GetTypeInfo().Assembly.FullName);
                return factory.Create(nameof(SharedResource), assemblyName.Name);
            });
builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var supportCultures = new List<CultureInfo>
    {
        new CultureInfo("en-US"),
        new CultureInfo("fr-FR"),
        new CultureInfo("es-ES"),
        new CultureInfo("tr-TR"),
    };
    options.DefaultRequestCulture = new RequestCulture(culture: "tr-TR", uiCulture: "tr-TR");
    options.SupportedCultures = supportCultures;
    options.SupportedUICultures = supportCultures;
    options.RequestCultureProviders.Insert(0, new QueryStringRequestCultureProvider());
});
#endregion



// Diðer servisler...
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IDestinationService, DestinationService>();
builder.Services.AddScoped<ITestimonialService, TestimonialService>();
builder.Services.AddScoped<IFeatureService, FeatureService>();
builder.Services.AddScoped<ITripPlanService, TripPlanService>();
builder.Services.AddScoped<IReservationService, ReservationService>();

builder.Services.AddHttpClient();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

// Database settings
builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("DatabaseSettings"));
builder.Services.AddSingleton<IDatabaseSettings>(sp =>
    sp.GetRequiredService<IOptions<DatabaseSettings>>().Value);


builder.Services.AddControllersWithViews().AddViewLocalization();
var app = builder.Build();

// --- MIDDLEWARE ---
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseRequestLocalization(
    app.Services.GetRequiredService<IOptions<RequestLocalizationOptions>>().Value
);

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Default}/{action=Index}/{id?}");

app.Run();