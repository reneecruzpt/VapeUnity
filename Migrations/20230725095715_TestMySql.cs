using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VapeUnity.Migrations
{
    /// <inheritdoc />
    public partial class TestMySql : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_Usuarios_UserId",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_Usuarios_UserId",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_Usuarios_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_Usuarios_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserTokens",
                table: "AspNetUserTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserRoles",
                table: "AspNetUserRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserLogins",
                table: "AspNetUserLogins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserClaims",
                table: "AspNetUserClaims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetRoleClaims",
                table: "AspNetRoleClaims");

            migrationBuilder.DropColumn(
                name: "TokenEmail",
                table: "Usuarios");

            migrationBuilder.RenameTable(
                name: "AspNetUserTokens",
                newName: "TokensUsuarios");

            migrationBuilder.RenameTable(
                name: "AspNetUserRoles",
                newName: "UsuariosFuncoes");

            migrationBuilder.RenameTable(
                name: "AspNetUserLogins",
                newName: "LoginsUsuarios");

            migrationBuilder.RenameTable(
                name: "AspNetUserClaims",
                newName: "ReivindicacoesUsuarios");

            migrationBuilder.RenameTable(
                name: "AspNetRoleClaims",
                newName: "ReivindicacoesFuncoes");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "UsuariosFuncoes",
                newName: "IX_UsuariosFuncoes_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "LoginsUsuarios",
                newName: "IX_LoginsUsuarios_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "ReivindicacoesUsuarios",
                newName: "IX_ReivindicacoesUsuarios_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "ReivindicacoesFuncoes",
                newName: "IX_ReivindicacoesFuncoes_RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TokensUsuarios",
                table: "TokensUsuarios",
                columns: new[] { "UserId", "LoginProvider", "Name" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsuariosFuncoes",
                table: "UsuariosFuncoes",
                columns: new[] { "UserId", "RoleId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_LoginsUsuarios",
                table: "LoginsUsuarios",
                columns: new[] { "LoginProvider", "ProviderKey" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReivindicacoesUsuarios",
                table: "ReivindicacoesUsuarios",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReivindicacoesFuncoes",
                table: "ReivindicacoesFuncoes",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Funcoes",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Funcoes_AspNetRoles_Id",
                        column: x => x.Id,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddForeignKey(
                name: "FK_LoginsUsuarios_Usuarios_UserId",
                table: "LoginsUsuarios",
                column: "UserId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReivindicacoesFuncoes_AspNetRoles_RoleId",
                table: "ReivindicacoesFuncoes",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReivindicacoesUsuarios_Usuarios_UserId",
                table: "ReivindicacoesUsuarios",
                column: "UserId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TokensUsuarios_Usuarios_UserId",
                table: "TokensUsuarios",
                column: "UserId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsuariosFuncoes_AspNetRoles_RoleId",
                table: "UsuariosFuncoes",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsuariosFuncoes_Usuarios_UserId",
                table: "UsuariosFuncoes",
                column: "UserId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoginsUsuarios_Usuarios_UserId",
                table: "LoginsUsuarios");

            migrationBuilder.DropForeignKey(
                name: "FK_ReivindicacoesFuncoes_AspNetRoles_RoleId",
                table: "ReivindicacoesFuncoes");

            migrationBuilder.DropForeignKey(
                name: "FK_ReivindicacoesUsuarios_Usuarios_UserId",
                table: "ReivindicacoesUsuarios");

            migrationBuilder.DropForeignKey(
                name: "FK_TokensUsuarios_Usuarios_UserId",
                table: "TokensUsuarios");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuariosFuncoes_AspNetRoles_RoleId",
                table: "UsuariosFuncoes");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuariosFuncoes_Usuarios_UserId",
                table: "UsuariosFuncoes");

            migrationBuilder.DropTable(
                name: "Funcoes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsuariosFuncoes",
                table: "UsuariosFuncoes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TokensUsuarios",
                table: "TokensUsuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReivindicacoesUsuarios",
                table: "ReivindicacoesUsuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReivindicacoesFuncoes",
                table: "ReivindicacoesFuncoes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LoginsUsuarios",
                table: "LoginsUsuarios");

            migrationBuilder.RenameTable(
                name: "UsuariosFuncoes",
                newName: "AspNetUserRoles");

            migrationBuilder.RenameTable(
                name: "TokensUsuarios",
                newName: "AspNetUserTokens");

            migrationBuilder.RenameTable(
                name: "ReivindicacoesUsuarios",
                newName: "AspNetUserClaims");

            migrationBuilder.RenameTable(
                name: "ReivindicacoesFuncoes",
                newName: "AspNetRoleClaims");

            migrationBuilder.RenameTable(
                name: "LoginsUsuarios",
                newName: "AspNetUserLogins");

            migrationBuilder.RenameIndex(
                name: "IX_UsuariosFuncoes_RoleId",
                table: "AspNetUserRoles",
                newName: "IX_AspNetUserRoles_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_ReivindicacoesUsuarios_UserId",
                table: "AspNetUserClaims",
                newName: "IX_AspNetUserClaims_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_ReivindicacoesFuncoes_RoleId",
                table: "AspNetRoleClaims",
                newName: "IX_AspNetRoleClaims_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_LoginsUsuarios_UserId",
                table: "AspNetUserLogins",
                newName: "IX_AspNetUserLogins_UserId");

            migrationBuilder.AddColumn<string>(
                name: "TokenEmail",
                table: "Usuarios",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserRoles",
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserTokens",
                table: "AspNetUserTokens",
                columns: new[] { "UserId", "LoginProvider", "Name" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserClaims",
                table: "AspNetUserClaims",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetRoleClaims",
                table: "AspNetRoleClaims",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserLogins",
                table: "AspNetUserLogins",
                columns: new[] { "LoginProvider", "ProviderKey" });

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_Usuarios_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_Usuarios_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_Usuarios_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_Usuarios_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
