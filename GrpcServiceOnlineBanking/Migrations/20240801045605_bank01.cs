using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GrpcServiceOnlineBanking.Migrations
{
    /// <inheritdoc />
    public partial class bank01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountCustomers",
                columns: table => new
                {
                    AccountId = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    CustomerId = table.Column<int>(type: "int", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountCustomers", x => new { x.AccountId, x.CustomerId });
                });

            migrationBuilder.CreateTable(
                name: "Accountss",
                columns: table => new
                {
                    AccountId = table.Column<int>(type: "int", maxLength: 10, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountBalance = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    DateOpen = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BranchId = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    TypeOfAccount = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accountss", x => x.AccountId);
                });

            migrationBuilder.CreateTable(
                name: "AccountTypes",
                columns: table => new
                {
                    TypeOfAccount = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    MinimumBalanceRestriction = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountTypes", x => x.TypeOfAccount);
                });

            migrationBuilder.CreateTable(
                name: "BankingTransactions",
                columns: table => new
                {
                    TransactionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionType = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerId = table.Column<int>(type: "int", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankingTransactions", x => x.TransactionId);
                });

            migrationBuilder.CreateTable(
                name: "BranchEmployees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    BranchId = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BranchEmployees", x => new { x.BranchId, x.EmployeeId });
                });

            migrationBuilder.CreateTable(
                name: "Branches",
                columns: table => new
                {
                    BranchId = table.Column<int>(type: "int", maxLength: 10, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchName = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    StreesAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    City = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    State = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    ZipCode = table.Column<int>(type: "int", maxLength: 12, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branches", x => x.BranchId);
                });

            migrationBuilder.CreateTable(
                name: "CreditCards",
                columns: table => new
                {
                    CreditCardNumber = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    MaximumLimit = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    ExpireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreditScore = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    CustomerId = table.Column<int>(type: "int", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditCards", x => x.CreditCardNumber);
                });

            migrationBuilder.CreateTable(
                name: "CreditCardTransactionss",
                columns: table => new
                {
                    TransactionId = table.Column<int>(type: "int", maxLength: 10, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreditCardNumber = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    TransctionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    Merchant = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditCardTransactionss", x => x.TransactionId);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", maxLength: 10, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    StreesAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    City = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    State = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    ZipCode = table.Column<int>(type: "int", maxLength: 12, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    Sex = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", maxLength: 10, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    StreesAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    City = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    State = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    ZipCode = table.Column<int>(type: "int", maxLength: 12, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    Sex = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LevelOfAccess = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    SupervisorId = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "Loans",
                columns: table => new
                {
                    LoanId = table.Column<int>(type: "int", maxLength: 10, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DurationInYear = table.Column<decimal>(type: "decimal(4,2)", precision: 4, scale: 2, nullable: false),
                    LoanStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InterestRate = table.Column<decimal>(type: "decimal(4,2)", precision: 4, scale: 2, nullable: false),
                    LoanAmountTaken = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    LoanAmountRepaid = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    LoanType = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    CustomerId = table.Column<int>(type: "int", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loans", x => x.LoanId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountCustomers_AccountId_CustomerId",
                table: "AccountCustomers",
                columns: new[] { "AccountId", "CustomerId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Accountss_AccountId",
                table: "Accountss",
                column: "AccountId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AccountTypes_TypeOfAccount",
                table: "AccountTypes",
                column: "TypeOfAccount",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BankingTransactions_TransactionId",
                table: "BankingTransactions",
                column: "TransactionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BranchEmployees_BranchId_EmployeeId",
                table: "BranchEmployees",
                columns: new[] { "BranchId", "EmployeeId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Branches_BranchId",
                table: "Branches",
                column: "BranchId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CreditCards_CreditCardNumber",
                table: "CreditCards",
                column: "CreditCardNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CreditCardTransactionss_TransactionId",
                table: "CreditCardTransactionss",
                column: "TransactionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CustomerId",
                table: "Customers",
                column: "CustomerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_EmployeeId",
                table: "Employees",
                column: "EmployeeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Loans_LoanId",
                table: "Loans",
                column: "LoanId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountCustomers");

            migrationBuilder.DropTable(
                name: "Accountss");

            migrationBuilder.DropTable(
                name: "AccountTypes");

            migrationBuilder.DropTable(
                name: "BankingTransactions");

            migrationBuilder.DropTable(
                name: "BranchEmployees");

            migrationBuilder.DropTable(
                name: "Branches");

            migrationBuilder.DropTable(
                name: "CreditCards");

            migrationBuilder.DropTable(
                name: "CreditCardTransactionss");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Loans");
        }
    }
}
