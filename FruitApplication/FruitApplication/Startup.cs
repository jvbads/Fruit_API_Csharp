using FruitApplication.BussinessLogic;
using FruitApplication.DataAccess.Repository;
using FruitApplication.DataAccess.Utils;
using FruitApplication.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FruitApplication
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddScoped<IFruitRepository, FruitRepository>();
            services.AddScoped<IBLFruit, BLFruit>();

            // SQL Server 
            services.AddDbContext<FruitContext>(options => options.UseSqlServer(Configuration.GetConnectionString("FruitContext"),
                                                builder => builder.MigrationsAssembly("FruitApplication")));

            //services.AddScoped<SeedingService>();

            //string DBUUID = Guid.NewGuid().ToString();

            //services.AddDbContext<FruitContext>(options => options.UseInMemoryDatabase("FruitList" + DBUUID));

            //services.AddScoped<IFruitRepository, FruitRepository>();

            //services.AddScoped<IBLFruit, BLFruit>();


            services.AddSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(x => { x.SwaggerEndpoint("/swagger/v1/swagger.json", "Fruit API"); });
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
