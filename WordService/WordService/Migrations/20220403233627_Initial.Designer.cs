﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WordService.DBContexts;

#nullable disable

namespace WordService.Migrations
{
    [DbContext(typeof(WordContext))]
    [Migration("20220403233627_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("WordService.Model.SingleWord", b =>
                {
                    b.Property<string>("Word")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.HasKey("Word");

                    b.ToTable("SingleWords");

                    b.HasData(
                        new
                        {
                            Word = "hello",
                            Count = 0
                        },
                        new
                        {
                            Word = "goodbye",
                            Count = 0
                        },
                        new
                        {
                            Word = "simple",
                            Count = 0
                        },
                        new
                        {
                            Word = "list",
                            Count = 0
                        },
                        new
                        {
                            Word = "search",
                            Count = 0
                        },
                        new
                        {
                            Word = "filter",
                            Count = 0
                        },
                        new
                        {
                            Word = "yes",
                            Count = 0
                        },
                        new
                        {
                            Word = "no",
                            Count = 0
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
