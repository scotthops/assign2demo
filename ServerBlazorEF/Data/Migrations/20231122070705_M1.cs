using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ServerBlazorEF.Data.Migrations
{
    /// <inheritdoc />
    public partial class M1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    AccountNo = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Street = table.Column<string>(type: "TEXT", nullable: false),
                    City = table.Column<string>(type: "TEXT", nullable: false),
                    PostalCode = table.Column<string>(type: "TEXT", nullable: false),
                    Country = table.Column<string>(type: "TEXT", nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Modified = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    ModifiedBy = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.AccountNo);
                });

            migrationBuilder.CreateTable(
                name: "Donations",
                columns: table => new
                {
                    TransId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    AccountNo = table.Column<int>(type: "INTEGER", nullable: false),
                    TransactionTypeId = table.Column<int>(type: "INTEGER", nullable: false),
                    Amount = table.Column<float>(type: "REAL", nullable: false),
                    PaymentMethodId = table.Column<int>(type: "INTEGER", nullable: false),
                    Notes = table.Column<string>(type: "TEXT", nullable: true),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Modified = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    ModifiedBy = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donations", x => x.TransId);
                });

            migrationBuilder.CreateTable(
                name: "PaymentMethods",
                columns: table => new
                {
                    PaymentMethodId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Modified = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    ModifiedBy = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentMethods", x => x.PaymentMethodId);
                });

            migrationBuilder.CreateTable(
                name: "TransactionTypes",
                columns: table => new
                {
                    TransactionTypeId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Modified = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedBy = table.Column<string>(type: "TEXT", nullable: false),
                    ModifiedBy = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionTypes", x => x.TransactionTypeId);
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "AccountNo", "City", "Country", "Created", "CreatedBy", "Email", "FirstName", "LastName", "Modified", "ModifiedBy", "PostalCode", "Street" },
                values: new object[,]
                {
                    { 101, "Anotherplace", "Australia", new DateTime(2023, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Admin", "alice.williams@email.com", "Alice", "Williams", new DateTime(2023, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Admin", "13579", "101 Elm St" },
                    { 123, "Anytown", "USA", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Admin", "john.doe@email.com", "John", "Doe", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Admin", "12345", "123 Main St" },
                    { 456, "Otherville", "Canada", new DateTime(2023, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "User1", "jane.smith@email.com", "Jane", "Smith", new DateTime(2023, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "User1", "67890", "456 Oak St" },
                    { 789, "Sometown", "UK", new DateTime(2023, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "User2", "bob.johnson@email.com", "Bob", "Johnson", new DateTime(2023, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "User2", "54321", "789 Pine St" }
                });

            migrationBuilder.InsertData(
                table: "Donations",
                columns: new[] { "TransId", "AccountNo", "Amount", "Created", "CreatedBy", "Date", "Modified", "ModifiedBy", "Notes", "PaymentMethodId", "TransactionTypeId" },
                values: new object[,]
                {
                    { 1, 123, 100.5f, new DateTime(2023, 1, 10, 8, 30, 0, 0, DateTimeKind.Unspecified), "User1", new DateTime(2023, 1, 10, 8, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 10, 8, 30, 0, 0, DateTimeKind.Unspecified), "User1", "Donation for Education", 1, 1 },
                    { 2, 456, 75.25f, new DateTime(2023, 1, 11, 12, 45, 0, 0, DateTimeKind.Unspecified), "User2", new DateTime(2023, 1, 11, 12, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 11, 12, 45, 0, 0, DateTimeKind.Unspecified), "User2", "Monthly Subscription", 2, 2 },
                    { 3, 789, 50.75f, new DateTime(2023, 1, 12, 10, 0, 0, 0, DateTimeKind.Unspecified), "Admin", new DateTime(2023, 1, 12, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 12, 10, 0, 0, 0, DateTimeKind.Unspecified), "Admin", "Event Registration", 3, 3 },
                    { 4, 101, 120f, new DateTime(2023, 1, 13, 14, 20, 0, 0, DateTimeKind.Unspecified), "Admin", new DateTime(2023, 1, 13, 14, 20, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 13, 14, 20, 0, 0, DateTimeKind.Unspecified), "Admin", "General Donation", 4, 1 }
                });

            migrationBuilder.InsertData(
                table: "PaymentMethods",
                columns: new[] { "PaymentMethodId", "Created", "CreatedBy", "Modified", "ModifiedBy", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Admin", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Admin", "Credit Card" },
                    { 2, new DateTime(2023, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "User1", new DateTime(2023, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "User1", "PayPal" },
                    { 3, new DateTime(2023, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "User2", new DateTime(2023, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "User2", "Bank Transfer" },
                    { 4, new DateTime(2023, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Admin", new DateTime(2023, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Admin", "Cash" }
                });

            migrationBuilder.InsertData(
                table: "TransactionTypes",
                columns: new[] { "TransactionTypeId", "Created", "CreatedBy", "Description", "Modified", "ModifiedBy", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Admin", "Donation for a cause", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Admin", "Donation" },
                    { 2, new DateTime(2023, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "User1", "Monthly subscription payment", new DateTime(2023, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "User1", "Subscription" },
                    { 3, new DateTime(2023, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "User2", "Event registration fee", new DateTime(2023, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "User2", "Event" },
                    { 4, new DateTime(2023, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Admin", "General donation", new DateTime(2023, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Admin", "General" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Donations");

            migrationBuilder.DropTable(
                name: "PaymentMethods");

            migrationBuilder.DropTable(
                name: "TransactionTypes");
        }
    }
}
