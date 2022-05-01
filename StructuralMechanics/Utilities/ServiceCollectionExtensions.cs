namespace StructuralMechanics.Utilities
{
    public static class ServiceCollectionExtensions
    {
        public static void AddProjectServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IProjectRepository, SQLServerProjectRepository>();
            serviceCollection.AddScoped<IStructureRepository, SQLServerStructureRepository>();
        }
        public static void AddModelServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<ICrossSectionElementRepository, SQLServerCrossSectionRepository>();
            serviceCollection.AddScoped<IVectorPhysicalQuantityRepository, SQLServerVectorPhysicalQuantityRepository>();
            serviceCollection.AddScoped<IPointRepository, SQLServerPointRepository>();
            serviceCollection.AddScoped<ICrossSectionPartRepository, SQLServerCrossSectionPartRepository>();
        }
    }
}
