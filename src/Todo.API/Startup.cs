using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Todo.API.EFCore;
using Todo.API.Repository;
using Todo.API.Service;

namespace Todo.API
{
    public static class Startup
    {
        public static IConfiguration Configuration { get; set; }

        public static WebApplication CreateWebApplication(string[] args, string configFileName = "appsettings.json")
        {
            var builder = WebApplication.CreateBuilder(args);

#pragma warning disable ASP0013
            builder.Host.ConfigureAppConfiguration(app =>
            {
                app.AddJsonFile(configFileName);
                if (builder.Environment.IsDevelopment())
                {
                    app.AddEnvironmentVariables();
                }
            });
#pragma warning restore ASP0013 

            Configuration = builder.Configuration;

            builder.Host.ConfigureServices(ConfigureServices);

            var app = builder.Build();

            Configure(app, builder.Environment);

            return app;
        }
        // This method is called by the runtime. Use this method to add services to the container.
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            var connString = Configuration.GetValue<string>("SqlConnection:ConnectionString");

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(connString);
            });


            services.AddDbContext<AppDbContext>();


            services.AddFluentValidation();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddTransient<ITaskService, TaskService>();
            services.AddTransient<ITaskRepository, TaskRepository>();
        }

        // This method is called by the runtime. Use this method to configure the HTTP request pipeline.
        public static void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }

        private static void AddFluentValidation(this IServiceCollection services)
        {
            services.AddFluentValidationAutoValidation();
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
