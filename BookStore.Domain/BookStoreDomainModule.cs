using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace BookStore.Domain
{
    [DependsOn(
        typeof(AbpDddDomainModule)
        )]
    public class BookStoreDomainModule : AbpModule
    {
    }


}
