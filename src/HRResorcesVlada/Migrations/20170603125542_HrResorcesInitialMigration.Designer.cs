using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using HRResorcesVlada.Entities;

namespace HRResorcesVlada.Migrations
{
    [DbContext(typeof(HrResorcesContext))]
    [Migration("20170603125542_HrResorcesInitialMigration")]
    partial class HrResorcesInitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HRResorcesVlada.Entities.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City");

                    b.Property<string>("Country");

                    b.Property<string>("Description");

                    b.Property<string>("EmailAdress");

                    b.Property<string>("Name");

                    b.Property<string>("Phone");

                    b.Property<string>("WebSite");

                    b.HasKey("Id");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("HRResorcesVlada.Entities.JobPosition", b =>
                {
                    b.Property<int>("JobId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("JobCity");

                    b.Property<string>("JobCountry");

                    b.Property<string>("JobDescription");

                    b.Property<string>("JobKeyWords");

                    b.Property<string>("JobName");

                    b.Property<string>("JobPartTime");

                    b.HasKey("JobId");

                    b.ToTable("Jobpositions");
                });

            modelBuilder.Entity("HRResorcesVlada.Entities.RegularUser", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("UserCity");

                    b.Property<string>("UserDateOfBirth");

                    b.Property<string>("UserFullTimeJob");

                    b.Property<string>("UserKeyWords");

                    b.Property<string>("UserName");

                    b.Property<string>("UserSex");

                    b.Property<string>("UserSurname");

                    b.Property<string>("UserVilingToChangeLocation");

                    b.Property<string>("UserWorkExperience");

                    b.HasKey("UserId");

                    b.ToTable("RegularUsers");
                });
        }
    }
}
