using MyFirstAPI.UseCase.Contas.GetAllContas;

namespace MyFirstAPI
{
    public static class UseCaseDependencyInjection
    {
        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            // Add use case handlers here
            services.AddScoped<GetAllContasHandler>();
            // Add other use case handlers as needed
            return services;
        }
    }
}
