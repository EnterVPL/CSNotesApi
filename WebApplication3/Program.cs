using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Add NSwag services
builder.Services.AddOpenApiDocument(config =>
{
    config.Title = "Notes API";
    config.Version = "v1";
    
    // Add example for ID and indicate it's a UUID
    config.SchemaSettings.GenerateExamples = true;
    config.SchemaSettings.SchemaProcessors.Add(new CustomSchemaProcessor());
});

// Configure SQLite database
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite("Data Source=notes.db"));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();

    // Enable NSwag in development
    app.UseOpenApi();
    app.UseSwaggerUi();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

// Ensure database is created
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    dbContext.Database.EnsureCreated();
}

app.Run();