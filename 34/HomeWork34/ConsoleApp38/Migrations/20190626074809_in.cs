using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ConsoleApp38.Migrations
{
    public partial class @in : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(unicode: false, maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.Id);
                    table.UniqueConstraint("UQ_City_Name", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "Position",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(unicode: false, maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Position", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PostalItem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(unicode: false, maxLength: 250, nullable: false),
                    NumberOfPages = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostalItem", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(unicode: false, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    CityId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(unicode: false, maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Address_City_CityId",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contractor",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(unicode: false, maxLength: 250, nullable: false),
                    PositionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contractor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contractor_Position_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Position",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SendingStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PostalItemId = table.Column<int>(nullable: false),
                    UpdateStatuse = table.Column<DateTimeOffset>(nullable: false),
                    StatusId = table.Column<int>(nullable: false),
                    SendingContractorId = table.Column<int>(nullable: false),
                    SendingAddressId = table.Column<int>(nullable: false),
                    ReceivingContractorId = table.Column<int>(nullable: false),
                    ReceivingAddressId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SendingStatus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SendingStatus_PostalItem_PostalItemId",
                        column: x => x.PostalItemId,
                        principalTable: "PostalItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SendingStatus_Address_ReceivingAddressId",
                        column: x => x.ReceivingAddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SendingStatus_Contractor_ReceivingContractorId",
                        column: x => x.ReceivingContractorId,
                        principalTable: "Contractor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SendingStatus_Address_SendingAddressId",
                        column: x => x.SendingAddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SendingStatus_Contractor_SendingContractorId",
                        column: x => x.SendingContractorId,
                        principalTable: "Contractor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SendingStatus_Status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_CityId",
                table: "Address",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Contractor_PositionId",
                table: "Contractor",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_SendingStatus_PostalItemId",
                table: "SendingStatus",
                column: "PostalItemId");

            migrationBuilder.CreateIndex(
                name: "IX_SendingStatus_ReceivingAddressId",
                table: "SendingStatus",
                column: "ReceivingAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_SendingStatus_ReceivingContractorId",
                table: "SendingStatus",
                column: "ReceivingContractorId");

            migrationBuilder.CreateIndex(
                name: "IX_SendingStatus_SendingAddressId",
                table: "SendingStatus",
                column: "SendingAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_SendingStatus_SendingContractorId",
                table: "SendingStatus",
                column: "SendingContractorId");

            migrationBuilder.CreateIndex(
                name: "IX_SendingStatus_StatusId",
                table: "SendingStatus",
                column: "StatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SendingStatus");

            migrationBuilder.DropTable(
                name: "PostalItem");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "Contractor");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "Position");
        }
    }
}
