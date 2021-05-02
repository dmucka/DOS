using Microsoft.EntityFrameworkCore.Migrations;

namespace DOS_DAL.Migrations
{
    public partial class ProcessSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Process",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Vstupná kontrola" },
                    { 2, "Medzioperačná kontrola" },
                    { 3, "Napínací test" },
                    { 4, "Kalibrácia" },
                    { 5, "Výstupná kontrola" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Process",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Process",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Process",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Process",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Process",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
