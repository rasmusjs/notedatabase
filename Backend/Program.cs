using lars_notedatabase.DAL;
using lars_notedatabase.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;


WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<NoteDbContext>(options => options.UseSqlite("Data Source=NoteDatabase.db"));
builder.Services.AddControllersWithViews();


builder.Services.AddSession();
// Source https://stackoverflow.com/questions/59199593/net-core-3-0-possible-object-cycle-was-detected-which-is-not-supported
builder.Services.AddControllersWithViews()
    .AddNewtonsoftJson(options =>
        options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore
    );

builder.Services.AddScoped<INoteRepository<OrchestralSet>, NoteRepository<OrchestralSet>>();
builder.Services.AddScoped<INoteRepository<Country>, NoteRepository<Country>>();
builder.Services.AddScoped<INoteRepository<Instrument>, NoteRepository<Instrument>>();
builder.Services.AddScoped<INoteRepository<Contributor>, NoteRepository<Contributor>>();
builder.Services.AddScoped<INoteRepository<FileAttachment>, NoteRepository<FileAttachment>>();


// Needed to fix fail: Microsoft.AspNetCore.Diagnostics.DeveloperExceptionPageMiddleware[1]
// Source https://stackoverflow.com/questions/59199593/net-core-3-0-possible-object-cycle-was-detected-which-is-not-supported
builder.Services.AddControllersWithViews()
    .AddNewtonsoftJson(options =>
        options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore
    );

WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    DbInit.Seed(app); // for adding seed data
}
else
{
    app.UseExceptionHandler("/Home/Error");
}


app.MapGet("/", () => "Hello World!");
app.UseSession();
app.UseStaticFiles();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.Run();