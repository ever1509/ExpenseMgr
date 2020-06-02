using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Persistance.Migrations
{
    public partial class AddDataForTypeExpenses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"INSERT INTO public.""TypeExpenses""(""Description"") VALUES ('Expense');");
            migrationBuilder.Sql(@"INSERT INTO public.""TypeExpenses""(""Description"") VALUES ('Income');");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DELETE FROM  public.""TypeExpenses""");
        }
    }
}
