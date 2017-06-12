using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlinePizzaWebApplication.Migrations
{
    public partial class OrdersPizzaId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Pizzas_PizzaId",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "PieId",
                table: "OrderDetails");

            migrationBuilder.AlterColumn<int>(
                name: "PizzaId",
                table: "OrderDetails",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Pizzas_PizzaId",
                table: "OrderDetails",
                column: "PizzaId",
                principalTable: "Pizzas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Pizzas_PizzaId",
                table: "OrderDetails");

            migrationBuilder.AlterColumn<int>(
                name: "PizzaId",
                table: "OrderDetails",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "PieId",
                table: "OrderDetails",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Pizzas_PizzaId",
                table: "OrderDetails",
                column: "PizzaId",
                principalTable: "Pizzas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
