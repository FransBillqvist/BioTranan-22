using Infrastructure.Data;
var builder = WebApplication.CreateBuilder(args);

var connectString = builder.Configuration.GetConnectionString("MovieDB") ?? "Data Source=MovieDB.db";
builder.Services.AddSqlite<MovieContext>(connectString);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using(var scope = app.Services.CreateScope())
{
    var scopedProvider = scope.ServiceProvider;
    try
    {
        var MovieContext = scopedProvider.GetRequiredService<MovieContext>();
        await MovieContextSeed.SeedAsync(MovieContext);
    }
    catch(Exception ex)
    {
        Console.WriteLine(ex);
    }

}

app.Run();
