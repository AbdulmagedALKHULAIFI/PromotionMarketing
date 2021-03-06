// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PromotionMarketing.Data;

namespace PromotionMarketing.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20211212155052_ManyToManyAdded2")]
    partial class ManyToManyAdded2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PromotionMarketing.Models.Op", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("EndDateOperation")
                        .HasColumnType("datetime2");

                    b.Property<string>("Enseigne")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OpName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("StartDateOperation")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Ops");
                });

            modelBuilder.Entity("PromotionMarketing.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Brand")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("PromotionMarketing.Models.Product_Op", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("OpId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OpId");

                    b.HasIndex("ProductId");

                    b.ToTable("Product_Op");
                });

            modelBuilder.Entity("PromotionMarketing.Models.Product_Op", b =>
                {
                    b.HasOne("PromotionMarketing.Models.Op", "Op")
                        .WithMany("Product_Ops")
                        .HasForeignKey("OpId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PromotionMarketing.Models.Product", "Product")
                        .WithMany("Product_Ops")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Op");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("PromotionMarketing.Models.Op", b =>
                {
                    b.Navigation("Product_Ops");
                });

            modelBuilder.Entity("PromotionMarketing.Models.Product", b =>
                {
                    b.Navigation("Product_Ops");
                });
#pragma warning restore 612, 618
        }
    }
}
