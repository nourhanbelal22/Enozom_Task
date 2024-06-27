
using LibraryBL.IServices;
using LibraryBL.Services;
using LibraryDAL.Data;
using LibraryDAL.Interfaces;
using LibraryDAL.Reposatiories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace Library
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Library API",
                    Version = "v1",
                    Description = "API documentation for the Library system."
                });
            });

            var connectionString = builder.Configuration.GetConnectionString("DevConnection");
            builder.Services.AddDbContext<LibraryDbContext>(options =>
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
            builder.Services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            builder.Services.AddScoped<IBookReository, BookCopyRepository>();
            builder.Services.AddScoped<IBookService,BookServices>();    

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

            app.Run();
        }
    }
}
