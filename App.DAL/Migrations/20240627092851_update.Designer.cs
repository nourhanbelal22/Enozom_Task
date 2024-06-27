﻿// <auto-generated />
using System;
using LibraryDAL.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LibraryDAL.Migrations
{
    [DbContext(typeof(LibraryDbContext))]
    [Migration("20240627092851_update")]
    partial class update
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("LibraryDAL.Entities.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("copyId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Books", (string)null);
                });

            modelBuilder.Entity("LibraryDAL.Entities.BookCopy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<string>("status")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.ToTable("BookCopies", (string)null);
                });

            modelBuilder.Entity("LibraryDAL.Entities.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("phoneNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Students", (string)null);
                });

            modelBuilder.Entity("LibraryDAL.Entities.StudentBookCopy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CopyId")
                        .HasColumnType("int");

                    b.Property<string>("ReturnStatus")
                        .HasColumnType("longtext");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.Property<DateOnly?>("actualReturnDate")
                        .HasColumnType("date");

                    b.Property<DateOnly?>("borrowedDate")
                        .HasColumnType("date");

                    b.Property<DateOnly?>("expectedReturnDate")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.HasIndex("CopyId");

                    b.HasIndex("StudentId");

                    b.ToTable("BorrowRecords", (string)null);
                });

            modelBuilder.Entity("LibraryDAL.Entities.BookCopy", b =>
                {
                    b.HasOne("LibraryDAL.Entities.Book", "book")
                        .WithMany("BookCopies")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("book");
                });

            modelBuilder.Entity("LibraryDAL.Entities.StudentBookCopy", b =>
                {
                    b.HasOne("LibraryDAL.Entities.BookCopy", "bookCopy")
                        .WithMany("studentBookCopies")
                        .HasForeignKey("CopyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LibraryDAL.Entities.Student", "student")
                        .WithMany("BookCopies")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("bookCopy");

                    b.Navigation("student");
                });

            modelBuilder.Entity("LibraryDAL.Entities.Book", b =>
                {
                    b.Navigation("BookCopies");
                });

            modelBuilder.Entity("LibraryDAL.Entities.BookCopy", b =>
                {
                    b.Navigation("studentBookCopies");
                });

            modelBuilder.Entity("LibraryDAL.Entities.Student", b =>
                {
                    b.Navigation("BookCopies");
                });
#pragma warning restore 612, 618
        }
    }
}