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
            serviceCollection.AddScoped<IGeometryObjectRepository, SQLServerGeometryObjectRepository>();
            serviceCollection.AddScoped<IVectorPhysicalQuantityRepository, SQLServerVectorPhysicalQuantityRepository>();
            serviceCollection.AddScoped<IPointsRepository, SQLServerPointsRepository>();
            serviceCollection.AddScoped<ISimpleShapesRepository, SQLServerSimpleShapesRepository>();
        }
    }
}
