using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


// 

builder.Services.AddAuthorization();
builder.Services.AddAuthentication()
    .AddCookie();
// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddEntityFrameworkNpgsql()
    .AddDbContext<pim8.Data.Context>(options => 
    options.UseNpgsql("Host=localhost;Port=3333;Database=pim8;Username=postgres;Password=unip"));
builder.Services.AddScoped<pim8.Data.iUserRepository, pim8.Data.MockRepository>();


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
app.UseAuthentication();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Auth}/{action=SignIn}/{id?}");

app.Run();
