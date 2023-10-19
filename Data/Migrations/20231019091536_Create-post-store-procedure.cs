using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DotnetAngular.Data.Migrations
{
    /// <inheritdoc />
    public partial class Createpoststoreprocedure : Migration
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
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                column: "Createdat",
                value: new DateTime(2023, 10, 19, 16, 15, 36, 811, DateTimeKind.Local).AddTicks(2870));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2,
                column: "Createdat",
                value: new DateTime(2023, 10, 19, 16, 15, 36, 811, DateTimeKind.Local).AddTicks(2884));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3,
                column: "Createdat",
                value: new DateTime(2023, 10, 19, 16, 15, 36, 811, DateTimeKind.Local).AddTicks(2885));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 4,
                column: "Createdat",
                value: new DateTime(2023, 10, 19, 16, 15, 36, 811, DateTimeKind.Local).AddTicks(2886));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 5,
                column: "Createdat",
                value: new DateTime(2023, 10, 19, 16, 15, 36, 811, DateTimeKind.Local).AddTicks(2887));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 1,
                column: "Createdat",
                value: new DateTime(2023, 10, 19, 10, 3, 38, 251, DateTimeKind.Local).AddTicks(356));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 2,
                column: "Createdat",
                value: new DateTime(2023, 10, 19, 10, 3, 38, 251, DateTimeKind.Local).AddTicks(367));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 3,
                column: "Createdat",
                value: new DateTime(2023, 10, 19, 10, 3, 38, 251, DateTimeKind.Local).AddTicks(368));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 4,
                column: "Createdat",
                value: new DateTime(2023, 10, 19, 10, 3, 38, 251, DateTimeKind.Local).AddTicks(369));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 5,
                column: "Createdat",
                value: new DateTime(2023, 10, 19, 10, 3, 38, 251, DateTimeKind.Local).AddTicks(370));
        }
    }
}
