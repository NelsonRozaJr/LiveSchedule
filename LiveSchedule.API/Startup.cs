using AutoMapper;
using LiveSchedule.API.Domains.Interfaces;
using LiveSchedule.API.Repositories;
using LiveSchedule.API.Repositories.Context;
using LiveSchedule.API.Services;
using LiveSchedule.API.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace LiveSchedule.API
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
            services.AddDbContext<LiveScheduleContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddTransient<ILiveSchedule, LiveScheduleRepository>();
            services.AddTransient<ILiveScheduleService, LiveScheduleService>();

            services.AddSwaggerGen(s => s.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Live Schedule API"
            }));

            services.AddAutoMapper(typeof(Startup));

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder => builder
                    .SetIsOriginAllowed(_ => true)
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwagger()
                .UseSwaggerUI(options => options.SwaggerEndpoint("/swagger/v1/swagger.json", "Version 1"));

            app.UseCors();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
