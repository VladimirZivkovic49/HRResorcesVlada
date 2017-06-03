using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HRResorcesVlada.Migrations
{
    public partial class HrResorcesInitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    City = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    EmailAdress = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    WebSite = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Jobpositions",
                columns: table => new
                {
                    JobId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    JobCity = table.Column<string>(nullable: true),
                    JobCountry = table.Column<string>(nullable: true),
                    JobDescription = table.Column<string>(nullable: true),
                    JobKeyWords = table.Column<string>(nullable: true),
                    JobName = table.Column<string>(nullable: true),
                    JobPartTime = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobpositions", x => x.JobId);
                });

            migrationBuilder.CreateTable(
                name: "RegularUsers",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserCity = table.Column<string>(nullable: true),
                    UserFullTimeJob = table.Column<string>(nullable: true),
                    UserKeyWords = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true),
                    UserSurname = table.Column<string>(nullable: true),
                    UserVilingToChangeLocation = table.Column<string>(nullable: true),
                    UserWorkExperience = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegularUsers", x => x.UserId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "Jobpositions");

            migrationBuilder.DropTable(
                name: "RegularUsers");
        }
    }
}
