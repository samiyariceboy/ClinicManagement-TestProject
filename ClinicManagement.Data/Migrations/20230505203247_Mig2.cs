using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicManagement.Data.Migrations
{
    /// <inheritdoc />
    public partial class Mig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "AppointmentAggregateRoots",
                newName: "PatientUserId");

            migrationBuilder.CreateTable(
                name: "ClinicAggregateRoots",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    ClinicName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfEstablishment = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClinicAddress = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClinicAggregateRoots", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentAggregateRoots_PatientUserId",
                table: "AppointmentAggregateRoots",
                column: "PatientUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppointmentAggregateRoots_AspNetUsers_PatientUserId",
                table: "AppointmentAggregateRoots",
                column: "PatientUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppointmentAggregateRoots_AspNetUsers_PatientUserId",
                table: "AppointmentAggregateRoots");

            migrationBuilder.DropTable(
                name: "ClinicAggregateRoots");

            migrationBuilder.DropIndex(
                name: "IX_AppointmentAggregateRoots_PatientUserId",
                table: "AppointmentAggregateRoots");

            migrationBuilder.RenameColumn(
                name: "PatientUserId",
                table: "AppointmentAggregateRoots",
                newName: "UserId");
        }
    }
}
