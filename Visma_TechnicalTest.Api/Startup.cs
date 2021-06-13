using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Visma_TechnicalTest.Core;
using Visma_TechnicalTest.Core.Services;
using Visma_TechnicalTest.Data;
using Visma_TechnicalTest.Services;

namespace Visma_TechnicalTest.Api
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

            services.AddDbContext<TechnicalTestDbContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("Default"),
                x => x.MigrationsAssembly("Visma_TechnicalTest.Data")));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IEmployeeService, EmployeeService>();

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "Visma TechnicalTest", Version = "v1" });
            });

            services.AddAutoMapper(typeof(Startup));

            services.AddCors(x =>
            {
                x.AddPolicy("AllowOrigin", options => options.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod());
            });

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

            app.UseCors(options => options.WithOrigins("http://localhost:4200"));

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = "";
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Visma TechnicalTest V1");
            });
        }
    }
}
