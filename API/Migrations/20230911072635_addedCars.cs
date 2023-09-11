using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class addedCars : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

           

            migrationBuilder.AddColumn<int>(
                name: "LotId",
                table: "Photos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Regions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RagionState = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TechnicalConditions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TechnicalCond = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TechnicalConditions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    CarId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Mark = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    VoluemeofTank = table.Column<double>(type: "float", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnginePower = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mileage = table.Column<double>(type: "float", nullable: false),
                    LotId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.CarId);
                });

            migrationBuilder.CreateTable(
                name: "Descriptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescriptionText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LotId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Descriptions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lots",
                columns: table => new
                {
                    LotId = table.Column<int>(type: "int", nullable: false),
                    NameLot = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lots", x => x.LotId);
                    table.ForeignKey(
                        name: "FK_Lots_Categories_LotId",
                        column: x => x.LotId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Lots_Descriptions_LotId",
                        column: x => x.LotId,
                        principalTable: "Descriptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Lots_Regions_LotId",
                        column: x => x.LotId,
                        principalTable: "Regions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Lots_TechnicalConditions_LotId",
                        column: x => x.LotId,
                        principalTable: "TechnicalConditions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Lots_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Category" },
                values: new object[,]
                {
                    { 1, "Mini" },
                    { 2, "Small Cars" },
                    { 3, "Medium Cars" },
                    { 4, "Large Cars" },
                    { 5, "Executive Cars" },
                    { 6, "Luxury Cars" },
                    { 7, "Sport Cars" },
                    { 8, "MultiPurpose Cars" },
                    { 9, "Jeeps" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "RagionState" },
                values: new object[,]
                {
                    { 1, "Greater Poland" },
                    { 2, "Kuyavian-Pomeranian" },
                    { 3, "Lesser Poland" },
                    { 4, "Lodz" },
                    { 5, "Lower Silesian" },
                    { 6, "Lublin" },
                    { 7, "Lubusz" },
                    { 8, "Masovian" },
                    { 9, "Opole" },
                    { 10, "Podlasie" },
                    { 11, "Pomeranian" }
                });

            migrationBuilder.InsertData(
                table: "TechnicalConditions",
                columns: new[] { "Id", "TechnicalCond" },
                values: new object[,]
                {
                    { 1, "New" },
                    { 2, "Old" },
                    { 3, "Damaged" },
                    { 4, "Without any Damage" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Photos_LotId",
                table: "Photos",
                column: "LotId");

  
            migrationBuilder.CreateIndex(
                name: "IX_Cars_LotId",
                table: "Cars",
                column: "LotId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Descriptions_LotId",
                table: "Descriptions",
                column: "LotId");

            migrationBuilder.CreateIndex(
                name: "IX_Lots_UserId",
                table: "Lots",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_Lots_LotId",
                table: "Photos",
                column: "LotId",
                principalTable: "Lots",
                principalColumn: "LotId");

        

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Lots_LotId",
                table: "Cars",
                column: "LotId",
                principalTable: "Lots",
                principalColumn: "LotId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Descriptions_Lots_LotId",
                table: "Descriptions",
                column: "LotId",
                principalTable: "Lots",
                principalColumn: "LotId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photos_Lots_LotId",
                table: "Photos");

            migrationBuilder.DropForeignKey(
                name: "FK_Photos_Users_UserId",
                table: "Photos");

            migrationBuilder.DropForeignKey(
                name: "FK_Descriptions_Lots_LotId",
                table: "Descriptions");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Lots");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Descriptions");

            migrationBuilder.DropTable(
                name: "Regions");

            migrationBuilder.DropTable(
                name: "TechnicalConditions");

            migrationBuilder.DropIndex(
                name: "IX_Photos_LotId",
                table: "Photos");

            migrationBuilder.DropIndex(
                name: "IX_Photos_UserId",
                table: "Photos");

            migrationBuilder.DropColumn(
                name: "LotId",
                table: "Photos");

            migrationBuilder.RenameColumn(
                name: "Url",
                table: "Photos",
                newName: "Ulr");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Photos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Photos_UserId",
                table: "Photos",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_Users_UserId",
                table: "Photos",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
