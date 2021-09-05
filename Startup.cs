using EnergyConsumption.Context;
using EnergyConsumption.Logic;
using EnergyConsumption.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace EnergyConsumption
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
            services.AddDbContext<MeterReadingDbContext>
                (options => options.UseSqlServer(Configuration.GetConnectionString("MeterReadingConn")));

            services.AddScoped<IProcessRequest, RequestProcessor>();
            services.AddScoped<IDataExtractor, FileDataReader>();
            services.AddScoped<IProcessData, ProcessData>();
            services.AddScoped<IDataContext, DataLayer>();
            services.AddScoped<IValidation, Validation>();

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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
