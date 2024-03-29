﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StructuralMechanics.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProjectName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_Projects_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Structures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(type: "int", nullable: false),
                    ProjectId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Structures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Structures_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CirclePlates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CirclePlates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CirclePlates_Structures_Id",
                        column: x => x.Id,
                        principalTable: "Structures",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CrossSectionElements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ElementType = table.Column<int>(type: "int", nullable: false),
                    StructureId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CrossSectionElements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CrossSectionElements_Structures_StructureId",
                        column: x => x.StructureId,
                        principalTable: "Structures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RotationalShells",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RotationalShells", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RotationalShells_Structures_Id",
                        column: x => x.Id,
                        principalTable: "Structures",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ThinWalledStructures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    ThinWalledStructureType = table.Column<int>(type: "int", nullable: false),
                    SecondMomentOfAreaOfStructure = table.Column<double>(type: "float", nullable: false),
                    FullShearForce = table.Column<double>(type: "float", nullable: false),
                    MultiplicationCoefficientForShearFlow = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThinWalledStructures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ThinWalledStructures_Structures_Id",
                        column: x => x.Id,
                        principalTable: "Structures",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "VectorPhysicalQuantities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Magnitude = table.Column<double>(type: "float", nullable: false),
                    Direction = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    StructureId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VectorPhysicalQuantities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VectorPhysicalQuantities_Structures_StructureId",
                        column: x => x.StructureId,
                        principalTable: "Structures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AreaProperties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    FirstMomentOfArea = table.Column<double>(type: "float", nullable: false),
                    SecondMomentOfArea = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AreaProperties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AreaProperties_CrossSectionElements_Id",
                        column: x => x.Id,
                        principalTable: "CrossSectionElements",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Points",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    X = table.Column<double>(type: "float", nullable: false),
                    Y = table.Column<double>(type: "float", nullable: false),
                    PointPosition = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Points", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Points_CrossSectionElements_Id",
                        column: x => x.Id,
                        principalTable: "CrossSectionElements",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Moments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Moments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Moments_VectorPhysicalQuantities_Id",
                        column: x => x.Id,
                        principalTable: "VectorPhysicalQuantities",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CrossSectionParts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Thickness = table.Column<double>(type: "float", nullable: false),
                    Length = table.Column<double>(type: "float", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    FirstPointId = table.Column<int>(type: "int", nullable: false),
                    SecondPointId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CrossSectionParts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CrossSectionParts_AreaProperties_Id",
                        column: x => x.Id,
                        principalTable: "AreaProperties",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CrossSectionParts_Points_FirstPointId",
                        column: x => x.FirstPointId,
                        principalTable: "Points",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CrossSectionParts_Points_SecondPointId",
                        column: x => x.SecondPointId,
                        principalTable: "Points",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ShearForces",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShearForces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShearForces_Points_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Points",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ShearForces_VectorPhysicalQuantities_Id",
                        column: x => x.Id,
                        principalTable: "VectorPhysicalQuantities",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StrengthMembers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    ReductionCoefficient = table.Column<double>(type: "float", nullable: false),
                    Area = table.Column<double>(type: "float", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StrengthMembers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StrengthMembers_AreaProperties_Id",
                        column: x => x.Id,
                        principalTable: "AreaProperties",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StrengthMembers_Points_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Points",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Arcs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Radius = table.Column<double>(type: "float", nullable: false),
                    ArcQuadrant = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Arcs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Arcs_CrossSectionParts_Id",
                        column: x => x.Id,
                        principalTable: "CrossSectionParts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "HorizontalLines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HorizontalLines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HorizontalLines_CrossSectionParts_Id",
                        column: x => x.Id,
                        principalTable: "CrossSectionParts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SlopeLines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    SlopeAngle = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SlopeLines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SlopeLines_CrossSectionParts_Id",
                        column: x => x.Id,
                        principalTable: "CrossSectionParts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "VerticalLines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VerticalLines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VerticalLines_CrossSectionParts_Id",
                        column: x => x.Id,
                        principalTable: "CrossSectionParts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CrossSectionElements_StructureId",
                table: "CrossSectionElements",
                column: "StructureId");

            migrationBuilder.CreateIndex(
                name: "IX_CrossSectionParts_FirstPointId",
                table: "CrossSectionParts",
                column: "FirstPointId");

            migrationBuilder.CreateIndex(
                name: "IX_CrossSectionParts_SecondPointId",
                table: "CrossSectionParts",
                column: "SecondPointId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ApplicationUserId",
                table: "Projects",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ShearForces_LocationId",
                table: "ShearForces",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_StrengthMembers_LocationId",
                table: "StrengthMembers",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Structures_ProjectId",
                table: "Structures",
                column: "ProjectId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VectorPhysicalQuantities_StructureId",
                table: "VectorPhysicalQuantities",
                column: "StructureId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Arcs");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CirclePlates");

            migrationBuilder.DropTable(
                name: "HorizontalLines");

            migrationBuilder.DropTable(
                name: "Moments");

            migrationBuilder.DropTable(
                name: "RotationalShells");

            migrationBuilder.DropTable(
                name: "ShearForces");

            migrationBuilder.DropTable(
                name: "SlopeLines");

            migrationBuilder.DropTable(
                name: "StrengthMembers");

            migrationBuilder.DropTable(
                name: "ThinWalledStructures");

            migrationBuilder.DropTable(
                name: "VerticalLines");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "VectorPhysicalQuantities");

            migrationBuilder.DropTable(
                name: "CrossSectionParts");

            migrationBuilder.DropTable(
                name: "AreaProperties");

            migrationBuilder.DropTable(
                name: "Points");

            migrationBuilder.DropTable(
                name: "CrossSectionElements");

            migrationBuilder.DropTable(
                name: "Structures");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
