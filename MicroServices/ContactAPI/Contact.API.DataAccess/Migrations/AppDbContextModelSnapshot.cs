﻿// <auto-generated />
using System;
using Contact.API.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Contact.API.DataAccess.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.14")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Contact.API.Entities.Contact", b =>
                {
                    b.Property<string>("UUID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Firm")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UUID");

                    b.ToTable("Contact");
                });

            modelBuilder.Entity("Contact.API.Entities.ContactInformation", b =>
                {
                    b.Property<string>("UUID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ContactUUID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UUID");

                    b.HasIndex("ContactUUID");

                    b.ToTable("ContactInformation");
                });

            modelBuilder.Entity("Contact.API.Entities.ContactInformation", b =>
                {
                    b.HasOne("Contact.API.Entities.Contact", null)
                        .WithMany("ContactInformations")
                        .HasForeignKey("ContactUUID");
                });

            modelBuilder.Entity("Contact.API.Entities.Contact", b =>
                {
                    b.Navigation("ContactInformations");
                });
#pragma warning restore 612, 618
        }
    }
}
