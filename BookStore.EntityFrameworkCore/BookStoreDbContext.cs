using BookStore.Domain.UserInfo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace BookStore.EntityFrameworkCore
{
    [ConnectionStringName("Default")]
    public class BookStoreDbContext : AbpDbContext<BookStoreDbContext>
    {
        //配置需要映射的实体
        public DbSet<Users> Users { get; set; }

        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options) : base(options)
        {

        }
    }
}
