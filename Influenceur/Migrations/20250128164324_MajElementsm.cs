using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Influenceur.Migrations
{
    /// <inheritdoc />
    public partial class MajElementsm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_identities_Users_UserId",
                table: "identities");

            migrationBuilder.DropForeignKey(
                name: "FK_influenceurs_Users_UserId",
                table: "influenceurs");

            migrationBuilder.DropForeignKey(
                name: "FK_sponsors_Users_UserId",
                table: "sponsors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_sponsors",
                table: "sponsors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_influenceurs",
                table: "influenceurs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_identities",
                table: "identities");

            migrationBuilder.RenameTable(
                name: "sponsors",
                newName: "Sponsors");

            migrationBuilder.RenameTable(
                name: "influenceurs",
                newName: "Influenceurs");

            migrationBuilder.RenameTable(
                name: "identities",
                newName: "Identities");

            migrationBuilder.RenameIndex(
                name: "IX_sponsors_UserId",
                table: "Sponsors",
                newName: "IX_Sponsors_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_influenceurs_UserId",
                table: "Influenceurs",
                newName: "IX_Influenceurs_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_identities_UserId",
                table: "Identities",
                newName: "IX_Identities_UserId");

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
                name: "Email",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Adresse",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Code_postale",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Complement_adresse",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date_naissance",
                table: "Users",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Language",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone_number",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Sexe",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "WebSite",
                table: "Sponsors",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Industry",
                table: "Sponsors",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "Sponsors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Sponsors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "categorie",
                table: "Influenceurs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "SocialMedia",
                table: "Influenceurs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FollowersNumber",
                table: "Influenceurs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<double>(
                name: "EngagementRate",
                table: "Influenceurs",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddColumn<string>(
                name: "Content_style",
                table: "Influenceurs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Contentlanguage",
                table: "Influenceurs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Niches",
                table: "Influenceurs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "IdVersoUrl",
                table: "Identities",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "IdType",
                table: "Identities",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "IdRectoUrl",
                table: "Identities",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "SelfiUrl",
                table: "Identities",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sponsors",
                table: "Sponsors",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Influenceurs",
                table: "Influenceurs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Identities",
                table: "Identities",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "SocialMediaAccounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlatformName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FollowersCount = table.Column<int>(type: "int", nullable: true),
                    ManRate = table.Column<double>(type: "float", nullable: true),
                    FemaleRate = table.Column<double>(type: "float", nullable: true),
                    TopCities = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TopCountries = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AgeRange = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InfluenceurTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialMediaAccounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SocialMediaAccounts_Influenceurs_InfluenceurTypeId",
                        column: x => x.InfluenceurTypeId,
                        principalTable: "Influenceurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SocialMediaAccounts_InfluenceurTypeId",
                table: "SocialMediaAccounts",
                column: "InfluenceurTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Identities_Users_UserId",
                table: "Identities",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Influenceurs_Users_UserId",
                table: "Influenceurs",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Sponsors_Users_UserId",
                table: "Sponsors",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Identities_Users_UserId",
                table: "Identities");

            migrationBuilder.DropForeignKey(
                name: "FK_Influenceurs_Users_UserId",
                table: "Influenceurs");

            migrationBuilder.DropForeignKey(
                name: "FK_Sponsors_Users_UserId",
                table: "Sponsors");

            migrationBuilder.DropTable(
                name: "SocialMediaAccounts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sponsors",
                table: "Sponsors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Influenceurs",
                table: "Influenceurs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Identities",
                table: "Identities");

            migrationBuilder.DropColumn(
                name: "Adresse",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Code_postale",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Complement_adresse",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Date_naissance",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Language",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Phone_number",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Sexe",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Sponsors");

            migrationBuilder.DropColumn(
                name: "Content_style",
                table: "Influenceurs");

            migrationBuilder.DropColumn(
                name: "Contentlanguage",
                table: "Influenceurs");

            migrationBuilder.DropColumn(
                name: "Niches",
                table: "Influenceurs");

            migrationBuilder.DropColumn(
                name: "SelfiUrl",
                table: "Identities");

            migrationBuilder.RenameTable(
                name: "Sponsors",
                newName: "sponsors");

            migrationBuilder.RenameTable(
                name: "Influenceurs",
                newName: "influenceurs");

            migrationBuilder.RenameTable(
                name: "Identities",
                newName: "identities");

            migrationBuilder.RenameIndex(
                name: "IX_Sponsors_UserId",
                table: "sponsors",
                newName: "IX_sponsors_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Influenceurs_UserId",
                table: "influenceurs",
                newName: "IX_influenceurs_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Identities_UserId",
                table: "identities",
                newName: "IX_identities_UserId");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
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

            migrationBuilder.AlterColumn<string>(
                name: "WebSite",
                table: "sponsors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Industry",
                table: "sponsors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "sponsors",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "categorie",
                table: "influenceurs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SocialMedia",
                table: "influenceurs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FollowersNumber",
                table: "influenceurs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "EngagementRate",
                table: "influenceurs",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "IdVersoUrl",
                table: "identities",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "IdType",
                table: "identities",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "IdRectoUrl",
                table: "identities",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_sponsors",
                table: "sponsors",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_influenceurs",
                table: "influenceurs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_identities",
                table: "identities",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_identities_Users_UserId",
                table: "identities",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_influenceurs_Users_UserId",
                table: "influenceurs",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_sponsors_Users_UserId",
                table: "sponsors",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
