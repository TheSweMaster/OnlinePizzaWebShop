using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using OnlinePizzaWebApplication.Data;
using OnlinePizzaWebApplication.Models;

namespace OnlinePizzaWebApplication.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20170605213119_PizzaPriceTypeFix")]
    partial class PizzaPriceTypeFix
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("OnlinePizzaWebApplication.Models.Pizza", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Image");

                    b.Property<bool>("IsPizzaOfTheWeek");

                    b.Property<string>("Name");

                    b.Property<decimal>("Price");

                    b.HasKey("Id");

                    b.ToTable("Pizzas");
                });
        }
    }
}
