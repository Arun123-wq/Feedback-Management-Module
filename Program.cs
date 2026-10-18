using FeedbackManagement.Services;

var builder = WebApplication.CreateBuilder(args);

// MVC (Controllers + Views)
builder.Services.AddControllersWithViews();

// In-memory repository (singleton so data lives while the app runs)
builder.Services.AddSingleton<IFeedbackRepository, InMemoryFeedbackRepository>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
