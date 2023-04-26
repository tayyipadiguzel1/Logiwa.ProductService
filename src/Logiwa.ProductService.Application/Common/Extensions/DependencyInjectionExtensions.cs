using System.Reflection;
using Logiwa.ProductService.Domain.Data.EntityFramework;
using Logiwa.ProductService.Domain.Data.EntityFramework.UnitOfWorks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Logiwa.ProductService.Application.Common.Extensions
{
    /// <summary>
    /// DependencyInjectionExtensions
    /// </summary>
    public static class DependencyInjectionExtensions
    {
        public static void Register(this IServiceCollection services)
        {
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<DataContext>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            
        }
    }
}
