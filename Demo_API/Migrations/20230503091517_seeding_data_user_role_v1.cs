using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Demo_API.Migrations
{
    /// <inheritdoc />
    public partial class seeding_data_user_role_v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8849cc49-f8c5-486f-af6e-b587e9aeeaf2",
                column: "ConcurrencyStamp",
                value: "5aa4075b-dc4e-49a3-8d18-62394abd7604");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "94872e29-9ae6-4450-a840-fbfaa34da622",
                column: "ConcurrencyStamp",
                value: "f663261b-3eeb-4116-8c08-f2cfbcd3525c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b9be2c08-e735-45e3-9f88-3bedf6d15d3e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "07950319-28e8-4f0e-bb5d-88eb5e8a78bd", "AQAAAAEAACcQAAAAEMCbmu4pPIlEEJYRup5jSv0bykW3xSQ4qT2vTwU0CZxEifbRquRL7i4CID0n3giZrw==", "447a6642-8ffc-48f0-8f4b-3d8a01a0df32" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "beb7dab8-6c49-422f-bb91-be5998cce504",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "183c6d87-c7c7-4c9c-8269-a621c1048d1d", "AQAAAAEAACcQAAAAEH7BTDvMeQLafWVP7Sh5BUvdcZoEJ9gpPFje5TT0lWV22OELZzm8nf9Oh/a/RhyE1g==", "02e2cb55-6e18-4427-a9dc-0c68d347758f" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8849cc49-f8c5-486f-af6e-b587e9aeeaf2",
                column: "ConcurrencyStamp",
                value: "e62493bc-5619-4f64-8471-d18c9653d1a8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "94872e29-9ae6-4450-a840-fbfaa34da622",
                column: "ConcurrencyStamp",
                value: "dacb2eaf-e8d4-419d-872f-2a05994bad6b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b9be2c08-e735-45e3-9f88-3bedf6d15d3e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4f50bc71-c227-43df-a86d-901b51025474", "AQAAAAEAACcQAAAAEFUUdjDKQeZfHSiCp7GBoF2i9zS3HA7V1SCeZfKdZGuo0QV6a6Sa57A6gNrSBj+cTA==", "d2cb6fe2-9781-4297-bcaa-bfad6e2256ac" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "beb7dab8-6c49-422f-bb91-be5998cce504",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a60c701d-ddb2-4b12-b966-a7b4f9b46cf5", "AQAAAAEAACcQAAAAEPhjU0RDFPl/hOP+1njvr5im53rqw1u5ubGGY9T7/04lbK4iCgcyEbO4mmuronqFhw==", "70a8ffd7-d295-4501-8b3d-d6033ac8c25d" });
        }
    }
}
