using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace StructuralMechanics.Models
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Project> Projects { get; set; }
        public DbSet<GeometryObject> GeometryObjects { get; set; }
        public DbSet<VectorPhysicalQuantity> VectorPhysicalQuantities { get; set; }



        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>().HasMany(au => au.Projects).WithOne(p => p.ApplicationUser);

            builder.Entity<Project>().HasKey("Id").IsClustered(false);
            builder.Entity<Project>().HasMany(p => p.GeometryObjects).WithOne(g => g.Project);
            builder.Entity<Project>().HasMany(p => p.VectorPhysicalQuantities).WithOne(vpq => vpq.Project);

            builder.Entity<GeometryObject>().ToTable("GeometryObjects");
            builder.Entity<GeometryObject>().HasKey("Id");
            builder.Entity<GeneralGeometryProperties>().ToTable("GeneralGeometryProperties");

            builder.Entity<SimpleShape>().ToTable("SimpleShapes");
            builder.Entity<SimpleShape>().HasOne(ss => ss.FirstPoint).WithOne().HasForeignKey<SimpleShape>(ss => ss.FirstPointId);
            builder.Entity<SimpleShape>().HasOne(ss => ss.SecondPoint).WithOne().HasForeignKey<SimpleShape>(ss => ss.SecondPointId);

            builder.Entity<Arc>().ToTable("Arcs");
            builder.Entity<HorizontalLine>().ToTable("HorizontalLines");
            builder.Entity<Point>().ToTable("Points");
            builder.Entity<SlopeLine>().ToTable("SlopeLines");
            builder.Entity<StrengthMember>().ToTable("StrengthMembers");
            builder.Entity<StrengthMember>().HasOne(sm => sm.Location).WithOne().HasForeignKey<StrengthMember>(sm => sm.LocationId);
            builder.Entity<VerticalLine>().ToTable("VerticalLines");

            builder.Entity<VectorPhysicalQuantity>().ToTable("VectorPhysicalQuantities");
            builder.Entity<VectorPhysicalQuantity>().HasKey("Id");

            builder.Entity<Moment>().ToTable("Moments");
            builder.Entity<ShearForce>().ToTable("ShearForces");
            builder.Entity<ShearForce>().HasOne(sf => sf.Location).WithOne().HasForeignKey<ShearForce>(sf => sf.LocationId);


            foreach (var foreignKey in builder.Model.GetEntityTypes()
                                                    .SelectMany(e => e.GetForeignKeys()))
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
    }
}
