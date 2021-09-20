using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.EntityFrameworkCore
{
    /**************************************************
    * 
    * DbContext工厂类，如果DbContext中，无法使用无参构造函数，
    * 那就应该创建这个类，实现IDesignTimeDbContextFactory接
    * 口，这样EF tool在Migration的时候，就不会管你有没有参数了，
    * 都会默认来这里，执行这里的创建DbContext方法。
    * 
    **************************************************/
    public class BookStoreDbContextFactory : IDesignTimeDbContextFactory<BookStoreDbContext>
    {
        public BookStoreDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: false).Build();

            var builder = new DbContextOptionsBuilder<BookStoreDbContext>()
                .UseMySql(configuration.GetConnectionString("Default"),
                MySqlServerVersion.LatestSupportedServerVersion);

            return new BookStoreDbContext(builder.Options);
        }
    }
}
