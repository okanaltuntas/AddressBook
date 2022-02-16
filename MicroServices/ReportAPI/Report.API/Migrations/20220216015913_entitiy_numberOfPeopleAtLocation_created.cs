using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Report.API.Migrations
{
    public partial class entitiy_numberOfPeopleAtLocation_created : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.CreateTable(
                name: "NumbersOfAtLocation",
                columns: table => new
                {
                    UUID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LocationName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberCount = table.Column<int>(type: "int", nullable: false),
                    ContactCount = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NumbersOfAtLocation", x => x.UUID);
                });
 
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContactInformation");

            migrationBuilder.DropTable(
                name: "NumbersOfAtLocation");

            migrationBuilder.DropTable(
                name: "Contact");
        }
    }
}
