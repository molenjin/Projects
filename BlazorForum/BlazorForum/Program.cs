using BlazorForum.Database;
using BlazorForum.Libraries;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.  
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

// Add the database call object  
builder.Services.AddSingleton<IDatabaseCalls, DatabaseCallsMySQL>();
// Add the data library
builder.Services.AddSingleton<LibData>();
// Add the formatting library
builder.Services.AddSingleton<LibFormat>();
// Add the validation library
builder.Services.AddSingleton<LibValidate>();
// Add the external IO library
builder.Services.AddHttpContextAccessor();
builder.Services.AddSingleton<LibExternal>();

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

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
