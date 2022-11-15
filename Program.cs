using Microsoft.EntityFrameworkCore;
using pim8.Services;

var builder = WebApplication.CreateBuilder(args);


// 

builder.Services.AddAuthorization();
builder.Services.AddAuthentication()
    .AddCookie();
// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddEntityFrameworkNpgsql()
    .AddDbContext<pim8.Models.Database.Context>(options => 
    options.UseNpgsql(builder.Configuration.GetConnectionString("Database")));
builder.Services.AddScoped<pim8.Models.Database.iUserRepository, pim8.Models.Database.MockRepository>();
builder.Services.AddScoped<pim8.Models.Database.iAddressRepository, pim8.Models.Database.AddressRepository>();
builder.Services.AddScoped<pim8.Controllers.iHelpers.iEncryptPassword, pim8.Helpers.Encrypter>();
builder.Services.AddScoped<pim8.Controllers.iHelpers.iComparePassword, pim8.Helpers.Encrypter>();
builder.Services.AddScoped<pim8.Controllers.iHelpers.iSendMail, pim8.Services.MailService>();
builder.Services.AddScoped<pim8.Controllers.iHelpers.iGenerateEmailToken, pim8.Helpers.GenerateToken>();
builder.Services.AddScoped<pim8.Controllers.iHelpers.iValidatorEmail, pim8.Helpers.Validator>();
builder.Services.AddScoped<pim8.Controllers.iHelpers.iValidatorCPF, pim8.Helpers.Validator>();


var app = builder.Build();
app.UseAuth(); // My middleware; =D

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
    pattern: "{id}",
    new { controller = "Home", action = "Default" });
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Auth}/{action=SignIn}/{id?}");

app.Run();
