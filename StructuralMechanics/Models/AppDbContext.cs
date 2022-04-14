using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace StructuralMechanics.Models
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Project> Projects { get; set; }
        public DbSet<GeometryObject> GeometryObjects { get; set; }
        public DbSet<Point> Points { get; set; }
        public DbSet<SimpleShape> SimpleShapes { get; set; }
        public DbSet<StrengthMember> StrengthMembers { get; set; }
        public DbSet<VectorPhysicalQuantity> VectorPhysicalQuantities { get; set; }
        public DbSet<ShearForce> ShearForces { get; set; }
        public DbSet<Structure> Structures { get; set; }
        public DbSet<ThinWalledStructure> ThinWalledStructures { get; set; }
        public DbSet<CirclePlate> CirclePlates { get; set; }
        public DbSet<RotationalShell> RotationalShells { get; set; }


        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>().HasMany(au => au.Projects).WithOne(p => p.ApplicationUser)
                                                                        .HasForeignKey(p => p.ApplicationUserId)
                                                                        .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Project>().HasKey("Id").IsClustered(true);
            builder.Entity<Project>().HasOne(p => p.Structure).WithOne(s => s.Project)
                                                              .HasForeignKey<Structure>(s => s.ProjectId)
                                                              .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Structure>().ToTable("Structures");
            builder.Entity<Structure>().HasMany(s => s.GeometryObjects).WithOne(go => go.Structure)
                                                                       .HasForeignKey(go => go.StructureId)
                                                                       .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<ThinWalledStructure>().ToTable("ThinWalledStructures");
            builder.Entity<CirclePlate>().ToTable("CirclePlates");
            builder.Entity<RotationalShell>().ToTable("RotationalShells");

            builder.Entity<GeometryObject>().ToTable("GeometryObjects");
            builder.Entity<GeneralGeometryProperties>().ToTable("GeneralGeometryProperties");

            builder.Entity<SimpleShape>().ToTable("SimpleShapes");
            builder.Entity<SimpleShape>().HasOne(ss => ss.FirstPoint).WithOne().HasForeignKey<SimpleShape>(ss => ss.FirstPointId)
                                                                               .OnDelete(DeleteBehavior.NoAction);
            builder.Entity<SimpleShape>().HasOne(ss => ss.SecondPoint).WithOne().HasForeignKey<SimpleShape>(ss => ss.SecondPointId)
                                                                                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Arc>().ToTable("Arcs");
            builder.Entity<HorizontalLine>().ToTable("HorizontalLines");
            builder.Entity<Point>().ToTable("Points");
            builder.Entity<SlopeLine>().ToTable("SlopeLines");
            builder.Entity<StrengthMember>().ToTable("StrengthMembers");
            builder.Entity<StrengthMember>().HasOne(sm => sm.Location).WithOne().HasForeignKey<StrengthMember>(sm => sm.LocationId)
                                                                                .OnDelete(DeleteBehavior.NoAction);
            builder.Entity<VerticalLine>().ToTable("VerticalLines");

            builder.Entity<VectorPhysicalQuantity>().ToTable("VectorPhysicalQuantities");

            builder.Entity<Moment>().ToTable("Moments");
            builder.Entity<ShearForce>().ToTable("ShearForces");
            builder.Entity<ShearForce>().HasOne(sf => sf.Location).WithOne().HasForeignKey<ShearForce>(sf => sf.LocationId)
                                                                            .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
