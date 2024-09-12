var builder = WebApplication.CreateBuilder(args);
//Mvc Projesi Olduðunu Tanýttýk
builder.Services.AddControllersWithViews();


var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();

//Link Yönergemizi Oluþturduk
app.MapControllerRoute(
    name :"Default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
    );

app.Run();
