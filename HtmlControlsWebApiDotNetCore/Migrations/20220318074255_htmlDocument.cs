using Microsoft.EntityFrameworkCore.Migrations;

namespace HtmlControlsWebApiDotNetCore.Migrations
{
    public partial class htmlDocument : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HtmlDocuments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HtmlDocuments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HtmlDocuments_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HtmlControl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ElementId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ElementType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ElementOrder = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HtmlText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Width = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Height = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MarginLeft = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MarginTop = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MarginRight = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MarginBottom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Align = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BackgroundColor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ButtonType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FontSize = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FontColor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ButtonColor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HtmlDocumentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HtmlControl", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HtmlControl_HtmlDocuments_HtmlDocumentId",
                        column: x => x.HtmlDocumentId,
                        principalTable: "HtmlDocuments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HtmlControl_HtmlDocumentId",
                table: "HtmlControl",
                column: "HtmlDocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_HtmlDocuments_UserId",
                table: "HtmlDocuments",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HtmlControl");

            migrationBuilder.DropTable(
                name: "HtmlDocuments");
        }
    }
}
