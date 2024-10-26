using Microsoft.EntityFrameworkCore;
using TodoAppApi.Data;
using TodoAppApi.Repositories;

namespace TodoAppApi;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddAuthorization();

        builder.Services.AddDbContext<ToDoAppDbContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("ConnectionString")));

        builder.Services.AddScoped<IItemRepository, ItemRepository>();
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
        app.MapControllers(); 
        app.UseAuthorization();
        
        app.Run();
    }
}