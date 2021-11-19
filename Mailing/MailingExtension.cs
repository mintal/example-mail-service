using Microsoft.Extensions.DependencyInjection;

namespace MailChimp
{
    public static class MailingExtension
    {
        public static IServiceCollection AddMail(this IServiceCollection services)
        {
            services.AddScoped<MailService>();
            return services;
        }
    }
}