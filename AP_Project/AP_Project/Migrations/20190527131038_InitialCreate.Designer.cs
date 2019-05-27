﻿// <auto-generated />
using System;
using AP_Project.Back_End.Modals;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AP_Project.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20190527131038_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AP_Project.Back_End.Modals.Persons.Person", b =>
                {
                    b.Property<int>("PersonId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<short?>("AccessLevel");

                    b.Property<string>("Email");

                    b.Property<string>("FullName");

                    b.Property<string>("Password");

                    b.Property<string>("PhoneNumber");

                    b.Property<string>("UserName");

                    b.HasKey("PersonId");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("AP_Project.Back_End.Modals.Products.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Category");

                    b.Property<string>("Explanations");

                    b.Property<string>("ManuFacturer");

                    b.Property<int?>("PersonId");

                    b.Property<int>("ProductBarcode");

                    b.Property<string>("ProductName");

                    b.Property<string>("ProductPhotoAdress");

                    b.Property<int>("Store");

                    b.HasKey("ProductId");

                    b.HasIndex("PersonId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("AP_Project.Back_End.Modals.Products.Product", b =>
                {
                    b.HasOne("AP_Project.Back_End.Modals.Persons.Person")
                        .WithMany("Cart")
                        .HasForeignKey("PersonId");
                });
#pragma warning restore 612, 618
        }
    }
}
