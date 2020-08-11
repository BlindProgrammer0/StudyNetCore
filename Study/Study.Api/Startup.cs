using Consumption.EFCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Study.EFCore.Context;
using System;
using System.IO;

namespace Study.Api
{
    public class Startup
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// 
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// ���÷��� ʹ�ô˷�����������ӵ������С�
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {        
            services.AddCors(options =>
            {
                options.AddPolicy("any", builder =>
                {
                    builder.AllowAnyOrigin();
                });
            });
            services.AddControllers();

            services.AddHsts(options =>
            {
                options.Preload = true;
                options.IncludeSubDomains = true;
                options.MaxAge = TimeSpan.FromDays(60);
            });

            services.AddDbContext<ConsumptionContext>(options =>
            {
                //Ǩ����Sqlite
                //var connectionString = Configuration.GetConnectionString("NoteConnection");
                //options.UseSqlite(connectionString);

                //Ǩ����MySql
                var connectionString = Configuration.GetConnectionString("MySqlNoteConnection");
                options.UseMySQL(connectionString);
            });
            services.AddUnitOfWork<ConsumptionContext>();

            //.AddCustomRepository<User, CustomUserRepository>()
            //.AddCustomRepository<UserLog, CustomUserLogRepository>()
            //.AddCustomRepository<Menu, CustomMenuRepository>()
            //.AddCustomRepository<Group, CustomGroupRepository>()
            //.AddCustomRepository<AuthItem, CustomAuthItemRepository>()
            //.AddCustomRepository<Basic, CustomBasicRepository>();

            services.AddSwaggerGen(options =>
            {
                var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "StudyApi.xml");
                options.IncludeXmlComments(path);
                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo()
                {
                    Title = "Study Service API",
                    //Version = "v1",
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact()
                    {
                        Name = "Study-WEB-API",
                        //Url = new Uri("https://github.com/HenJigg/WPF-Xamarin-Blazor-Examples")
                    }
                });
            });
        }

        /// <summary>
        /// �˷���������ʱ���á�ʹ�ô˷�������HTTP����ܵ���
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
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
         
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.ShowExtensions();
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "StudyAPI");
            });
        }
    }
}
