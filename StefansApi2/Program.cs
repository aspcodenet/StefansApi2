
using Microsoft.EntityFrameworkCore;
using StefansApi2.Data;

namespace StefansApi2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            builder.Services.AddTransient<DataInitializer>();
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });


            var app = builder.Build();
            using (var scope = app.Services.CreateScope())
            {
                scope.ServiceProvider.GetRequiredService<DataInitializer>().MigrateData();
            }

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.UseSwaggerUI(appAction =>
                {
                    appAction.SwaggerEndpoint("/openapi/v1.json", "StefansApi api");
                    appAction.RoutePrefix = string.Empty;
                });
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
