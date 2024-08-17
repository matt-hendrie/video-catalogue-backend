using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VideoCatalogue.EfCore.Migrations
{
    /// <inheritdoc />
    public partial class new_video_elements : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Channels");

            migrationBuilder.AlterColumn<float>(
                name: "Runtime",
                table: "VideoData",
                type: "REAL",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddColumn<DateTime>(
                name: "UploadDate",
                table: "VideoData",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Tag",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    VideoId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tag_VideoData_VideoId",
                        column: x => x.VideoId,
                        principalTable: "VideoData",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tag_VideoId",
                table: "Tag",
                column: "VideoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tag");

            migrationBuilder.DropColumn(
                name: "UploadDate",
                table: "VideoData");

            migrationBuilder.AlterColumn<string>(
                name: "Runtime",
                table: "VideoData",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(float),
                oldType: "REAL",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Channels",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
