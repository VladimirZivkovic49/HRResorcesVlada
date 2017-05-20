using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using HRResorcesVlada.Entities;

namespace HRResorcesVlada.Migrations
{
    [DbContext(typeof(HrResorcesContext))]
    [Migration("20170520121137_HrRecorsesInitialMigration")]
    partial class HrRecorsesInitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HRResorcesVlada.Entities.Company", b =>
                {
                    b.Property<string>("Name")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City");

                    b.Property<string>("Country");

                    b.Property<string>("Description");

                    b.Property<string>("EmailAdress");

                    b.Property<int>("Id");

                    b.Property<string>("Phone");

                    b.Property<string>("WebSite");

                    b.HasKey("Name");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("HRResorcesVlada.Entities.JobPosition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City");

                    b.Property<int?>("CompanyId");

                    b.Property<string>("CompanyName");

                    b.Property<string>("Country");

                    b.Property<string>("Description");

                    b.Property<string>("KeyWords");

                    b.Property<string>("Name");

                    b.Property<string>("PartTime");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("CompanyName");

                    b.ToTable("Jobpositions");
                });

            modelBuilder.Entity("HRResorcesVlada.Entities.RegularUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City");

                    b.Property<string>("FullTimeJob");

                    b.Property<string>("KeyWords");

                    b.Property<string>("Name");

                    b.Property<string>("Surname");

                    b.Property<string>("VilingToChangeLocation");

                    b.Property<string>("WorkExperience");

                    b.HasKey("Id");

                    b.ToTable("RegularUsers");
                });

            modelBuilder.Entity("HRResorcesVlada.Entities.JobPosition", b =>
                {
                    b.HasOne("HRResorcesVlada.Entities.RegularUser", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId");

                    b.HasOne("HRResorcesVlada.Entities.Company")
                        .WithMany("JobsPosition")
                        .HasForeignKey("CompanyName");
                });
        }
    }
}
