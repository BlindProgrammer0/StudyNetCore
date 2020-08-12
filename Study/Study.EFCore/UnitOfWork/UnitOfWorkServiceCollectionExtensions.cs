

namespace Consumption.EFCore
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    /// 用于设置与工作相关的服务单元的扩展方法  <see cref="IServiceCollection"/>.
    /// </summary>
    public static class UnitOfWorkServiceCollectionExtensions
    {
        /// <summary>
        /// 将给定上下文的工作单元注册为服务 in the <see cref="IServiceCollection"/>.
        /// </summary>
        /// <typeparam name="TContext">数据库上下文的类型.</typeparam>
        /// <param name="services">The <see cref="IServiceCollection"/> to add services to.</param>
        /// <returns>相同的服务集合，以便可以链接多个调用。</returns>
        /// <remarks>
        /// 此方法只支持一个db上下文，如果调用多次，将抛出异常。
        /// </remarks>
        public static IServiceCollection AddUnitOfWork<TContext>(this IServiceCollection services) where TContext : DbContext
        {
            services.AddScoped<IRepositoryFactory, UnitOfWork<TContext>>();
            // 下面有一个问题:IUnitOfWork不能支持多个dbcontext/数据库， 
            // 这意味着不能多次调用AddUnitOfWork。
            // 解决方案:检查IUnitOfWork是否为空
            services.AddScoped<IUnitOfWork, UnitOfWork<TContext>>();
            services.AddScoped<IUnitOfWork<TContext>, UnitOfWork<TContext>>();

            return services;
        }

        /// <summary>
        /// 将给定上下文的工作单元注册为服务 in the <see cref="IServiceCollection"/>.
        /// </summary>
        /// <typeparam name="TContext1">数据库上下文的类型。</typeparam>
        /// <typeparam name="TContext2">数据库上下文的类型。</typeparam>
        /// <param name="services">The <see cref="IServiceCollection"/> to add services to.</param>
        /// <returns>相同的服务集合，以便可以链接多个调用。</returns>
        /// <remarks>
        /// 此方法只支持一个db上下文，如果调用多次，将抛出异常。
        /// </remarks>
        public static IServiceCollection AddUnitOfWork<TContext1, TContext2>(this IServiceCollection services)
            where TContext1 : DbContext
            where TContext2 : DbContext
        {
            services.AddScoped<IUnitOfWork<TContext1>, UnitOfWork<TContext1>>();
            services.AddScoped<IUnitOfWork<TContext2>, UnitOfWork<TContext2>>();

            return services;
        }

        /// <summary>
        /// Registers the unit of work given context as a service in the <see cref="IServiceCollection"/>.
        /// </summary>
        /// <typeparam name="TContext1">The type of the db context.</typeparam>
        /// <typeparam name="TContext2">The type of the db context.</typeparam>
        /// <typeparam name="TContext3">The type of the db context.</typeparam>
        /// <param name="services">The <see cref="IServiceCollection"/> to add services to.</param>
        /// <returns>The same service collection so that multiple calls can be chained.</returns>
        /// <remarks>
        /// This method only support one db context, if been called more than once, will throw exception.
        /// </remarks>
        public static IServiceCollection AddUnitOfWork<TContext1, TContext2, TContext3>(this IServiceCollection services)
            where TContext1 : DbContext
            where TContext2 : DbContext
            where TContext3 : DbContext
        {
            services.AddScoped<IUnitOfWork<TContext1>, UnitOfWork<TContext1>>();
            services.AddScoped<IUnitOfWork<TContext2>, UnitOfWork<TContext2>>();
            services.AddScoped<IUnitOfWork<TContext3>, UnitOfWork<TContext3>>();

            return services;
        }

        /// <summary>
        /// Registers the unit of work given context as a service in the <see cref="IServiceCollection"/>.
        /// </summary>
        /// <typeparam name="TContext1">The type of the db context.</typeparam>
        /// <typeparam name="TContext2">The type of the db context.</typeparam>
        /// <typeparam name="TContext3">The type of the db context.</typeparam>
        /// <typeparam name="TContext4">The type of the db context.</typeparam>
        /// <param name="services">The <see cref="IServiceCollection"/> to add services to.</param>
        /// <returns>The same service collection so that multiple calls can be chained.</returns>
        /// <remarks>
        /// This method only support one db context, if been called more than once, will throw exception.
        /// </remarks>
        public static IServiceCollection AddUnitOfWork<TContext1, TContext2, TContext3, TContext4>(this IServiceCollection services)
            where TContext1 : DbContext
            where TContext2 : DbContext
            where TContext3 : DbContext
            where TContext4 : DbContext
        {
            services.AddScoped<IUnitOfWork<TContext1>, UnitOfWork<TContext1>>();
            services.AddScoped<IUnitOfWork<TContext2>, UnitOfWork<TContext2>>();
            services.AddScoped<IUnitOfWork<TContext3>, UnitOfWork<TContext3>>();
            services.AddScoped<IUnitOfWork<TContext4>, UnitOfWork<TContext4>>();

            return services;
        }

        /// <summary>
        /// Registers the custom repository as a service in the <see cref="IServiceCollection"/>.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <typeparam name="TRepository">The type of the custom repositry.</typeparam>
        /// <param name="services">The <see cref="IServiceCollection"/> to add services to.</param>
        /// <returns>The same service collection so that multiple calls can be chained.</returns>
        public static IServiceCollection AddCustomRepository<TEntity, TRepository>(this IServiceCollection services)
            where TEntity : class
            where TRepository : class, IRepository<TEntity>
        {
            services.AddScoped<IRepository<TEntity>, TRepository>();

            return services;
        }
    }
}
