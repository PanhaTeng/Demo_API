using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Demo_API.Migrations
{
    /// <inheritdoc />
    public partial class seeding_data_user_role : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8849cc49-f8c5-486f-af6e-b587e9aeeaf2", "e62493bc-5619-4f64-8471-d18c9653d1a8", "user", "USER" },
                    { "94872e29-9ae6-4450-a840-fbfaa34da622", "dacb2eaf-e8d4-419d-872f-2a05994bad6b", "admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "b9be2c08-e735-45e3-9f88-3bedf6d15d3e", 0, "4f50bc71-c227-43df-a86d-901b51025474", "user2424@gmail.com", false, false, null, "USER2424@GmAIL.COM", "USER2424@GmAIL.COM", "AQAAAAEAACcQAAAAEFUUdjDKQeZfHSiCp7GBoF2i9zS3HA7V1SCeZfKdZGuo0QV6a6Sa57A6gNrSBj+cTA==", null, false, "d2cb6fe2-9781-4297-bcaa-bfad6e2256ac", false, "user2424@gmail.com" },
                    { "beb7dab8-6c49-422f-bb91-be5998cce504", 0, "a60c701d-ddb2-4b12-b966-a7b4f9b46cf5", "admin2424@gmail.com", false, false, null, "ADMIN2424@GmAIL.COM", "ADMIN2424@GmAIL.COM", "AQAAAAEAACcQAAAAEPhjU0RDFPl/hOP+1njvr5im53rqw1u5ubGGY9T7/04lbK4iCgcyEbO4mmuronqFhw==", null, false, "70a8ffd7-d295-4501-8b3d-d6033ac8c25d", false, "admin2424@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "8849cc49-f8c5-486f-af6e-b587e9aeeaf2", "b9be2c08-e735-45e3-9f88-3bedf6d15d3e" },
                    { "94872e29-9ae6-4450-a840-fbfaa34da622", "beb7dab8-6c49-422f-bb91-be5998cce504" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "8849cc49-f8c5-486f-af6e-b587e9aeeaf2", "b9be2c08-e735-45e3-9f88-3bedf6d15d3e" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "94872e29-9ae6-4450-a840-fbfaa34da622", "beb7dab8-6c49-422f-bb91-be5998cce504" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8849cc49-f8c5-486f-af6e-b587e9aeeaf2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "94872e29-9ae6-4450-a840-fbfaa34da622");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b9be2c08-e735-45e3-9f88-3bedf6d15d3e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "beb7dab8-6c49-422f-bb91-be5998cce504");
        }
    }
}
