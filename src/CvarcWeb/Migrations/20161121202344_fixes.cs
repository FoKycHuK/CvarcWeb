using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CvarcWeb.Migrations
{
    public partial class fixes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommandGameResults_Commands_CommandId",
                table: "CommandGameResults");

            migrationBuilder.DropForeignKey(
                name: "FK_CommandGameResults_Games_GameId",
                table: "CommandGameResults");

            migrationBuilder.DropForeignKey(
                name: "FK_Results_CommandGameResults_CommandGameResultId",
                table: "Results");

            migrationBuilder.AlterColumn<int>(
                name: "CommandGameResultId",
                table: "Results",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "GameId",
                table: "CommandGameResults",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CommandId",
                table: "CommandGameResults",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CommandGameResults_Commands_CommandId",
                table: "CommandGameResults",
                column: "CommandId",
                principalTable: "Commands",
                principalColumn: "CommandId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CommandGameResults_Games_GameId",
                table: "CommandGameResults",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "GameId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Results_CommandGameResults_CommandGameResultId",
                table: "Results",
                column: "CommandGameResultId",
                principalTable: "CommandGameResults",
                principalColumn: "CommandGameResultId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommandGameResults_Commands_CommandId",
                table: "CommandGameResults");

            migrationBuilder.DropForeignKey(
                name: "FK_CommandGameResults_Games_GameId",
                table: "CommandGameResults");

            migrationBuilder.DropForeignKey(
                name: "FK_Results_CommandGameResults_CommandGameResultId",
                table: "Results");

            migrationBuilder.AlterColumn<int>(
                name: "CommandGameResultId",
                table: "Results",
                nullable: false);

            migrationBuilder.AlterColumn<int>(
                name: "GameId",
                table: "CommandGameResults",
                nullable: false);

            migrationBuilder.AlterColumn<int>(
                name: "CommandId",
                table: "CommandGameResults",
                nullable: false);

            migrationBuilder.AddForeignKey(
                name: "FK_CommandGameResults_Commands_CommandId",
                table: "CommandGameResults",
                column: "CommandId",
                principalTable: "Commands",
                principalColumn: "CommandId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CommandGameResults_Games_GameId",
                table: "CommandGameResults",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "GameId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Results_CommandGameResults_CommandGameResultId",
                table: "Results",
                column: "CommandGameResultId",
                principalTable: "CommandGameResults",
                principalColumn: "CommandGameResultId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
