using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace FiscusApi.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ArticleUnit",
                columns: table => new
                {
                    ArticleUnit_Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ArticleUnit_Text = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleUnit", x => x.ArticleUnit_Id);
                });

            migrationBuilder.CreateTable(
                name: "DocumentDetail",
                columns: table => new
                {
                    Document_Number = table.Column<int>(type: "integer", nullable: false),
                    User_IBAN = table.Column<string>(type: "text", nullable: true),
                    User_RefNumber = table.Column<string>(type: "text", nullable: true),
                    User_FirstName = table.Column<string>(type: "text", nullable: true),
                    User_LastName = table.Column<string>(type: "text", nullable: true),
                    User_Mail = table.Column<string>(type: "text", nullable: true),
                    Customer_FirstName = table.Column<string>(type: "text", nullable: true),
                    Customer_LastName = table.Column<string>(type: "text", nullable: true),
                    Customer_Address1 = table.Column<string>(type: "text", nullable: true),
                    Customer_PlzNumber = table.Column<string>(type: "text", nullable: true),
                    Customer_PlzCity = table.Column<string>(type: "text", nullable: true),
                    ArtPos_Quantity = table.Column<decimal>(type: "numeric", nullable: false),
                    Art_Title = table.Column<string>(type: "text", nullable: true),
                    Art_Description = table.Column<string>(type: "text", nullable: true),
                    Art_Price = table.Column<decimal>(type: "numeric", nullable: false),
                    TaxRate_Percentage = table.Column<decimal>(type: "numeric", nullable: false),
                    ArtUnit_Text = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "DocumentStatus",
                columns: table => new
                {
                    DocumentStatus_Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DocumentStatus_Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentStatus", x => x.DocumentStatus_Id);
                });

            migrationBuilder.CreateTable(
                name: "DocumentType",
                columns: table => new
                {
                    DocumentType_Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DocumentType_Title = table.Column<string>(type: "text", nullable: true),
                    DocumentType_Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentType", x => x.DocumentType_Id);
                });

            migrationBuilder.CreateTable(
                name: "Plz",
                columns: table => new
                {
                    Plz_Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Plz_Number = table.Column<string>(type: "text", nullable: true),
                    Plz_City = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plz", x => x.Plz_Id);
                });

            migrationBuilder.CreateTable(
                name: "TaxRate",
                columns: table => new
                {
                    Taxrate_Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Taxrate_Percentage = table.Column<double>(type: "double precision", nullable: false),
                    Taxrate_Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxRate", x => x.Taxrate_Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    User_Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    User_IBAN = table.Column<string>(type: "character varying(34)", maxLength: 34, nullable: true),
                    User_ReferenceNumber = table.Column<string>(type: "character varying(27)", maxLength: 27, nullable: true),
                    User_FirstName = table.Column<string>(type: "text", nullable: true),
                    User_LastName = table.Column<string>(type: "text", nullable: true),
                    User_DisplayName = table.Column<string>(type: "text", nullable: true),
                    User_Mail = table.Column<string>(type: "text", nullable: true),
                    User_Password = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.User_Id);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Customer_Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Customer_FirstName = table.Column<string>(type: "text", nullable: true),
                    Customer_LastName = table.Column<string>(type: "text", nullable: true),
                    Customer_Address1 = table.Column<string>(type: "text", nullable: true),
                    Customer_Address2 = table.Column<string>(type: "text", nullable: true),
                    Customer_Email = table.Column<string>(type: "text", nullable: true),
                    Customer_PlzId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Customer_Id);
                    table.ForeignKey(
                        name: "FK_Customer_Plz_Customer_PlzId",
                        column: x => x.Customer_PlzId,
                        principalTable: "Plz",
                        principalColumn: "Plz_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Article",
                columns: table => new
                {
                    Article_Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Article_Title = table.Column<string>(type: "text", nullable: true),
                    Article_Description = table.Column<string>(type: "text", nullable: true),
                    Article_Price = table.Column<double>(type: "double precision", nullable: false),
                    Article_TaxRate = table.Column<int>(type: "integer", nullable: false),
                    Article_Unit = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Article", x => x.Article_Id);
                    table.ForeignKey(
                        name: "FK_Article_ArticleUnit_Article_Unit",
                        column: x => x.Article_Unit,
                        principalTable: "ArticleUnit",
                        principalColumn: "ArticleUnit_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Article_TaxRate_Article_TaxRate",
                        column: x => x.Article_TaxRate,
                        principalTable: "TaxRate",
                        principalColumn: "Taxrate_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Document",
                columns: table => new
                {
                    Document_Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Document_Number = table.Column<int>(type: "integer", nullable: false),
                    Document_TypeId = table.Column<int>(type: "integer", nullable: false),
                    Document_CreatorId = table.Column<int>(type: "integer", nullable: false),
                    Document_SendeeId = table.Column<int>(type: "integer", nullable: false),
                    Document_StatusId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Document", x => x.Document_Id);
                    table.ForeignKey(
                        name: "FK_Document_Customer_Document_SendeeId",
                        column: x => x.Document_SendeeId,
                        principalTable: "Customer",
                        principalColumn: "Customer_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Document_DocumentStatus_Document_StatusId",
                        column: x => x.Document_StatusId,
                        principalTable: "DocumentStatus",
                        principalColumn: "DocumentStatus_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Document_DocumentType_Document_TypeId",
                        column: x => x.Document_TypeId,
                        principalTable: "DocumentType",
                        principalColumn: "DocumentType_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Document_User_Document_CreatorId",
                        column: x => x.Document_CreatorId,
                        principalTable: "User",
                        principalColumn: "User_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArticlePosition",
                columns: table => new
                {
                    ArticlePosition_Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Article_Id = table.Column<int>(type: "integer", nullable: false),
                    Document_Id = table.Column<int>(type: "integer", nullable: false),
                    Article_Quantity = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticlePosition", x => x.ArticlePosition_Id);
                    table.ForeignKey(
                        name: "FK_ArticlePosition_Article_Article_Id",
                        column: x => x.Article_Id,
                        principalTable: "Article",
                        principalColumn: "Article_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArticlePosition_Document_Document_Id",
                        column: x => x.Document_Id,
                        principalTable: "Document",
                        principalColumn: "Document_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Article_Article_TaxRate",
                table: "Article",
                column: "Article_TaxRate");

            migrationBuilder.CreateIndex(
                name: "IX_Article_Article_Unit",
                table: "Article",
                column: "Article_Unit");

            migrationBuilder.CreateIndex(
                name: "IX_ArticlePosition_Article_Id",
                table: "ArticlePosition",
                column: "Article_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ArticlePosition_Document_Id",
                table: "ArticlePosition",
                column: "Document_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_Customer_PlzId",
                table: "Customer",
                column: "Customer_PlzId");

            migrationBuilder.CreateIndex(
                name: "IX_Document_Document_CreatorId",
                table: "Document",
                column: "Document_CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Document_Document_SendeeId",
                table: "Document",
                column: "Document_SendeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Document_Document_StatusId",
                table: "Document",
                column: "Document_StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Document_Document_TypeId",
                table: "Document",
                column: "Document_TypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArticlePosition");

            migrationBuilder.DropTable(
                name: "DocumentDetail");

            migrationBuilder.DropTable(
                name: "Article");

            migrationBuilder.DropTable(
                name: "Document");

            migrationBuilder.DropTable(
                name: "ArticleUnit");

            migrationBuilder.DropTable(
                name: "TaxRate");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "DocumentStatus");

            migrationBuilder.DropTable(
                name: "DocumentType");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Plz");
        }
    }
}
