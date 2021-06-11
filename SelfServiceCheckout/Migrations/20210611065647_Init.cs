using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SelfServiceCheckout.Migrations
{
	public partial class Init : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
				name: "Money",
				columns: table => new
				{
					Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
					Value = table.Column<int>(type: "int", nullable: true),
					Key = table.Column<string>(type: "nvarchar(20)", nullable: true),
					InStock = table.Column<bool>(type: "bit", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Money", x => x.Id);
				});
			migrationBuilder.InsertData(
				table: "Money",
				columns: new[] { "Key", "Value", "InStock" },
				values: new object[,]
				{
					{ "5", "0" , false},
					{ "10", "0" , false},
					{ "20", "0" , false},
					{ "50", "0" , false},
					{ "100", "0" , false},
					{ "200", "0" , false},
					{ "500", "0" , false},
					{ "1000", "0" , false},
					{ "2000", "0" , false},
					{ "5000", "0" , false},
					{ "10000", "0" , false},
					{ "20000", "0" , false}
				});

		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "Money");
		}
	}
}
