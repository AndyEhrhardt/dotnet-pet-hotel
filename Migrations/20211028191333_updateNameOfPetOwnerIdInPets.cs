using Microsoft.EntityFrameworkCore.Migrations;

namespace dotnet_bakery.Migrations
{
    public partial class updateNameOfPetOwnerIdInPets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pets_PetOwners_PetOwners",
                table: "Pets");

            migrationBuilder.RenameColumn(
                name: "PetOwners",
                table: "Pets",
                newName: "petOwnerid");

            migrationBuilder.RenameIndex(
                name: "IX_Pets_PetOwners",
                table: "Pets",
                newName: "IX_Pets_petOwnerid");

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_PetOwners_petOwnerid",
                table: "Pets",
                column: "petOwnerid",
                principalTable: "PetOwners",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pets_PetOwners_petOwnerid",
                table: "Pets");

            migrationBuilder.RenameColumn(
                name: "petOwnerid",
                table: "Pets",
                newName: "PetOwners");

            migrationBuilder.RenameIndex(
                name: "IX_Pets_petOwnerid",
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
    }
}
