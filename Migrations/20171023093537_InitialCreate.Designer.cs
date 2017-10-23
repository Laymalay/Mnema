﻿// <auto-generated />
using AuthApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace Mnema.Migrations
{
    [DbContext(typeof(UserContext))]
    [Migration("20171023093537_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Mnema.Models.Comment", b =>
                {
                    b.Property<int>("CommentId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("PhotoId");

                    b.Property<int?>("UserId");

                    b.HasKey("CommentId");

                    b.HasIndex("PhotoId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("Mnema.Models.Like", b =>
                {
                    b.Property<int>("LikeId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("PhotoId");

                    b.Property<int?>("UserId");

                    b.HasKey("LikeId");

                    b.HasIndex("PhotoId");

                    b.HasIndex("UserId");

                    b.ToTable("Likes");
                });

            modelBuilder.Entity("Mnema.Models.Photo", b =>
                {
                    b.Property<int>("PhotoId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<string>("Path");

                    b.Property<int>("UserId");

                    b.HasKey("PhotoId");

                    b.HasIndex("UserId");

                    b.ToTable("Photos");
                });

            modelBuilder.Entity("Mnema.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<byte[]>("Avatar");

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.Property<string>("Password");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Mnema.Models.Comment", b =>
                {
                    b.HasOne("Mnema.Models.Photo", "Photo")
                        .WithMany("Comments")
                        .HasForeignKey("PhotoId");

                    b.HasOne("Mnema.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Mnema.Models.Like", b =>
                {
                    b.HasOne("Mnema.Models.Photo", "Photo")
                        .WithMany("Likes")
                        .HasForeignKey("PhotoId");

                    b.HasOne("Mnema.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Mnema.Models.Photo", b =>
                {
                    b.HasOne("Mnema.Models.User", "User")
                        .WithMany("Photos")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
