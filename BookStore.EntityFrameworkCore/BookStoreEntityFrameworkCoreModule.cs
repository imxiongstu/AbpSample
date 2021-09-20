using BookStore.Domain;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace BookStore.EntityFrameworkCore
{
    [DependsOn(
        typeof(AbpEntityFrameworkCoreModule),
        typeof(BookStoreDomainModule)
        )]
    public class BookStoreEntityFrameworkCoreModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var services = context.Services;

            services.AddAbpDbContext<BookStoreDbContext>(options =>
            {
                //启用仓库模式
                options.AddDefaultRepositories(true);
            });

            Configure<AbpDbContextOptions>(options =>
            {
                //配置上下文的数据库对象为Mysql
                options.UseMySQL();
            });
        }
    }
}
