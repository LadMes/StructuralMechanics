namespace StructuralMechanics.Utilities
{
    public static class ServiceCollectionExtensions
    {
        public static void AddProjectServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IProjectService, SQLServerProjectService>();
            serviceCollection.AddScoped<IStructureService, SQLServerStructureService>();
        }
        public static void AddModelServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IGeometryObjectService, SQLServerGeometryObjectService>();
            serviceCollection.AddScoped<IVectorPhysicalQuantityService, SQLServerVectorPhysicalQuantityService>();
            serviceCollection.AddScoped<IPointsService, SQLServerPointsService>();
            serviceCollection.AddScoped<ISimpleShapesService, SQLServerSimpleShapesService>();
        }
    }
}
