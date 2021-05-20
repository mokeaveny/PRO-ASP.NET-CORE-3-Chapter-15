using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using ASP.NET_CORE_3_Chapter_15.Services;

namespace ASP.NET_CORE_3_Chapter_15
{
    public class Startup
    {
        public Startup(IConfiguration config)
        {
            Configuration = config;
        }

        private IConfiguration Configuration { get; set; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDistributedSqlServerCache(opts =>
            {
                opts.ConnectionString
                    = Configuration["ConnectionStrings:CacheConnection"];
                opts.SchemaName = "dbo";
                opts.TableName = "DataCache";
            });
            services.AddResponseCaching();
            services.AddSingleton<IResponseFormatter, HtmlResponseFormatter>();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseDeveloperExceptionPage();
            app.UseResponseCaching();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapEndpoint<SumEndpoint>("/sum/{count:int=1000000000}");

                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }
    }
}