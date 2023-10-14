using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DotnetAngular.Data.Migrations
{
    /// <inheritdoc />
    public partial class Createpost : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var createpost = @"CREATE PROCEDURE CreatePost 
	                    @Title nvarchar(max), @Createdat datetime, @Content nvarchar(max),
	                    @Imageurl nvarchar(max), @PostTypeId int
                    AS
                    BEGIN
	                    SET NOCOUNT ON;
	                    insert into Posts (Title,Createdat, Content ,
	                    Imageurl , PostTypeId) values (@Title,@Createdat,@Content,@Imageurl,@PostTypeId)
                    END
                    GO";
            migrationBuilder.Sql(createpost);
            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "Createdat",
                value: new DateTime(2023, 10, 14, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "Createdat",
                value: new DateTime(2023, 10, 14, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                column: "Createdat",
                value: new DateTime(2023, 10, 14, 10, 2, 10, 349, DateTimeKind.Local).AddTicks(1953));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2,
                column: "Createdat",
                value: new DateTime(2023, 10, 14, 10, 2, 10, 349, DateTimeKind.Local).AddTicks(1966));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3,
                column: "Createdat",
                value: new DateTime(2023, 10, 14, 10, 2, 10, 349, DateTimeKind.Local).AddTicks(1967));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 4,
                column: "Createdat",
                value: new DateTime(2023, 10, 14, 10, 2, 10, 349, DateTimeKind.Local).AddTicks(1968));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 5,
                column: "Createdat",
                value: new DateTime(2023, 10, 14, 10, 2, 10, 349, DateTimeKind.Local).AddTicks(1969));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "Createdat",
                value: new DateTime(2023, 10, 9, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "Createdat",
                value: new DateTime(2023, 10, 9, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                column: "Createdat",
                value: new DateTime(2023, 10, 9, 14, 57, 26, 911, DateTimeKind.Local).AddTicks(7192));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2,
                column: "Createdat",
                value: new DateTime(2023, 10, 9, 14, 57, 26, 911, DateTimeKind.Local).AddTicks(7203));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3,
                column: "Createdat",
                value: new DateTime(2023, 10, 9, 14, 57, 26, 911, DateTimeKind.Local).AddTicks(7204));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 4,
                column: "Createdat",
                value: new DateTime(2023, 10, 9, 14, 57, 26, 911, DateTimeKind.Local).AddTicks(7205));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 5,
                column: "Createdat",
                value: new DateTime(2023, 10, 9, 14, 57, 26, 911, DateTimeKind.Local).AddTicks(7206));
        }
    }
}
