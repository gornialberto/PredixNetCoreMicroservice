using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using netCoreWebApi.DataLayer;
using netCoreWebApi.DataServices;
using Microsoft.EntityFrameworkCore;

namespace netCoreWebApi
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
            var connectionString = Configuration.GetConnectionString("ECSQLServer");
            
            services.AddDbContext<EFDataContext>(options =>
                options.UseSqlServer(connectionString));

            //services.AddDbContext<EFDataContext>(options =>
            //   options.UseInMemoryDatabase("InMemoryDB"));

            //services.AddDbContext<EFDataContext>(options =>
            // options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));

            services.AddMvc();

            services.AddSingleton<IKeyValueService, KeyValueService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory,
            EFDataContext dataContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.UseStatusCodePages();
            }

            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseMvc();

            //inizialize the DB
            dataContext.Database.EnsureCreated();
        }
    }
}
