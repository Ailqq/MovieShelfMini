using Microsoft.EntityFrameworkCore;
using MovieShelfMini.Services;
using MovieShelfMini.Services.Contracts;
using MovieShelfMini.Data;
using MovieShelfMini.Data.Migrations;



namespace MovieShelfMini.WEB
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<MovieDbContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefaultConnection"),
                    x => x.MigrationsAssembly("MovieShelfMini.Data")));

            builder.Services.AddScoped<IMovieService, MovieService>();

            var app = builder.Build();
            using (var scope = app.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<MovieDbContext>();
                dbContext.Database.Migrate();
                DemoData.Seed(dbContext);
            }

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
