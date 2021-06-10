using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Leave_Management.Data.Migrations
{
    public partial class AdjustAllocationsAndTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LeaveHisttories_AspNetUsers_ApprovedById",
                table: "LeaveHisttories");

            migrationBuilder.DropForeignKey(
                name: "FK_LeaveHisttories_AspNetUsers_RequestingEmployeeId",
                table: "LeaveHisttories");

            migrationBuilder.DropForeignKey(
                name: "FK_LeaveHisttories_LeaveTypes_LeaveTypeId",
                table: "LeaveHisttories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LeaveHisttories",
                table: "LeaveHisttories");

            migrationBuilder.RenameTable(
                name: "LeaveHisttories",
                newName: "LeaveHistories");

            migrationBuilder.RenameIndex(
                name: "IX_LeaveHisttories_RequestingEmployeeId",
                table: "LeaveHistories",
                newName: "IX_LeaveHistories_RequestingEmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_LeaveHisttories_LeaveTypeId",
                table: "LeaveHistories",
                newName: "IX_LeaveHistories_LeaveTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_LeaveHisttories_ApprovedById",
                table: "LeaveHistories",
                newName: "IX_LeaveHistories_ApprovedById");

            migrationBuilder.AddColumn<int>(
                name: "DefaultDays",
                table: "LeaveTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Period",
                table: "LeaveAllocations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_LeaveHistories",
                table: "LeaveHistories",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "DetailsLeaveTypeViewModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetailsLeaveTypeViewModel", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_LeaveHistories_AspNetUsers_ApprovedById",
                table: "LeaveHistories",
                column: "ApprovedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LeaveHistories_AspNetUsers_RequestingEmployeeId",
                table: "LeaveHistories",
                column: "RequestingEmployeeId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LeaveHistories_LeaveTypes_LeaveTypeId",
                table: "LeaveHistories",
                column: "LeaveTypeId",
                principalTable: "LeaveTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LeaveHistories_AspNetUsers_ApprovedById",
                table: "LeaveHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_LeaveHistories_AspNetUsers_RequestingEmployeeId",
                table: "LeaveHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_LeaveHistories_LeaveTypes_LeaveTypeId",
                table: "LeaveHistories");

            migrationBuilder.DropTable(
                name: "DetailsLeaveTypeViewModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LeaveHistories",
                table: "LeaveHistories");

            migrationBuilder.DropColumn(
                name: "DefaultDays",
                table: "LeaveTypes");

            migrationBuilder.DropColumn(
                name: "Period",
                table: "LeaveAllocations");

            migrationBuilder.RenameTable(
                name: "LeaveHistories",
                newName: "LeaveHisttories");

            migrationBuilder.RenameIndex(
                name: "IX_LeaveHistories_RequestingEmployeeId",
                table: "LeaveHisttories",
                newName: "IX_LeaveHisttories_RequestingEmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_LeaveHistories_LeaveTypeId",
                table: "LeaveHisttories",
                newName: "IX_LeaveHisttories_LeaveTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_LeaveHistories_ApprovedById",
                table: "LeaveHisttories",
                newName: "IX_LeaveHisttories_ApprovedById");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LeaveHisttories",
                table: "LeaveHisttories",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LeaveHisttories_AspNetUsers_ApprovedById",
                table: "LeaveHisttories",
                column: "ApprovedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LeaveHisttories_AspNetUsers_RequestingEmployeeId",
                table: "LeaveHisttories",
                column: "RequestingEmployeeId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LeaveHisttories_LeaveTypes_LeaveTypeId",
                table: "LeaveHisttories",
                column: "LeaveTypeId",
                principalTable: "LeaveTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
