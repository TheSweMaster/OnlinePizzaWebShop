using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlinePizzaWebApplication.Migrations
{
    public partial class Added_PizzaIngredients_Categories_Reviews2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pizzas_Categories_CategoryId",
                table: "Pizzas");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Pizzas",
                newName: "CategoriesId");

            migrationBuilder.RenameIndex(
                name: "IX_Pizzas_CategoryId",
                table: "Pizzas",
                newName: "IX_Pizzas_CategoriesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pizzas_Categories_CategoriesId",
                table: "Pizzas",
                column: "CategoriesId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pizzas_Categories_CategoriesId",
                table: "Pizzas");

            migrationBuilder.RenameColumn(
                name: "CategoriesId",
                table: "Pizzas",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Pizzas_CategoriesId",
                table: "Pizzas",
                newName: "IX_Pizzas_CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pizzas_Categories_CategoryId",
                table: "Pizzas",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
