using BookStore.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace BookStore.Api
{
    [DependsOn(
        typeof(AbpAspNetCoreMvcModule),
        typeof(BookStoreEntityFrameworkCoreModule),
        typeof(AbpAutofacModule)
        )]
    public class BookStoreApiModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            //得到服务IserverCollction
            var services = context.Services;

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BookStore.Api", Version = "v1" });
            });
        }


        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            //得到管道Configure
            var app = context.GetApplicationBuilder();
            //得到Host环境
            var env = context.GetEnvironment();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BookStore.Api v1"));
            }

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
