
using Microsoft.EntityFrameworkCore;
using WebApi_emprepositorycrud.Repository;
using WebApi_emprepositorycrud.Service;

namespace WebApi_emprepositorycrud
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddTransient<IEmployeeservice, SqlEmployeeservice>();
            builder.Services.AddDbContext<Appdbcontext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("EmployeeDBConnection")), ServiceLifetime.Transient);
            builder.Services.AddCors((p) => p.AddDefaultPolicy(policy => policy.WithOrigins("*").AllowAnyHeader().AllowAnyMethod()));
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
            app.UseCors();
            app.UseAuthorization();


            app.MapControllers();
           /* app.MapControllerRoute(
                name: "default",
                pattern );*/

            app.Run();
        }
    }
}
