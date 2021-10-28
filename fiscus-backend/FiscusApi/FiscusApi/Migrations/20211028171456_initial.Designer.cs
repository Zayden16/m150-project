﻿// <auto-generated />
using FiscusApi.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace FiscusApi.Migrations
{
    [DbContext(typeof(SqlContext))]
    [Migration("20211028171456_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("FiscusApi.Models.Article", b =>
                {
                    b.Property<int>("Article_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Article_Description")
                        .HasColumnType("text");

                    b.Property<double>("Article_Price")
                        .HasColumnType("double precision");

                    b.Property<int>("Article_TaxRate")
                        .HasColumnType("integer");

                    b.Property<string>("Article_Title")
                        .HasColumnType("text");

                    b.Property<int>("Article_Unit")
                        .HasColumnType("integer");

                    b.HasKey("Article_Id");

                    b.HasIndex("Article_TaxRate");

                    b.HasIndex("Article_Unit");

                    b.ToTable("Article");
                });

            modelBuilder.Entity("FiscusApi.Models.ArticlePosition", b =>
                {
                    b.Property<int>("ArticlePosition_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("Article_Id")
                        .HasColumnType("integer");

                    b.Property<double>("Article_Quantity")
                        .HasColumnType("double precision");

                    b.Property<int>("Document_Id")
                        .HasColumnType("integer");

                    b.HasKey("ArticlePosition_Id");

                    b.HasIndex("Article_Id");

                    b.HasIndex("Document_Id");

                    b.ToTable("ArticlePosition");
                });

            modelBuilder.Entity("FiscusApi.Models.ArticleUnit", b =>
                {
                    b.Property<int>("ArticleUnit_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ArticleUnit_Text")
                        .HasColumnType("text");

                    b.HasKey("ArticleUnit_Id");

                    b.ToTable("ArticleUnit");
                });

            modelBuilder.Entity("FiscusApi.Models.Customer", b =>
                {
                    b.Property<int>("Customer_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Customer_Address1")
                        .HasColumnType("text");

                    b.Property<string>("Customer_Address2")
                        .HasColumnType("text");

                    b.Property<string>("Customer_Email")
                        .HasColumnType("text");

                    b.Property<string>("Customer_FirstName")
                        .HasColumnType("text");

                    b.Property<string>("Customer_LastName")
                        .HasColumnType("text");

                    b.Property<int>("Customer_PlzId")
                        .HasColumnType("integer");

                    b.HasKey("Customer_Id");

                    b.HasIndex("Customer_PlzId");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("FiscusApi.Models.Document", b =>
                {
                    b.Property<int>("Document_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("Document_CreatorId")
                        .HasColumnType("integer");

                    b.Property<int>("Document_Number")
                        .HasColumnType("integer");

                    b.Property<int>("Document_SendeeId")
                        .HasColumnType("integer");

                    b.Property<int>("Document_StatusId")
                        .HasColumnType("integer");

                    b.Property<int>("Document_TypeId")
                        .HasColumnType("integer");

                    b.HasKey("Document_Id");

                    b.HasIndex("Document_CreatorId");

                    b.HasIndex("Document_SendeeId");

                    b.HasIndex("Document_StatusId");

                    b.HasIndex("Document_TypeId");

                    b.ToTable("Document");
                });

            modelBuilder.Entity("FiscusApi.Models.DocumentDetail", b =>
                {
                    b.Property<decimal>("ArtPos_Quantity")
                        .HasColumnType("numeric");

                    b.Property<string>("ArtUnit_Text")
                        .HasColumnType("text");

                    b.Property<string>("Art_Description")
                        .HasColumnType("text");

                    b.Property<decimal>("Art_Price")
                        .HasColumnType("numeric");

                    b.Property<string>("Art_Title")
                        .HasColumnType("text");

                    b.Property<string>("Customer_Address1")
                        .HasColumnType("text");

                    b.Property<string>("Customer_FirstName")
                        .HasColumnType("text");

                    b.Property<string>("Customer_LastName")
                        .HasColumnType("text");

                    b.Property<string>("Customer_PlzCity")
                        .HasColumnType("text");

                    b.Property<string>("Customer_PlzNumber")
                        .HasColumnType("text");

                    b.Property<int>("Document_Number")
                        .HasColumnType("integer");

                    b.Property<decimal>("TaxRate_Percentage")
                        .HasColumnType("numeric");

                    b.Property<string>("User_FirstName")
                        .HasColumnType("text");

                    b.Property<string>("User_IBAN")
                        .HasColumnType("text");

                    b.Property<string>("User_LastName")
                        .HasColumnType("text");

                    b.Property<string>("User_Mail")
                        .HasColumnType("text");

                    b.Property<string>("User_RefNumber")
                        .HasColumnType("text");

                    b.ToTable("DocumentDetail");
                });

            modelBuilder.Entity("FiscusApi.Models.DocumentStatus", b =>
                {
                    b.Property<int>("DocumentStatus_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("DocumentStatus_Description")
                        .HasColumnType("text");

                    b.HasKey("DocumentStatus_Id");

                    b.ToTable("DocumentStatus");
                });

            modelBuilder.Entity("FiscusApi.Models.DocumentType", b =>
                {
                    b.Property<int>("DocumentType_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("DocumentType_Description")
                        .HasColumnType("text");

                    b.Property<string>("DocumentType_Title")
                        .HasColumnType("text");

                    b.HasKey("DocumentType_Id");

                    b.ToTable("DocumentType");
                });

            modelBuilder.Entity("FiscusApi.Models.Plz", b =>
                {
                    b.Property<int>("Plz_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Plz_City")
                        .HasColumnType("text");

                    b.Property<string>("Plz_Number")
                        .HasColumnType("text");

                    b.HasKey("Plz_Id");

                    b.ToTable("Plz");
                });

            modelBuilder.Entity("FiscusApi.Models.TaxRate", b =>
                {
                    b.Property<int>("Taxrate_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Taxrate_Description")
                        .HasColumnType("text");

                    b.Property<double>("Taxrate_Percentage")
                        .HasColumnType("double precision");

                    b.HasKey("Taxrate_Id");

                    b.ToTable("TaxRate");
                });

            modelBuilder.Entity("FiscusApi.Models.User", b =>
                {
                    b.Property<int>("User_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("User_DisplayName")
                        .HasColumnType("text");

                    b.Property<string>("User_FirstName")
                        .HasColumnType("text");

                    b.Property<string>("User_IBAN")
                        .HasMaxLength(34)
                        .HasColumnType("character varying(34)");

                    b.Property<string>("User_LastName")
                        .HasColumnType("text");

                    b.Property<string>("User_Mail")
                        .HasColumnType("text");

                    b.Property<string>("User_Password")
                        .HasColumnType("text");

                    b.Property<string>("User_ReferenceNumber")
                        .HasMaxLength(27)
                        .HasColumnType("character varying(27)");

                    b.HasKey("User_Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("FiscusApi.Models.Article", b =>
                {
                    b.HasOne("FiscusApi.Models.TaxRate", null)
                        .WithMany()
                        .HasForeignKey("Article_TaxRate")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FiscusApi.Models.ArticleUnit", null)
                        .WithMany()
                        .HasForeignKey("Article_Unit")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FiscusApi.Models.ArticlePosition", b =>
                {
                    b.HasOne("FiscusApi.Models.Article", null)
                        .WithMany()
                        .HasForeignKey("Article_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FiscusApi.Models.Document", null)
                        .WithMany()
                        .HasForeignKey("Document_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FiscusApi.Models.Customer", b =>
                {
                    b.HasOne("FiscusApi.Models.Plz", null)
                        .WithMany()
                        .HasForeignKey("Customer_PlzId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FiscusApi.Models.Document", b =>
                {
                    b.HasOne("FiscusApi.Models.User", null)
                        .WithMany()
                        .HasForeignKey("Document_CreatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FiscusApi.Models.Customer", null)
                        .WithMany()
                        .HasForeignKey("Document_SendeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FiscusApi.Models.DocumentStatus", null)
                        .WithMany()
                        .HasForeignKey("Document_StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FiscusApi.Models.DocumentType", null)
                        .WithMany()
                        .HasForeignKey("Document_TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
