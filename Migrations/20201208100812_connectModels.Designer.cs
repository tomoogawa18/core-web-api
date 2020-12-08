﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace SampleMVCApp.Migrations
{
    [DbContext(typeof(SampleMVCAppContext))]
    [Migration("20201208100812_connectModels")]
    partial class connectModels
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("SampleMVCApp.Models.Person", b =>
                {
                    b.Property<int>("PersonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Mail")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("PersonId");

                    b.ToTable("Person");
                });

            modelBuilder.Entity("SampleMVCApp.Models.Post", b =>
                {
                    b.Property<int>("PostId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .HasColumnType("text");

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.Property<int?>("PersonKey")
                        .HasColumnType("int");

                    b.Property<string>("Subject")
                        .HasColumnType("text");

                    b.HasKey("PostId");

                    b.HasIndex("PersonKey");

                    b.ToTable("Post");
                });

            modelBuilder.Entity("SampleMVCApp.Models.Post", b =>
                {
                    b.HasOne("SampleMVCApp.Models.Person", "Person")
                        .WithMany("Posts")
                        .HasForeignKey("PersonKey");
                });
#pragma warning restore 612, 618
        }
    }
}