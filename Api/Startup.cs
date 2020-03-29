using AutoMapper;
using Domain;
using Domain.Interfaces;
using Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Service;

namespace Api
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
            services.AddAutoMapper(typeof(IDishesService));
            services.AddDbContext<RestaurantContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("RestaurantDatabase")));

            //injectare pentru controllerele care au obiecte de tipul ISomethingService
            services.AddScoped<IDishesService, MenuService>();
            services.AddScoped<IIngredientsService, StockService>();

            // services.AddScoped<IRepository<Dish>,EfCoreDishRepository>();
            services.AddScoped<IIngredientsRepository, EfCoreIngredientsRepository>();
            services.AddScoped<IDishesRepository, EfCoreDishesRepository>();
            services.AddScoped<IDishIngredientsRepository, EfCoreDishIngredientsRepository>();

            services.AddAutoMapper(typeof(IDishesService));

            services.AddMvc(option => option.EnableEndpointRouting = false)
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
                .AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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
