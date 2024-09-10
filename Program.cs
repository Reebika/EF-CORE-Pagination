using Microsoft.EntityFrameworkCore;
using System;
using WebApplication1;
using WebApplication1.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



builder.Services.AddDbContext<ApiContext>
    (opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));

builder.Services.AddScoped<ApiContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

LoadSeedData(app);

app.MapControllers();


static void LoadSeedData(WebApplication app)
{
    var newTodos = new List<Todo>()
    {
        new() { Name = "Todo 1",Status = 1 },
        new() { Name = "Todo 2",Status = 1 },
        new() { Name = "Todo 3",Status = 1 },
        new() { Name = "Todo 4",Status = 1 },
        new() { Name = "Todo 5",Status = 1 },
        new() { Name = "Todo 6",Status = 1 },
        new() { Name = "Todo 7",Status = 1 },
        new() { Name = "Todo 8",Status = 1 },
        new() { Name = "Todo 9",Status = 1 },
        new() { Name = "Todo 10",Status = 1 },
        new() { Name = "Todo 11",Status = 1 },
        new() { Name = "Todo 12",Status = 1 },
        new() { Name = "Todo 13",Status = 1 },
        new() { Name = "Todo 14",Status = 1 },
        new() { Name = "Todo 15",Status = 1 }
    };

    using var scope = app.Services.CreateScope();
    ApiContext context = scope.ServiceProvider.GetRequiredService<ApiContext>();

    context.AddRange(newTodos);

    if (context is not null)
    {
        context.SaveChanges();
    }

}
    app.Run();