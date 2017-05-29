using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using HRResorcesVlada.Entities;

namespace HRResorcesVlada.Migrations
{
    [DbContext(typeof(HrResorcesContext))]
    partial class HrResorcesContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City");

                    b.Property<string>("Country");

                    b.Property<string>("Description");

                    b.Property<string>("KeyWords");

                    b.Property<string>("Name");

                    b.Property<string>("PartTime");

                    b.HasKey("Id");

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
        }
    }
}
