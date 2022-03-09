using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace StructuralMechanics.Models
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Project> Projects { get; set; }
        //public DbSet<Point> Points { get; set; }
        //public DbSet<Arc> Arcs { get; set; }
        //public DbSet<HorizontalLine> HorizontalLines { get; set; }
        //public DbSet<SlopeLine> SlopeLines { get; set; }
        //public DbSet<VerticalLine> VerticalLines { get; set; }
        //public DbSet<StrengthMember> StrengthMembers { get; set; }
        //public DbSet<Moment> Moments { get; set; }
        //public DbSet<ShearForce> ShearForces { get; set; }
        public DbSet<GeometryObject> GeometryObjects { get; set; }
        //public DbSet<VectorPhysicalQuantity> VectorPhysicalQuantities { get; set; }



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
            //builder.Entity<ShapeSharedInfo>().ToTable("ShapeSharedInfos");
            //builder.Entity<BasicShape>().ToTable("BasicShapes");

            ////builder.Entity<BasicShape>().HasOne(b => b.FirstPoint).WithOne();

            //builder.Entity<Arc>().ToTable("Arcs");
            //builder.Entity<Arc>(
            //    p =>
            //    {
            //        p.Property(m => m.FirstPoint);
            //        p.Property(m => m.SecondPoint);
            //        p.Property(m => m.Thickness);
            //    });
            ////builder.Entity<Arc>().HasOne(b => b.FirstPoint).WithOne();
            //builder.Entity<HorizontalLine>().ToTable("HorizontalLines");
            //builder.Entity<HorizontalLine>(
            //    p =>
            //    {
            //        p.Property(m => m.FirstPoint);
            //        p.Property(m => m.SecondPoint);
            //        p.Property(m => m.Thickness);
            //    });
            builder.Entity<Point>().ToTable("Points");
            //builder.Entity<SlopeLine>().ToTable("SlopeLines");
            //builder.Entity<SlopeLine>(
            //    p =>
            //    {
            //        p.Property(m => m.FirstPoint);
            //        p.Property(m => m.SecondPoint);
            //        p.Property(m => m.Thickness);
            //    });
            //builder.Entity<StrengthMember>().ToTable("StrengthMembers");
            //builder.Entity<StrengthMember>(
            //    p =>
            //    {
            //        p.Property(m => m.ReductionCoefficient);
            //        p.Property(m => m.Area);
            //        p.Property(m => m.Location);
            //    });
            //builder.Entity<VerticalLine>().ToTable("VerticalLines");
            //builder.Entity<VerticalLine>(
            //    p =>
            //    {
            //        p.Property(m => m.FirstPoint);
            //        p.Property(m => m.SecondPoint);
            //        p.Property(m => m.Thickness);
            //    });


            builder.Entity<VectorPhysicalQuantity>().ToTable("VectorPhysicalQuantities");
            builder.Entity<VectorPhysicalQuantity>().HasKey("Id");

            //builder.Entity<Moment>().ToTable("Moments");
            //builder.Entity<Moment>(
            //    p =>
            //    {
            //        p.Property(m => m.Magnitude);
            //        p.Property(m => m.Direction);
            //    });
            builder.Entity<ShearForce>().ToTable("ShearForces");
            builder.Entity<ShearForce>().HasOne(sf => sf.Location).WithOne(p => p.ShearForce);
            builder.Entity<ShearForce>(
                p =>
                {
                    p.Property(m => m.Location);
                });


            foreach (var foreignKey in builder.Model.GetEntityTypes()
                                                    .SelectMany(e => e.GetForeignKeys()))
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
    }
}
