using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Ok.Tech.App;
using Ok.Tech.Domain.Apps;
using Ok.Tech.Domain.Repositories;
using OK.Tech.Infra.Data.Contexts;
using OK.Tech.Infra.Data.Repositories;

namespace Ok.Tech.Api
{
    public class Startup
    {
      
        public IConfiguration Configuration  { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

        }          


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApiDbContext>(options => 
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));            
            });

            services.AddAutoMapper(typeof(Startup));

            services.AddScoped<IProductApp, ProductApp>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddControllers();

            //configura��o pra desligar comportamento padrao do Asp.net Core
            services.Configure<ApiBehaviorOptions>(options => { options.SuppressModelStateInvalidFilter = true; });
        }

       
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
