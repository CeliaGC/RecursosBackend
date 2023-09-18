using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class TableNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rols_Authorizations_Authorizations_IdAuthorization",
                table: "Rols_Authorizations");

            migrationBuilder.DropForeignKey(
                name: "FK_Rols_Authorizations_UserRols_IdRol",
                table: "Rols_Authorizations");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserRols_IdRol",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserRols",
                table: "UserRols");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rols_Authorizations",
                table: "Rols_Authorizations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Authorizations",
                table: "Authorizations");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "t_users");

            migrationBuilder.RenameTable(
                name: "UserRols",
                newName: "t_user_rols");

            migrationBuilder.RenameTable(
                name: "Rols_Authorizations",
                newName: "t_rols_authorizations");

            migrationBuilder.RenameTable(
                name: "Authorizations",
                newName: "t_endpoint_authorizations");

            migrationBuilder.RenameIndex(
                name: "IX_Users_IdRol",
                table: "t_users",
                newName: "IX_t_users_IdRol");

            migrationBuilder.RenameIndex(
                name: "IX_Rols_Authorizations_IdRol",
                table: "t_rols_authorizations",
                newName: "IX_t_rols_authorizations_IdRol");

            migrationBuilder.RenameIndex(
                name: "IX_Rols_Authorizations_IdAuthorization",
                table: "t_rols_authorizations",
                newName: "IX_t_rols_authorizations_IdAuthorization");

            migrationBuilder.AddPrimaryKey(
                name: "PK_t_users",
                table: "t_users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_t_user_rols",
                table: "t_user_rols",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_t_rols_authorizations",
                table: "t_rols_authorizations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_t_endpoint_authorizations",
                table: "t_endpoint_authorizations",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_t_rols_authorizations_t_endpoint_authorizations_IdAuthorization",
                table: "t_rols_authorizations",
                column: "IdAuthorization",
                principalTable: "t_endpoint_authorizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_t_rols_authorizations_t_user_rols_IdRol",
                table: "t_rols_authorizations",
                column: "IdRol",
                principalTable: "t_user_rols",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_t_users_t_user_rols_IdRol",
                table: "t_users",
                column: "IdRol",
                principalTable: "t_user_rols",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_t_rols_authorizations_t_endpoint_authorizations_IdAuthorization",
                table: "t_rols_authorizations");

            migrationBuilder.DropForeignKey(
                name: "FK_t_rols_authorizations_t_user_rols_IdRol",
                table: "t_rols_authorizations");

            migrationBuilder.DropForeignKey(
                name: "FK_t_users_t_user_rols_IdRol",
                table: "t_users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_t_users",
                table: "t_users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_t_user_rols",
                table: "t_user_rols");

            migrationBuilder.DropPrimaryKey(
                name: "PK_t_rols_authorizations",
                table: "t_rols_authorizations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_t_endpoint_authorizations",
                table: "t_endpoint_authorizations");

            migrationBuilder.RenameTable(
                name: "t_users",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "t_user_rols",
                newName: "UserRols");

            migrationBuilder.RenameTable(
                name: "t_rols_authorizations",
                newName: "Rols_Authorizations");

            migrationBuilder.RenameTable(
                name: "t_endpoint_authorizations",
                newName: "Authorizations");

            migrationBuilder.RenameIndex(
                name: "IX_t_users_IdRol",
                table: "Users",
                newName: "IX_Users_IdRol");

            migrationBuilder.RenameIndex(
                name: "IX_t_rols_authorizations_IdRol",
                table: "Rols_Authorizations",
                newName: "IX_Rols_Authorizations_IdRol");

            migrationBuilder.RenameIndex(
                name: "IX_t_rols_authorizations_IdAuthorization",
                table: "Rols_Authorizations",
                newName: "IX_Rols_Authorizations_IdAuthorization");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserRols",
                table: "UserRols",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rols_Authorizations",
                table: "Rols_Authorizations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Authorizations",
                table: "Authorizations",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Rols_Authorizations_Authorizations_IdAuthorization",
                table: "Rols_Authorizations",
                column: "IdAuthorization",
                principalTable: "Authorizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rols_Authorizations_UserRols_IdRol",
                table: "Rols_Authorizations",
                column: "IdRol",
                principalTable: "UserRols",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserRols_IdRol",
                table: "Users",
                column: "IdRol",
                principalTable: "UserRols",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
