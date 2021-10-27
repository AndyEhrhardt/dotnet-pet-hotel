using Microsoft.EntityFrameworkCore.Migrations;

namespace dotnet_bakery.Migrations
{
    public partial class AdjustPetTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ownerEmail",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "ownerName",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "ownerPetCount",
                table: "Pets");

            migrationBuilder.AddColumn<int>(
                name: "ownedByid",
                table: "Pets",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pets_ownedByid",
                table: "Pets",
                column: "ownedByid");

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_PetOwners_ownedByid",
                table: "Pets",
                column: "ownedByid",
                principalTable: "PetOwners",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pets_PetOwners_ownedByid",
                table: "Pets");

            migrationBuilder.DropIndex(
                name: "IX_Pets_ownedByid",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "ownedByid",
                table: "Pets");

            migrationBuilder.AddColumn<string>(
                name: "ownerEmail",
                table: "Pets",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ownerName",
                table: "Pets",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ownerPetCount",
                table: "Pets",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
