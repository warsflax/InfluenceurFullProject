using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Influenceur.Migrations
{
    /// <inheritdoc />
    public partial class RemoveInfluenceurType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SocialMediaAccounts_Influenceurs_InfluenceurTypeId",
                table: "SocialMediaAccounts");

            migrationBuilder.DropTable(
                name: "Influenceurs");

            migrationBuilder.RenameColumn(
                name: "InfluenceurTypeId",
                table: "SocialMediaAccounts",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_SocialMediaAccounts_InfluenceurTypeId",
                table: "SocialMediaAccounts",
                newName: "IX_SocialMediaAccounts_UserId");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Langue",
                table: "SocialMediaAccounts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Niches",
                table: "SocialMediaAccounts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SocialMediaAccounts_Users_UserId",
                table: "SocialMediaAccounts",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SocialMediaAccounts_Users_UserId",
                table: "SocialMediaAccounts");

            migrationBuilder.DropColumn(
                name: "Langue",
                table: "SocialMediaAccounts");

            migrationBuilder.DropColumn(
                name: "Niches",
                table: "SocialMediaAccounts");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "SocialMediaAccounts",
                newName: "InfluenceurTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_SocialMediaAccounts_UserId",
                table: "SocialMediaAccounts",
                newName: "IX_SocialMediaAccounts_InfluenceurTypeId");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "Influenceurs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    Content_style = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contentlanguage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EngagementRate = table.Column<double>(type: "float", nullable: true),
                    FollowersNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Niches = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SocialMedia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    categorie = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Influenceurs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Influenceurs_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Influenceurs_UserId",
                table: "Influenceurs",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_SocialMediaAccounts_Influenceurs_InfluenceurTypeId",
                table: "SocialMediaAccounts",
                column: "InfluenceurTypeId",
                principalTable: "Influenceurs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
