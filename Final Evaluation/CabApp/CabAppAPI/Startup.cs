using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.ServiceInterfaces;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yifan_Wu.CabApp.Infrastructure.Services;

namespace CabAppAPI
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
            services.AddDbContext<CabAppDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("CabAppDbConnection"));
            });
            services.AddScoped<ICabTypeRepository, CabTypeRepository>();
            services.AddScoped<IPlaceRepository, PlaceRepository>();
            services.AddScoped<IBookingsRepository, BookingsRepository>();
            services.AddScoped<IBookingsHistoryRepository, BookingsHistoryRepository>();
            services.AddScoped<IBookingsService, BookingsService>();
            services.AddScoped<IBookingsHistoryService, BookingsHistoryService>();
            services.AddScoped<ICabTypeService, CabTypeService>();
            services.AddScoped<IPlaceService, PlaceService>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CabAppAPI", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CabAppAPI v1"));
            }
            app.UseCors(builder => {
                builder.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowCredentials().AllowAnyMethod();
            });
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
