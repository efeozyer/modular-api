using Microsoft.AspNetCore.Builder;

namespace Modular.Platform
{
    public static class ServiceCollectionExtensions
    {
        private static readonly List<Module> Modules = new();

        public static WebApplicationBuilder AddModule<TModule>(this WebApplicationBuilder builder)
            where TModule : Module
        {
            var module = Activator.CreateInstance<TModule>();
            Modules.Add(module);
            module.Install();
            return builder;
        }
    }
}
