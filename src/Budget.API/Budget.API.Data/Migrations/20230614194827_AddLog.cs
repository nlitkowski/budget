using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Budget.API.Data.Migrations
{
    public partial class AddLog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.CreateTable(
				name: "BudgetLog",
				columns: table => new
				{
					TimeStamp = table.Column<DateTime>(type: "datetime", nullable: false),
					Level = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
					Message = table.Column<string>(type: "nvarchar(max)", maxLength: int.MaxValue, nullable: false),
					Logger = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
					Callsite = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
					Exception = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
				});

		}

        protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "BudgetLog");
		}
    }
}
