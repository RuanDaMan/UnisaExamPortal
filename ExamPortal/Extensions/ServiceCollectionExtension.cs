using System.Security.Claims;
using System.Text;
using ExamPortal.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.Extensions.Options;

namespace ExamPortal.Extensions
{
    public static class ServiceCollectionExtensions
    {
       

        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {

            var connectionFactory = new MsSqlDbConnectionFactory(configuration.GetConnectionString("DefaultConnection"));
            
            services.AddTransient<IDbConnectionFactory>(provider => connectionFactory);
            
            return services;
        }
        

       
    }
}