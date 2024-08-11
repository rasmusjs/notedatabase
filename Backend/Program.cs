using lars_notedatabase.DAL;
using lars_notedatabase.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Microsoft.OpenApi.Models;


WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer(); // Swagger
builder.Services.AddSwaggerGen(); // Source: https://learn.microsoft.com/en-us/aspnet/core/tutorials/getting-started-with-swashbuckle?view=aspnetcore-8.0&tabs=net-cli

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


builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Orchestral API",
        Description = "An ASP.NET Core Web API for managing orchestral items",
        TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "Example Contact",
            Url = new Uri("https://example.com/contact")
        },
        License = new OpenApiLicense
        {
            Name = "Example License",
            Url = new Uri("https://example.com/license")
        }
    });
});


WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
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