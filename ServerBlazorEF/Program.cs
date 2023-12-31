using Microsoft.AspNetCore.Identity;
using ServerBlazorEF;
using Microsoft.AspNetCore.Components.Authorization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddScoped<DonationService>();
builder.Services.AddScoped<AccountService>();
builder.Services.AddScoped<PaymentService>();
builder.Services.AddScoped<TransTypeService>();


builder.Services.AddScoped<AuthenticationStateProvider, AuthService>();
builder.Services.AddScoped<AuthService>();

// builder.Services.AddCascadingAuthenticationState();

// Former and working connection string stuff
// var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
// builder.Services.AddDbContext<DonationDbContext>(
//     options => options.UseSqlite(connectionString)
// );

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<DonationDbContext>(
    options => options.UseSqlite(connectionString, b => b.MigrationsAssembly("ServerBlazorEF"))
);

builder.Services.AddIdentity<IdentityUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<DonationDbContext>();

    


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

using (var scope = app.Services.CreateScope()) {
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<DonationDbContext>();    
    context.Database.Migrate();
}

app.Run();
