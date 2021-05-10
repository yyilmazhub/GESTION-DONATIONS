using Microsoft.EntityFrameworkCore.Migrations;

namespace GestionnaireDonations.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Donations",
                columns: table => new
                {
                    DonationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DonationCode = table.Column<string>(type: "nvarchar(24)", nullable: true),
                    DonateurNom = table.Column<string>(type: "nvarchar(24)", nullable: true),
                    BanqueNom = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    RIBCode = table.Column<string>(type: "nvarchar(24)", nullable: true),
                    Montant = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donations", x => x.DonationId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Donations");
        }
    }
}
