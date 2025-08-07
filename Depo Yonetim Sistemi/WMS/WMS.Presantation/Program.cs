var builder = WebApplication.CreateBuilder(args);

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "admin",
    pattern: "{area}/{controller=AdminLogin}/{action=AdminLogin}/{id?}");

app.MapControllerRoute(
    name: "calisan",
    pattern: "{area}/{controller=CalisanLogin}/{action=CalisanLogin}/{id?}");

app.MapControllerRoute(
    name: "magaza",
    pattern: "{area}/{controller=MagazaLogin}/{action=MagazaLogin}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Login}/{id?}");

app.Run();
