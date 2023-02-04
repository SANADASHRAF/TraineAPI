using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TraineAPI.Migrations
{
    /// <inheritdoc />
    public partial class udate5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tickets_payments_PaymentId",
                table: "tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_tickets_users_UserId",
                table: "tickets");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "tickets",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "PaymentId",
                table: "tickets",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "NumOfSeat",
                table: "tickets",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_tickets_payments_PaymentId",
                table: "tickets",
                column: "PaymentId",
                principalTable: "payments",
                principalColumn: "PaymentId");

            migrationBuilder.AddForeignKey(
                name: "FK_tickets_users_UserId",
                table: "tickets",
                column: "UserId",
                principalTable: "users",
                principalColumn: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tickets_payments_PaymentId",
                table: "tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_tickets_users_UserId",
                table: "tickets");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "tickets",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PaymentId",
                table: "tickets",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "NumOfSeat",
                table: "tickets",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_tickets_payments_PaymentId",
                table: "tickets",
                column: "PaymentId",
                principalTable: "payments",
                principalColumn: "PaymentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tickets_users_UserId",
                table: "tickets",
                column: "UserId",
                principalTable: "users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
