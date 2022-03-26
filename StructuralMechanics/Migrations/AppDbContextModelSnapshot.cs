﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StructuralMechanics.Models;

#nullable disable

namespace StructuralMechanics.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("StructuralMechanics.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("StructuralMechanics.Models.GeometryObject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("GeometryType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("GeometryObjects", (string)null);
                });

            modelBuilder.Entity("StructuralMechanics.Models.Project", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ApplicationUserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProjectName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("StructureId")
                        .HasColumnType("int");

                    b.Property<int>("StructureType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("Id"), false);

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("StructureId")
                        .IsUnique();

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("StructuralMechanics.Models.Structure", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.HasKey("Id");

                    b.ToTable("Structures", (string)null);
                });

            modelBuilder.Entity("StructuralMechanics.Models.VectorPhysicalQuantity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Direction")
                        .HasColumnType("int");

                    b.Property<double>("Magnitude")
                        .HasColumnType("float");

                    b.Property<int>("StructureId")
                        .HasColumnType("int");

                    b.Property<int>("VectorType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StructureId");

                    b.ToTable("VectorPhysicalQuantities", (string)null);
                });

            modelBuilder.Entity("StructuralMechanics.Models.CirclePlate", b =>
                {
                    b.HasBaseType("StructuralMechanics.Models.Structure");

                    b.ToTable("CirclePlates", (string)null);
                });

            modelBuilder.Entity("StructuralMechanics.Models.GeneralGeometryProperties", b =>
                {
                    b.HasBaseType("StructuralMechanics.Models.GeometryObject");

                    b.Property<double>("FirstMomentOfArea")
                        .HasColumnType("float");

                    b.Property<double>("SecondMomentOfArea")
                        .HasColumnType("float");

                    b.ToTable("GeneralGeometryProperties", (string)null);
                });

            modelBuilder.Entity("StructuralMechanics.Models.Moment", b =>
                {
                    b.HasBaseType("StructuralMechanics.Models.VectorPhysicalQuantity");

                    b.ToTable("Moments", (string)null);
                });

            modelBuilder.Entity("StructuralMechanics.Models.Point", b =>
                {
                    b.HasBaseType("StructuralMechanics.Models.GeometryObject");

                    b.Property<int>("PointPosition")
                        .HasColumnType("int");

                    b.Property<int>("StructureId")
                        .HasColumnType("int");

                    b.Property<double>("X")
                        .HasColumnType("float");

                    b.Property<double>("Y")
                        .HasColumnType("float");

                    b.HasIndex("StructureId");

                    b.ToTable("Points", (string)null);
                });

            modelBuilder.Entity("StructuralMechanics.Models.RotationalShell", b =>
                {
                    b.HasBaseType("StructuralMechanics.Models.Structure");

                    b.ToTable("RotationalShells", (string)null);
                });

            modelBuilder.Entity("StructuralMechanics.Models.ShearForce", b =>
                {
                    b.HasBaseType("StructuralMechanics.Models.VectorPhysicalQuantity");

                    b.Property<int>("LocationId")
                        .HasColumnType("int");

                    b.HasIndex("LocationId")
                        .IsUnique()
                        .HasFilter("[LocationId] IS NOT NULL");

                    b.ToTable("ShearForces", (string)null);
                });

            modelBuilder.Entity("StructuralMechanics.Models.ThinWalledStructure", b =>
                {
                    b.HasBaseType("StructuralMechanics.Models.Structure");

                    b.Property<double>("FullShearForce")
                        .HasColumnType("float");

                    b.Property<double>("MultiplicationCoefficientForShearFlow")
                        .HasColumnType("float");

                    b.Property<double>("SecondMomentOfAreaOfStructure")
                        .HasColumnType("float");

                    b.Property<int>("ThinWalledStructureType")
                        .HasColumnType("int");

                    b.ToTable("ThinWalledStructures", (string)null);
                });

            modelBuilder.Entity("StructuralMechanics.Models.SimpleShape", b =>
                {
                    b.HasBaseType("StructuralMechanics.Models.GeneralGeometryProperties");

                    b.Property<int>("FirstPointId")
                        .HasColumnType("int");

                    b.Property<double>("Length")
                        .HasColumnType("float");

                    b.Property<int>("SecondPointId")
                        .HasColumnType("int");

                    b.Property<int>("StructureId")
                        .HasColumnType("int");

                    b.Property<double>("Thickness")
                        .HasColumnType("float");

                    b.HasIndex("FirstPointId")
                        .IsUnique()
                        .HasFilter("[FirstPointId] IS NOT NULL");

                    b.HasIndex("SecondPointId")
                        .IsUnique()
                        .HasFilter("[SecondPointId] IS NOT NULL");

                    b.HasIndex("StructureId");

                    b.ToTable("SimpleShapes", (string)null);
                });

            modelBuilder.Entity("StructuralMechanics.Models.StrengthMember", b =>
                {
                    b.HasBaseType("StructuralMechanics.Models.GeneralGeometryProperties");

                    b.Property<double>("Area")
                        .HasColumnType("float");

                    b.Property<int>("LocationId")
                        .HasColumnType("int");

                    b.Property<double>("ReductionCoefficient")
                        .HasColumnType("float");

                    b.Property<int>("StructureId")
                        .HasColumnType("int");

                    b.HasIndex("LocationId")
                        .IsUnique()
                        .HasFilter("[LocationId] IS NOT NULL");

                    b.HasIndex("StructureId");

                    b.ToTable("StrengthMembers", (string)null);
                });

            modelBuilder.Entity("StructuralMechanics.Models.Arc", b =>
                {
                    b.HasBaseType("StructuralMechanics.Models.SimpleShape");

                    b.Property<int>("ArcQuadrant")
                        .HasColumnType("int");

                    b.Property<double>("Radius")
                        .HasColumnType("float");

                    b.ToTable("Arcs", (string)null);
                });

            modelBuilder.Entity("StructuralMechanics.Models.HorizontalLine", b =>
                {
                    b.HasBaseType("StructuralMechanics.Models.SimpleShape");

                    b.ToTable("HorizontalLines", (string)null);
                });

            modelBuilder.Entity("StructuralMechanics.Models.SlopeLine", b =>
                {
                    b.HasBaseType("StructuralMechanics.Models.SimpleShape");

                    b.Property<int>("SlopeAngle")
                        .HasColumnType("int");

                    b.ToTable("SlopeLines", (string)null);
                });

            modelBuilder.Entity("StructuralMechanics.Models.VerticalLine", b =>
                {
                    b.HasBaseType("StructuralMechanics.Models.SimpleShape");

                    b.ToTable("VerticalLines", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("StructuralMechanics.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("StructuralMechanics.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("StructuralMechanics.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("StructuralMechanics.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("StructuralMechanics.Models.Project", b =>
                {
                    b.HasOne("StructuralMechanics.Models.ApplicationUser", "ApplicationUser")
                        .WithMany("Projects")
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("StructuralMechanics.Models.Structure", "Structure")
                        .WithOne("Project")
                        .HasForeignKey("StructuralMechanics.Models.Project", "StructureId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ApplicationUser");

                    b.Navigation("Structure");
                });

            modelBuilder.Entity("StructuralMechanics.Models.VectorPhysicalQuantity", b =>
                {
                    b.HasOne("StructuralMechanics.Models.Structure", "Structure")
                        .WithMany("VectorPhysicalQuantities")
                        .HasForeignKey("StructureId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Structure");
                });

            modelBuilder.Entity("StructuralMechanics.Models.CirclePlate", b =>
                {
                    b.HasOne("StructuralMechanics.Models.Structure", null)
                        .WithOne()
                        .HasForeignKey("StructuralMechanics.Models.CirclePlate", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("StructuralMechanics.Models.GeneralGeometryProperties", b =>
                {
                    b.HasOne("StructuralMechanics.Models.GeometryObject", null)
                        .WithOne()
                        .HasForeignKey("StructuralMechanics.Models.GeneralGeometryProperties", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("StructuralMechanics.Models.Moment", b =>
                {
                    b.HasOne("StructuralMechanics.Models.VectorPhysicalQuantity", null)
                        .WithOne()
                        .HasForeignKey("StructuralMechanics.Models.Moment", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("StructuralMechanics.Models.Point", b =>
                {
                    b.HasOne("StructuralMechanics.Models.GeometryObject", null)
                        .WithOne()
                        .HasForeignKey("StructuralMechanics.Models.Point", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("StructuralMechanics.Models.Structure", "Structure")
                        .WithMany("Points")
                        .HasForeignKey("StructureId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Structure");
                });

            modelBuilder.Entity("StructuralMechanics.Models.RotationalShell", b =>
                {
                    b.HasOne("StructuralMechanics.Models.Structure", null)
                        .WithOne()
                        .HasForeignKey("StructuralMechanics.Models.RotationalShell", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("StructuralMechanics.Models.ShearForce", b =>
                {
                    b.HasOne("StructuralMechanics.Models.VectorPhysicalQuantity", null)
                        .WithOne()
                        .HasForeignKey("StructuralMechanics.Models.ShearForce", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("StructuralMechanics.Models.Point", "Location")
                        .WithOne()
                        .HasForeignKey("StructuralMechanics.Models.ShearForce", "LocationId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Location");
                });

            modelBuilder.Entity("StructuralMechanics.Models.ThinWalledStructure", b =>
                {
                    b.HasOne("StructuralMechanics.Models.Structure", null)
                        .WithOne()
                        .HasForeignKey("StructuralMechanics.Models.ThinWalledStructure", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("StructuralMechanics.Models.SimpleShape", b =>
                {
                    b.HasOne("StructuralMechanics.Models.Point", "FirstPoint")
                        .WithOne()
                        .HasForeignKey("StructuralMechanics.Models.SimpleShape", "FirstPointId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("StructuralMechanics.Models.GeneralGeometryProperties", null)
                        .WithOne()
                        .HasForeignKey("StructuralMechanics.Models.SimpleShape", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("StructuralMechanics.Models.Point", "SecondPoint")
                        .WithOne()
                        .HasForeignKey("StructuralMechanics.Models.SimpleShape", "SecondPointId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("StructuralMechanics.Models.Structure", "Structure")
                        .WithMany("SimpleShapes")
                        .HasForeignKey("StructureId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("FirstPoint");

                    b.Navigation("SecondPoint");

                    b.Navigation("Structure");
                });

            modelBuilder.Entity("StructuralMechanics.Models.StrengthMember", b =>
                {
                    b.HasOne("StructuralMechanics.Models.GeneralGeometryProperties", null)
                        .WithOne()
                        .HasForeignKey("StructuralMechanics.Models.StrengthMember", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("StructuralMechanics.Models.Point", "Location")
                        .WithOne()
                        .HasForeignKey("StructuralMechanics.Models.StrengthMember", "LocationId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("StructuralMechanics.Models.Structure", "Structure")
                        .WithMany("StrengthMembers")
                        .HasForeignKey("StructureId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Location");

                    b.Navigation("Structure");
                });

            modelBuilder.Entity("StructuralMechanics.Models.Arc", b =>
                {
                    b.HasOne("StructuralMechanics.Models.SimpleShape", null)
                        .WithOne()
                        .HasForeignKey("StructuralMechanics.Models.Arc", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("StructuralMechanics.Models.HorizontalLine", b =>
                {
                    b.HasOne("StructuralMechanics.Models.SimpleShape", null)
                        .WithOne()
                        .HasForeignKey("StructuralMechanics.Models.HorizontalLine", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("StructuralMechanics.Models.SlopeLine", b =>
                {
                    b.HasOne("StructuralMechanics.Models.SimpleShape", null)
                        .WithOne()
                        .HasForeignKey("StructuralMechanics.Models.SlopeLine", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("StructuralMechanics.Models.VerticalLine", b =>
                {
                    b.HasOne("StructuralMechanics.Models.SimpleShape", null)
                        .WithOne()
                        .HasForeignKey("StructuralMechanics.Models.VerticalLine", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("StructuralMechanics.Models.ApplicationUser", b =>
                {
                    b.Navigation("Projects");
                });

            modelBuilder.Entity("StructuralMechanics.Models.Structure", b =>
                {
                    b.Navigation("Points");

                    b.Navigation("Project")
                        .IsRequired();

                    b.Navigation("SimpleShapes");

                    b.Navigation("StrengthMembers");

                    b.Navigation("VectorPhysicalQuantities");
                });
#pragma warning restore 612, 618
        }
    }
}
