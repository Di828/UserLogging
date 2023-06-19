using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserLogging.Migrations
{
    /// <inheritdoc />
    public partial class UserActions2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PossibleAction_Users_UserId",
                table: "PossibleAction");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PossibleAction",
                table: "PossibleAction");

            migrationBuilder.RenameTable(
                name: "PossibleAction",
                newName: "UserActions");

            migrationBuilder.RenameIndex(
                name: "IX_PossibleAction_UserId",
                table: "UserActions",
                newName: "IX_UserActions_UserId");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "UserActions",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserActions",
                table: "UserActions",
                column: "PossibleActionId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserActions_Users_UserId",
                table: "UserActions",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserActions_Users_UserId",
                table: "UserActions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserActions",
                table: "UserActions");

            migrationBuilder.RenameTable(
                name: "UserActions",
                newName: "PossibleAction");

            migrationBuilder.RenameIndex(
                name: "IX_UserActions_UserId",
                table: "PossibleAction",
                newName: "IX_PossibleAction_UserId");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "PossibleAction",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PossibleAction",
                table: "PossibleAction",
                column: "PossibleActionId");

            migrationBuilder.AddForeignKey(
                name: "FK_PossibleAction_Users_UserId",
                table: "PossibleAction",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId");
        }
    }
}
