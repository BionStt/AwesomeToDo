﻿// <auto-generated />
using System;
using AwesomeToDo.Domain.Data.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AwesomeToDo.Domain.Migrations
{
    [DbContext(typeof(EfContext))]
    [Migration("20180628194146_RemovedContentFromMigration")]
    partial class RemovedContentFromMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.0-rtm-30799")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            modelBuilder.Entity("AwesomeToDo.Domain.Entities.Card", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreationDateTime");

                    b.Property<string>("Title")
                        .HasMaxLength(30);

                    b.Property<Guid?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Cards");
                });

            modelBuilder.Entity("AwesomeToDo.Domain.Entities.ToDo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("CardId");

                    b.Property<DateTime>("CreationDateTime");

                    b.Property<DateTime>("LastModified");

                    b.Property<int>("Status");

                    b.Property<string>("Title")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.HasIndex("CardId");

                    b.ToTable("ToDos");
                });

            modelBuilder.Entity("AwesomeToDo.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatationDateTime");

                    b.Property<string>("Email")
                        .HasMaxLength(30);

                    b.Property<string>("FirstName")
                        .HasMaxLength(30);

                    b.Property<string>("LastName")
                        .HasMaxLength(30);

                    b.Property<string>("Password");

                    b.Property<string>("Salt");

                    b.HasKey("Id");

                    b.HasIndex("Email");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("AwesomeToDo.Domain.Entities.Card", b =>
                {
                    b.HasOne("AwesomeToDo.Domain.Entities.User", "User")
                        .WithMany("Cards")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AwesomeToDo.Domain.Entities.ToDo", b =>
                {
                    b.HasOne("AwesomeToDo.Domain.Entities.Card", "Card")
                        .WithMany("ToDos")
                        .HasForeignKey("CardId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
