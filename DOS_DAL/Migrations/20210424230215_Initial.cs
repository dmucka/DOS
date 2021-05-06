using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace DOS_DAL.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Process",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Process", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1023)", maxLength: 1023, nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductProcess",
                schema: "dbo",
                columns: table => new
                {
                    ProcessId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductProcess", x => new { x.ProcessId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_ProductProcess_Process_ProcessId",
                        column: x => x.ProcessId,
                        principalSchema: "dbo",
                        principalTable: "Process",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductProcess_Product_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "dbo",
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Role_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "dbo",
                        principalTable: "Role",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Order",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    SerialNumber = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Customer = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(1023)", maxLength: 1023, nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Edited = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedById = table.Column<int>(type: "int", nullable: false),
                    EditedById = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_Product_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "dbo",
                        principalTable: "Product",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Order_User_CreatedById",
                        column: x => x.CreatedById,
                        principalSchema: "dbo",
                        principalTable: "User",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Order_User_EditedById",
                        column: x => x.EditedById,
                        principalSchema: "dbo",
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Tolerance",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ValueName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    MaxValue = table.Column<decimal>(type: "decimal(8,4)", nullable: false),
                    MinValue = table.Column<decimal>(type: "decimal(8,4)", nullable: false),
                    Edited = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EditedById = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ProcessId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tolerance", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tolerance_Process_ProcessId",
                        column: x => x.ProcessId,
                        principalSchema: "dbo",
                        principalTable: "Process",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tolerance_Product_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "dbo",
                        principalTable: "Product",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tolerance_User_EditedById",
                        column: x => x.EditedById,
                        principalSchema: "dbo",
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ManufacturingStep",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Wavelength = table.Column<decimal>(type: "decimal(8,4)", nullable: false, defaultValue: 0m),
                    Intensity = table.Column<decimal>(type: "decimal(8,4)", nullable: false, defaultValue: 0m),
                    Temperature = table.Column<decimal>(type: "decimal(8,4)", nullable: false, defaultValue: 0m),
                    Humidity = table.Column<decimal>(type: "decimal(8,4)", nullable: false, defaultValue: 0m),
                    Edited = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EditedById = table.Column<int>(type: "int", nullable: false),
                    ProcessId = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManufacturingStep", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ManufacturingStep_Order_OrderId",
                        column: x => x.OrderId,
                        principalSchema: "dbo",
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ManufacturingStep_Process_ProcessId",
                        column: x => x.ProcessId,
                        principalSchema: "dbo",
                        principalTable: "Process",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ManufacturingStep_User_EditedById",
                        column: x => x.EditedById,
                        principalSchema: "dbo",
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ManufacturingStep_EditedById",
                schema: "dbo",
                table: "ManufacturingStep",
                column: "EditedById");

            migrationBuilder.CreateIndex(
                name: "IX_ManufacturingStep_OrderId",
                schema: "dbo",
                table: "ManufacturingStep",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_ManufacturingStep_ProcessId",
                schema: "dbo",
                table: "ManufacturingStep",
                column: "ProcessId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_CreatedById",
                schema: "dbo",
                table: "Order",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Order_EditedById",
                schema: "dbo",
                table: "Order",
                column: "EditedById");

            migrationBuilder.CreateIndex(
                name: "IX_Order_ProductId",
                schema: "dbo",
                table: "Order",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_SerialNumber",
                schema: "dbo",
                table: "Order",
                column: "SerialNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Process_Name",
                schema: "dbo",
                table: "Process",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Product_Name",
                schema: "dbo",
                table: "Product",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductProcess_ProductId",
                schema: "dbo",
                table: "ProductProcess",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Role_Name",
                schema: "dbo",
                table: "Role",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tolerance_EditedById",
                schema: "dbo",
                table: "Tolerance",
                column: "EditedById");

            migrationBuilder.CreateIndex(
                name: "IX_Tolerance_ProcessId",
                schema: "dbo",
                table: "Tolerance",
                column: "ProcessId");

            migrationBuilder.CreateIndex(
                name: "IX_Tolerance_ProductId",
                schema: "dbo",
                table: "Tolerance",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_User_RoleId",
                schema: "dbo",
                table: "User",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_User_Username",
                schema: "dbo",
                table: "User",
                column: "Username",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ManufacturingStep",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ProductProcess",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Tolerance",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Order",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Process",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Product",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "User",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Role",
                schema: "dbo");
        }
    }
}
