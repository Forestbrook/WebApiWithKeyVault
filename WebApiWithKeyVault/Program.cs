using Forestbrook.WebApiWithKeyVault;

var builder = WebApplication.CreateBuilder(args);
builder.AddAzureKeyVault();

// Add services to the container:
//builder.AddDbContext<--your-DbContext-->();
builder.Services.AddSingleton<BlobStorageRepository>();
builder.Services.AddScoped<DatabaseRepository>();
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
