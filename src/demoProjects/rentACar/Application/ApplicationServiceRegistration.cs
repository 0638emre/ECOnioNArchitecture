//using Application.Features.Brands.Rules;
using Application.Features.Brands.Rules;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
namespace Application
{
    //burada IOC container ile application servislerimizi registraion ediyoruz
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddScoped<BrandsBusinessRules>();
            return services;
        }
    }
}
