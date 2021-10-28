using Microsoft.EntityFrameworkCore.Migrations;

namespace dotnet_bakery.Migrations
{
    public partial class alterPetOwnersTable1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pets_PetOwners_ownedByid",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "ownerId",
                table: "Pets");

            migrationBuilder.RenameColumn(
                name: "ownedByid",
                table: "Pets",
                newName: "PetOwners");

            migrationBuilder.RenameIndex(
                name: "IX_Pets_ownedByid",
                table: "Pets",
                newName: "IX_Pets_PetOwners");

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_PetOwners_PetOwners",
                table: "Pets",
                column: "PetOwners",
                principalTable: "PetOwners",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pets_PetOwners_PetOwners",
                table: "Pets");

            migrationBuilder.RenameColumn(
                name: "PetOwners",
                table: "Pets",
                newName: "ownedByid");

            migrationBuilder.RenameIndex(
                name: "IX_Pets_PetOwners",
                table: "Pets",
                newName: "IX_Pets_ownedByid");

            migrationBuilder.AddColumn<int>(
                name: "ownerId",
                table: "Pets",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_PetOwners_ownedByid",
                table: "Pets",
                column: "ownedByid",
                principalTable: "PetOwners",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
