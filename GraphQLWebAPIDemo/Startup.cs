using GraphiQl;
using GraphQL;
using GraphQL.Types;
using GraphQLWebAPIDemo.Queries;
using GraphQLWebAPIDemo.Schema;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RealEstateManager.DataAccess.Repositories;
using RealEstateManager.DataAccess.Repositories.Contracts;
using RealEstateManager.Database;
using RealEstateManager.Types;

namespace GraphQLWebAPIDemo
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
            services.AddControllers()
                .AddNewtonsoftJson(options =>
                {
                    // Use the default property (Pascal) casing
                    //options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                });

            services.AddScoped<IPaymentRepository, PaymentRepository>();
            services.AddScoped<IPropertyRepository, PropertyRepository>();

            services.AddDbContext<RealEstateContext>(options =>
                options.UseSqlServer(Configuration["ConnectionStrings:RealEstateDb"]));
            services.AddSingleton<IDocumentExecuter, DocumentExecuter>();
            services.AddScoped<PropertyQuery>();
            services.AddScoped<PropertyMutation>();
            services.AddScoped<PropertyType>();
            services.AddScoped<PaymentType>();
            services.AddScoped<PropertyInputType>();
            services.AddScoped<ISchema, RealEstateSchema>();
            //var sp = services.BuildServiceProvider();
            //services.AddSingleton<ISchema>(new RealEstateSchema(new FuncDependencyResolver(type => sp.GetService(type))));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, RealEstateContext db)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseGraphiQl();
            //app.UseMvc();
            db.EnsureSeedData();
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
