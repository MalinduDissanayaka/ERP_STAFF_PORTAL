using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.ResultManagement.DataServices.Migrations
{
    /// <inheritdoc />
    public partial class biuiuiubiubub : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ComResults",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ComId = table.Column<int>(type: "INTEGER", nullable: false),
                    StudentName = table.Column<string>(type: "TEXT", nullable: false),
                    CE0001 = table.Column<string>(type: "TEXT", nullable: true),
                    CE0002 = table.Column<string>(type: "TEXT", nullable: true),
                    CE0003 = table.Column<string>(type: "TEXT", nullable: true),
                    CE0004 = table.Column<string>(type: "TEXT", nullable: true),
                    CE0005 = table.Column<string>(type: "TEXT", nullable: true),
                    CE0006 = table.Column<string>(type: "TEXT", nullable: true),
                    CE0007 = table.Column<string>(type: "TEXT", nullable: true),
                    CE0008 = table.Column<string>(type: "TEXT", nullable: true),
                    CE0009 = table.Column<string>(type: "TEXT", nullable: true),
                    CE0010 = table.Column<string>(type: "TEXT", nullable: true),
                    CE0011 = table.Column<string>(type: "TEXT", nullable: true),
                    CE0012 = table.Column<string>(type: "TEXT", nullable: true),
                    AddedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComResults", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeieResults",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    DEIEid = table.Column<int>(type: "INTEGER", nullable: false),
                    StudentName = table.Column<string>(type: "TEXT", nullable: false),
                    EE0001 = table.Column<string>(type: "TEXT", nullable: true),
                    EE0002 = table.Column<string>(type: "TEXT", nullable: true),
                    EE0003 = table.Column<string>(type: "TEXT", nullable: true),
                    EE0004 = table.Column<string>(type: "TEXT", nullable: true),
                    EE0005 = table.Column<string>(type: "TEXT", nullable: true),
                    EE0006 = table.Column<string>(type: "TEXT", nullable: true),
                    EE0007 = table.Column<string>(type: "TEXT", nullable: true),
                    EE0008 = table.Column<string>(type: "TEXT", nullable: true),
                    EE0009 = table.Column<string>(type: "TEXT", nullable: true),
                    EE0010 = table.Column<string>(type: "TEXT", nullable: true),
                    EE0011 = table.Column<string>(type: "TEXT", nullable: true),
                    EE0012 = table.Column<string>(type: "TEXT", nullable: true),
                    AddedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeieResults", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComResults");

            migrationBuilder.DropTable(
                name: "DeieResults");
        }
    }
}
