using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Persistance.Migrations
{
    public partial class AddDataForCategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"INSERT INTO public.""Categories""(""Description"") VALUES ('Salary');");
            migrationBuilder.Sql(@"INSERT INTO public.""Categories""(""Description"") VALUES ('Food');");
            migrationBuilder.Sql(@"INSERT INTO public.""Categories""(""Description"") VALUES ('Clothes');");
            migrationBuilder.Sql(@"INSERT INTO public.""Categories""(""Description"") VALUES ('Restaurant');");
            migrationBuilder.Sql(@"INSERT INTO public.""Categories""(""Description"") VALUES ('Vehicule');");
            migrationBuilder.Sql(@"INSERT INTO public.""Categories""(""Description"") VALUES ('Transport');");
            migrationBuilder.Sql(@"INSERT INTO public.""Categories""(""Description"") VALUES ('Home');");
            migrationBuilder.Sql(@"INSERT INTO public.""Categories""(""Description"") VALUES ('Health');");


        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DELETE FROM public.""Categories""");
        }
    }
}
