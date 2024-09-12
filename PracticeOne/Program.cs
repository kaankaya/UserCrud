var builder = WebApplication.CreateBuilder(args);
//Mvc Projesi Oldu�unu Tan�tt�k
builder.Services.AddControllersWithViews();


var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();

//Link Y�nergemizi Olu�turduk
app.MapControllerRoute(
    name :"Default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
    );

app.Run();
