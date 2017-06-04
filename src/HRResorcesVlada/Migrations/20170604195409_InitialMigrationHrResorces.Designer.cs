using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using HRResorcesVlada.Entities;

namespace HRResorcesVlada.Migrations
{
    [DbContext(typeof(HrResorcesContext))]
    [Migration("20170604195409_InitialMigrationHrResorces")]
    partial class InitialMigrationHrResorces
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

                    b.Property<string>("Phone");

                    b.Property<string>("WebSite");

                    b.HasKey("Name");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("HRResorcesVlada.Entities.JobPosition", b =>
                {
                    b.Property<int>("JobId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CompanyName");

                    b.Property<string>("JobCity");

                    b.Property<string>("JobCountry");

                    b.Property<string>("JobDescription");

                    b.Property<string>("JobKeyWords");

                    b.Property<string>("JobName");

                    b.Property<string>("JobPartTime");

                    b.HasKey("JobId");

                    b.HasIndex("CompanyName");

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

            modelBuilder.Entity("HRResorcesVlada.Entities.JobPosition", b =>
                {
                    b.HasOne("HRResorcesVlada.Entities.Company", "Company")
                        .WithMany("Jobpositions")
                        .HasForeignKey("CompanyName");
                });
        }
    }
}
