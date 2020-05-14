using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartStoreInventoryManagement.Core.Migrations
{
    public partial class Initials : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    RefreshToken = table.Column<string>(nullable: true),
                    ProviderKey = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(maxLength: 150, nullable: true),
                    FirstName = table.Column<string>(maxLength: 150, nullable: true),
                    MiddleName = table.Column<string>(maxLength: 150, nullable: true),
                    Gender = table.Column<int>(nullable: false),
                    PictureUrl = table.Column<string>(nullable: true),
                    SystemUser = table.Column<bool>(nullable: false),
                    CanUseApplication = table.Column<bool>(nullable: false),
                    LastLoginDateUtc = table.Column<DateTime>(nullable: true),
                    JoinDate = table.Column<DateTime>(nullable: false),
                    UserType = table.Column<int>(nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(nullable: false),
                    LastLoginDate = table.Column<DateTime>(nullable: true),
                    Activated = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bank",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    DeletedBy = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    ModifiedBy = table.Column<Guid>(nullable: true),
                    RegNumber = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 350, nullable: true),
                    AbbrCode = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bank", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    DeletedBy = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    ModifiedBy = table.Column<Guid>(nullable: true),
                    CategorNumber = table.Column<string>(maxLength: 300, nullable: true),
                    Name = table.Column<string>(maxLength: 300, nullable: true),
                    Description = table.Column<string>(maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    DeletedBy = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    ModifiedBy = table.Column<Guid>(nullable: true),
                    Name = table.Column<string>(maxLength: 150, nullable: true),
                    Description = table.Column<string>(maxLength: 300, nullable: true),
                    Address = table.Column<string>(maxLength: 500, nullable: true),
                    TaxId = table.Column<string>(nullable: true),
                    MobileNo = table.Column<string>(nullable: true),
                    OfficeNo = table.Column<string>(maxLength: 13, nullable: true),
                    EmailAddress = table.Column<string>(maxLength: 300, nullable: true),
                    Website = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    DeletedBy = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    ModifiedBy = table.Column<Guid>(nullable: true),
                    CustomerNo = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(maxLength: 300, nullable: true),
                    FirstName = table.Column<string>(maxLength: 150, nullable: true),
                    IsMale = table.Column<bool>(nullable: false),
                    TelNo = table.Column<string>(maxLength: 13, nullable: true),
                    Address = table.Column<string>(maxLength: 500, nullable: true),
                    DoB = table.Column<DateTime>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    DeletedBy = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    ModifiedBy = table.Column<Guid>(nullable: true),
                    RegNumber = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 300, nullable: true),
                    Description = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductShelf",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    DeletedBy = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    ModifiedBy = table.Column<Guid>(nullable: true),
                    RegNumber = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 300, nullable: true),
                    Description = table.Column<string>(maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductShelf", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UnitOfMeasure",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    DeletedBy = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    ModifiedBy = table.Column<Guid>(nullable: true),
                    Symbol = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 300, nullable: true),
                    Decimals = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitOfMeasure", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    RoleId = table.Column<Guid>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true),
                    Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BankAccount",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    DeletedBy = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    ModifiedBy = table.Column<Guid>(nullable: true),
                    RegNumber = table.Column<string>(nullable: true),
                    AccountNo = table.Column<string>(maxLength: 13, nullable: true),
                    Title = table.Column<string>(maxLength: 500, nullable: true),
                    Bank_Id = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankAccount", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BankAccount_Bank_Bank_Id",
                        column: x => x.Bank_Id,
                        principalTable: "Bank",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Vendor",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    DeletedBy = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    ModifiedBy = table.Column<Guid>(nullable: true),
                    RegNumber = table.Column<string>(nullable: true),
                    Number = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 350, nullable: true),
                    ContactPerson = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    EmailAddress = table.Column<string>(maxLength: 300, nullable: true),
                    OfficeNumber = table.Column<string>(maxLength: 13, nullable: true),
                    ContactNumber = table.Column<string>(nullable: true),
                    Address = table.Column<string>(maxLength: 500, nullable: true),
                    Company_Id = table.Column<Guid>(nullable: false),
                    MyAppUser_Id = table.Column<Guid>(nullable: false),
                    MyAppUserId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vendor_Company_Company_Id",
                        column: x => x.Company_Id,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vendor_AspNetUsers_MyAppUserId",
                        column: x => x.MyAppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Branch",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    DeletedBy = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    ModifiedBy = table.Column<Guid>(nullable: true),
                    RegNumber = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 300, nullable: true),
                    Description = table.Column<string>(maxLength: 500, nullable: true),
                    Department_Id = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branch", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Branch_Department_Department_Id",
                        column: x => x.Department_Id,
                        principalTable: "Department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseOder",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    DeletedBy = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    ModifiedBy = table.Column<Guid>(nullable: true),
                    PurchaseOrderID = table.Column<string>(nullable: true),
                    OrderDate = table.Column<DateTime>(nullable: false),
                    DueDate = table.Column<DateTime>(nullable: false),
                    SupplyDate = table.Column<DateTime>(nullable: false),
                    TaxAmt = table.Column<int>(nullable: false),
                    Total = table.Column<decimal>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    UserCreatedBy_Id = table.Column<Guid>(nullable: true),
                    Vendor_Id = table.Column<Guid>(nullable: true),
                    Branch_Id = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseOder", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseOder_Branch_Branch_Id",
                        column: x => x.Branch_Id,
                        principalTable: "Branch",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseOder_AspNetUsers_UserCreatedBy_Id",
                        column: x => x.UserCreatedBy_Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseOder_Vendor_Vendor_Id",
                        column: x => x.Vendor_Id,
                        principalTable: "Vendor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Staff",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    DeletedBy = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    ModifiedBy = table.Column<Guid>(nullable: true),
                    Title = table.Column<string>(maxLength: 50, nullable: true),
                    User_Id = table.Column<Guid>(nullable: false),
                    StaffNo = table.Column<string>(maxLength: 100, nullable: true),
                    Branch_Id = table.Column<Guid>(nullable: true),
                    Department_Id = table.Column<Guid>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    OfficeNo = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false),
                    Staff_Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staff", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Staff_Branch_Branch_Id",
                        column: x => x.Branch_Id,
                        principalTable: "Branch",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Staff_Department_Department_Id",
                        column: x => x.Department_Id,
                        principalTable: "Department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Staff_AspNetUsers_User_Id",
                        column: x => x.User_Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Voucher",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    DeletedBy = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    ModifiedBy = table.Column<Guid>(nullable: true),
                    VoucherNumber = table.Column<string>(maxLength: 500, nullable: true),
                    LPO = table.Column<int>(nullable: false),
                    ValueDate = table.Column<DateTime>(nullable: false),
                    ExpiryDate = table.Column<DateTime>(nullable: false),
                    Amount = table.Column<decimal>(nullable: false),
                    AmountReleased = table.Column<decimal>(nullable: false),
                    PaidStatus = table.Column<int>(nullable: false),
                    ChequeNo = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
                    Bank_Id = table.Column<Guid>(nullable: true),
                    Vendor_Id = table.Column<Guid>(nullable: true),
                    BankAccount_Id = table.Column<Guid>(nullable: true),
                    Branch_Id = table.Column<Guid>(nullable: true),
                    UserCreatedBy_Id = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Voucher", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Voucher_BankAccount_BankAccount_Id",
                        column: x => x.BankAccount_Id,
                        principalTable: "BankAccount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Voucher_Bank_Bank_Id",
                        column: x => x.Bank_Id,
                        principalTable: "Bank",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Voucher_Branch_Branch_Id",
                        column: x => x.Branch_Id,
                        principalTable: "Branch",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Voucher_AspNetUsers_UserCreatedBy_Id",
                        column: x => x.UserCreatedBy_Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Voucher_Vendor_Vendor_Id",
                        column: x => x.Vendor_Id,
                        principalTable: "Vendor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    DeletedBy = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    ModifiedBy = table.Column<Guid>(nullable: true),
                    ProductNo = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 150, nullable: true),
                    Description = table.Column<string>(maxLength: 500, nullable: true),
                    TagNumber = table.Column<string>(nullable: true),
                    SerialNumber = table.Column<string>(nullable: true),
                    Period = table.Column<int>(nullable: false),
                    productType = table.Column<int>(nullable: false),
                    productstatus = table.Column<int>(nullable: false),
                    ReasonForInactivity = table.Column<string>(nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    RFID = table.Column<string>(nullable: true),
                    Barcode = table.Column<string>(nullable: true),
                    Class = table.Column<string>(nullable: true),
                    Style = table.Column<string>(nullable: true),
                    Color = table.Column<string>(maxLength: 150, nullable: true),
                    OpenBalance = table.Column<int>(nullable: false),
                    StandardCost = table.Column<decimal>(nullable: true),
                    UnitCost = table.Column<decimal>(nullable: true),
                    UnitPrice = table.Column<decimal>(nullable: true),
                    StockOutWarning = table.Column<int>(nullable: false),
                    ReOrderPoint = table.Column<int>(nullable: false),
                    SellStartDate = table.Column<DateTime>(nullable: false),
                    SellEndDate = table.Column<DateTime>(nullable: false),
                    DiscountRate = table.Column<decimal>(nullable: false),
                    VATRate = table.Column<decimal>(nullable: false),
                    Category_Id = table.Column<Guid>(nullable: true),
                    ProductShelf_Id = table.Column<Guid>(nullable: true),
                    Staff_Id = table.Column<Guid>(nullable: true),
                    UnitOfMeasure_Id = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_Category_Category_Id",
                        column: x => x.Category_Id,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Product_ProductShelf_ProductShelf_Id",
                        column: x => x.ProductShelf_Id,
                        principalTable: "ProductShelf",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Product_Staff_Staff_Id",
                        column: x => x.Staff_Id,
                        principalTable: "Staff",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Product_UnitOfMeasure_UnitOfMeasure_Id",
                        column: x => x.UnitOfMeasure_Id,
                        principalTable: "UnitOfMeasure",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseOrderDetail",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    DeletedBy = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    ModifiedBy = table.Column<Guid>(nullable: true),
                    OrderDetailNo = table.Column<string>(nullable: true),
                    VAT = table.Column<float>(nullable: false),
                    TaxValue = table.Column<decimal>(nullable: true),
                    SubTotal = table.Column<decimal>(nullable: true),
                    Amount = table.Column<decimal>(nullable: false),
                    UnitPrice = table.Column<decimal>(nullable: false),
                    OrderQuantity = table.Column<float>(nullable: false),
                    PurchaseOder_Id = table.Column<Guid>(nullable: true),
                    Product_Id = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseOrderDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseOrderDetail_Product_Product_Id",
                        column: x => x.Product_Id,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseOrderDetail_PurchaseOder_PurchaseOder_Id",
                        column: x => x.PurchaseOder_Id,
                        principalTable: "PurchaseOder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SellingPrice",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    DeletedBy = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    ModifiedBy = table.Column<Guid>(nullable: true),
                    PriceNumber = table.Column<string>(maxLength: 500, nullable: true),
                    Name = table.Column<string>(maxLength: 300, nullable: true),
                    SettingDate = table.Column<DateTime>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    Product_Id = table.Column<Guid>(nullable: true),
                    UserCreatedBy_Id = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SellingPrice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SellingPrice_Product_Product_Id",
                        column: x => x.Product_Id,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SellingPrice_AspNetUsers_UserCreatedBy_Id",
                        column: x => x.UserCreatedBy_Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RequestOrder",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    DeletedBy = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    ModifiedBy = table.Column<Guid>(nullable: true),
                    RequestNumber = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(maxLength: 500, nullable: true),
                    RequestDate = table.Column<DateTime>(nullable: false),
                    ExpectedDate = table.Column<DateTime>(nullable: false),
                    UserCreatedBy_Id = table.Column<Guid>(nullable: true),
                    Store_Id = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestOrder", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RequestOrder_AspNetUsers_UserCreatedBy_Id",
                        column: x => x.UserCreatedBy_Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RequestOrderDetail",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    DeletedBy = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    ModifiedBy = table.Column<Guid>(nullable: true),
                    OrderDetailNo = table.Column<string>(nullable: true),
                    QuantityRequest = table.Column<int>(nullable: false),
                    QuantityReleased = table.Column<int>(nullable: false),
                    RequestOrder_Id = table.Column<Guid>(nullable: true),
                    Product_Id = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestOrderDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RequestOrderDetail_Product_Product_Id",
                        column: x => x.Product_Id,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RequestOrderDetail_RequestOrder_RequestOrder_Id",
                        column: x => x.RequestOrder_Id,
                        principalTable: "RequestOrder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Store",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    DeletedBy = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    ModifiedBy = table.Column<Guid>(nullable: true),
                    StoreNumber = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 500, nullable: true),
                    Description = table.Column<string>(maxLength: 500, nullable: true),
                    StockQuantity = table.Column<int>(maxLength: 500, nullable: false),
                    EntryDate = table.Column<DateTime>(nullable: false),
                    ExpireDate = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    ProductStatus = table.Column<int>(nullable: false),
                    ProductType = table.Column<int>(nullable: false),
                    Product_Id = table.Column<Guid>(nullable: true),
                    ProductShelf_Id = table.Column<Guid>(nullable: true),
                    UserCreatedBy_Id = table.Column<Guid>(nullable: true),
                    Branch_Id = table.Column<Guid>(nullable: true),
                    Department_Id = table.Column<Guid>(nullable: true),
                    ProductLocationId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Store", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Store_Branch_Branch_Id",
                        column: x => x.Branch_Id,
                        principalTable: "Branch",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Store_Department_Department_Id",
                        column: x => x.Department_Id,
                        principalTable: "Department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Store_ProductShelf_ProductShelf_Id",
                        column: x => x.ProductShelf_Id,
                        principalTable: "ProductShelf",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Store_Product_Product_Id",
                        column: x => x.Product_Id,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Store_AspNetUsers_UserCreatedBy_Id",
                        column: x => x.UserCreatedBy_Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductLocation",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    DeletedBy = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    ModifiedBy = table.Column<Guid>(nullable: true),
                    RegNumber = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 300, nullable: true),
                    Description = table.Column<string>(maxLength: 300, nullable: true),
                    QuantityTransfered = table.Column<int>(nullable: false),
                    TransferDate = table.Column<DateTime>(nullable: false),
                    Product_Id = table.Column<Guid>(nullable: true),
                    Store_Id = table.Column<Guid>(nullable: true),
                    PreviousStore_Id = table.Column<Guid>(nullable: true),
                    Branch_Id = table.Column<Guid>(nullable: true),
                    PreviousBranch_Id = table.Column<Guid>(nullable: true),
                    Department_Id = table.Column<Guid>(nullable: true),
                    UnitPrice = table.Column<decimal>(nullable: true),
                    ProductSold = table.Column<decimal>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductLocation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductLocation_Branch_Branch_Id",
                        column: x => x.Branch_Id,
                        principalTable: "Branch",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductLocation_Department_Department_Id",
                        column: x => x.Department_Id,
                        principalTable: "Department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductLocation_Branch_PreviousBranch_Id",
                        column: x => x.PreviousBranch_Id,
                        principalTable: "Branch",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductLocation_Store_PreviousStore_Id",
                        column: x => x.PreviousStore_Id,
                        principalTable: "Store",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductLocation_Product_Product_Id",
                        column: x => x.Product_Id,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductLocation_Store_Store_Id",
                        column: x => x.Store_Id,
                        principalTable: "Store",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("a1b6b6b0-0825-4975-a93d-df3dc86f8cc7"), "fa5bc557a89740c6897da824010bd925", "SYS_ADMIN", "SYS_ADMIN" },
                    { new Guid("0718ddef-4067-4f29-aaa1-98c1548c1807"), "70e1ebe83b0143d2b7b1f1aebf27d727", "SUPER_ADMIN", "SUPER_ADMIN" },
                    { new Guid("8b93d395-a71a-4620-9352-5b9e6b3b6045"), "bf3657df58a04ce598e19e275bca026c", "SUPERUSER", "SUPERUSER" },
                    { new Guid("02bde570-4aa8-4c60-a462-07154aa69520"), "98c838441f814048883afce1a5cc5abb", "STAFF_USER", "STAFF_USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Activated", "CanUseApplication", "ConcurrencyStamp", "CreatedOnUtc", "Email", "EmailConfirmed", "FirstName", "Gender", "IsDeleted", "JoinDate", "LastLoginDate", "LastLoginDateUtc", "LastName", "LockoutEnabled", "LockoutEnd", "MiddleName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PictureUrl", "ProviderKey", "RefreshToken", "SecurityStamp", "SystemUser", "TwoFactorEnabled", "UserName", "UserType" },
                values: new object[,]
                {
                    { new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), 0, true, false, "1b3b31fd-0a1b-4285-a485-7cd3ba75cfc7", new DateTime(2019, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "system@smartstore.com", true, "Olaleye", 0, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Walure", false, null, null, "SYSTEM@SMARTSTORE.COM", "SYSTEM@SMARTSTORE.COM", "AQAAAAEAACcQAAAAENyafPtXGjanscQ/cJtxhcCPFQGt3D4sB9IXvb38Yth06OKaL9Owl2WNS5EKRCToHA==", "08067623699", true, null, null, null, "99ae0c45-d682-4542-9ba7-1281e471916b", false, false, "system@smartstore.com", 0 },
                    { new Guid("3fb897c8-c25d-4328-9813-cb1544369fba"), 0, true, false, "6e538e96-0e1f-4952-ad15-20abc3e14d12", new DateTime(2019, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "superadmin@smartstore.com", true, "Olaleye", 0, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Walure", false, null, null, "SUPERADMIN@SMARTSTORE.COM", "SUPERADMIN@SMARTSTORE.COM", "AQAAAAEAACcQAAAAEFY/myU6oC7nfLbl20znWDg/1KDAhJaakAMDuPFxk9IDyhSzhJOAX2HU44vbzIGGbg==", "08067623699", true, null, null, null, "016020e3-5c50-40b4-9e66-bba56c9f5bf2", false, false, "superadmin@smartstore.com", 1 },
                    { new Guid("973af7a9-7f18-4e8b-acd3-bc906580561a"), 0, true, false, "2181e8e1-7513-4845-ae03-b24625fb1ae7", new DateTime(2019, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "storemanager@vericore.com", true, "Prolifik", 0, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Lexzy", false, null, null, "STOREMANAGER@VERICORE.COM", "STOREMANAGER@VERICORE.COM", "AQAAAAEAACcQAAAAENoWFzlkaN4MZ2LIdjNRWWaYhQwAJwfxHtCq4gCfCZr8HwZQabD3SlF+10ARJHWT2A==", "08062066851", true, null, null, null, "7d728c76-1c51-491a-99db-bde6a5b0655b", false, false, "storemanager@vericore.com", 2 },
                    { new Guid("129712e3-9214-4dd3-9c03-cfc4eb9ba979"), 0, true, false, "e87199ff-4758-4d8c-9829-86a215a11aa5", new DateTime(2019, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "staff@smartstore.com", true, "Bolaji", 0, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Siraj", false, null, null, "STAFF@SMARTSTORE.COM", "STAFF@SMARTSTORE.COM", "AQAAAAEAACcQAAAAEPeMtIncpPJaGjdkO6FxXOiamTdIxD6jsYgHJxvRwYqlWTOA0HdP8wr6VF1iYyiAmA==", "08062066851", true, null, null, null, "953d3fd1-99e3-4fe7-a20d-3598baa96099", false, false, "staff@smartstore.com", 1 }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId", "Id" },
                values: new object[,]
                {
                    { new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new Guid("a1b6b6b0-0825-4975-a93d-df3dc86f8cc7"), 0 },
                    { new Guid("3fb897c8-c25d-4328-9813-cb1544369fba"), new Guid("0718ddef-4067-4f29-aaa1-98c1548c1807"), 0 },
                    { new Guid("973af7a9-7f18-4e8b-acd3-bc906580561a"), new Guid("8b93d395-a71a-4620-9352-5b9e6b3b6045"), 0 },
                    { new Guid("129712e3-9214-4dd3-9c03-cfc4eb9ba979"), new Guid("02bde570-4aa8-4c60-a462-07154aa69520"), 0 }
                });

            migrationBuilder.InsertData(
                table: "Staff",
                columns: new[] { "Id", "Address", "Branch_Id", "CreateOn", "CreatedBy", "CreatedOn", "DeletedBy", "DeletedOn", "Department_Id", "Email", "IsDeleted", "ModifiedBy", "ModifiedOn", "OfficeNo", "PhoneNumber", "StaffNo", "Staff_Type", "Status", "Title", "User_Id" },
                values: new object[,]
                {
                    { new Guid("1f1c57d1-14d9-4aca-8457-543b5874568b"), null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 9, 17, 6, 54, 57, 860, DateTimeKind.Utc), null, null, null, null, false, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 9, 17, 6, 54, 57, 860, DateTimeKind.Utc), null, null, "0001", 0, false, "Mrs.", new Guid("973af7a9-7f18-4e8b-acd3-bc906580561a") },
                    { new Guid("dbb5809d-b496-45c0-a3f3-db2ac9e84251"), null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 9, 17, 6, 54, 57, 860, DateTimeKind.Utc), null, null, null, null, false, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 9, 17, 6, 54, 57, 860, DateTimeKind.Utc), null, null, "0002", 0, false, "Mr", new Guid("129712e3-9214-4dd3-9c03-cfc4eb9ba979") },
                    { new Guid("8270691f-b40e-4794-8960-6b6b7ddc8e2c"), null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 9, 17, 6, 54, 57, 860, DateTimeKind.Utc), null, null, null, null, false, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 9, 17, 6, 54, 57, 860, DateTimeKind.Utc), null, null, "0003", 0, false, "Mr", new Guid("129712e3-9214-4dd3-9c03-cfc4eb9ba979") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BankAccount_Bank_Id",
                table: "BankAccount",
                column: "Bank_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Branch_Department_Id",
                table: "Branch",
                column: "Department_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Product_Category_Id",
                table: "Product",
                column: "Category_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProductShelf_Id",
                table: "Product",
                column: "ProductShelf_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Product_Staff_Id",
                table: "Product",
                column: "Staff_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Product_UnitOfMeasure_Id",
                table: "Product",
                column: "UnitOfMeasure_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ProductLocation_Branch_Id",
                table: "ProductLocation",
                column: "Branch_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ProductLocation_Department_Id",
                table: "ProductLocation",
                column: "Department_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ProductLocation_PreviousBranch_Id",
                table: "ProductLocation",
                column: "PreviousBranch_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ProductLocation_PreviousStore_Id",
                table: "ProductLocation",
                column: "PreviousStore_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ProductLocation_Product_Id",
                table: "ProductLocation",
                column: "Product_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ProductLocation_Store_Id",
                table: "ProductLocation",
                column: "Store_Id");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOder_Branch_Id",
                table: "PurchaseOder",
                column: "Branch_Id");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOder_UserCreatedBy_Id",
                table: "PurchaseOder",
                column: "UserCreatedBy_Id");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOder_Vendor_Id",
                table: "PurchaseOder",
                column: "Vendor_Id");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderDetail_Product_Id",
                table: "PurchaseOrderDetail",
                column: "Product_Id");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderDetail_PurchaseOder_Id",
                table: "PurchaseOrderDetail",
                column: "PurchaseOder_Id");

            migrationBuilder.CreateIndex(
                name: "IX_RequestOrder_Store_Id",
                table: "RequestOrder",
                column: "Store_Id");

            migrationBuilder.CreateIndex(
                name: "IX_RequestOrder_UserCreatedBy_Id",
                table: "RequestOrder",
                column: "UserCreatedBy_Id");

            migrationBuilder.CreateIndex(
                name: "IX_RequestOrderDetail_Product_Id",
                table: "RequestOrderDetail",
                column: "Product_Id");

            migrationBuilder.CreateIndex(
                name: "IX_RequestOrderDetail_RequestOrder_Id",
                table: "RequestOrderDetail",
                column: "RequestOrder_Id");

            migrationBuilder.CreateIndex(
                name: "IX_SellingPrice_Product_Id",
                table: "SellingPrice",
                column: "Product_Id");

            migrationBuilder.CreateIndex(
                name: "IX_SellingPrice_UserCreatedBy_Id",
                table: "SellingPrice",
                column: "UserCreatedBy_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Staff_Branch_Id",
                table: "Staff",
                column: "Branch_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Staff_Department_Id",
                table: "Staff",
                column: "Department_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Staff_User_Id",
                table: "Staff",
                column: "User_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Store_Branch_Id",
                table: "Store",
                column: "Branch_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Store_Department_Id",
                table: "Store",
                column: "Department_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Store_ProductLocationId",
                table: "Store",
                column: "ProductLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Store_ProductShelf_Id",
                table: "Store",
                column: "ProductShelf_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Store_Product_Id",
                table: "Store",
                column: "Product_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Store_UserCreatedBy_Id",
                table: "Store",
                column: "UserCreatedBy_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Vendor_Company_Id",
                table: "Vendor",
                column: "Company_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Vendor_MyAppUserId",
                table: "Vendor",
                column: "MyAppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Voucher_BankAccount_Id",
                table: "Voucher",
                column: "BankAccount_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Voucher_Bank_Id",
                table: "Voucher",
                column: "Bank_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Voucher_Branch_Id",
                table: "Voucher",
                column: "Branch_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Voucher_UserCreatedBy_Id",
                table: "Voucher",
                column: "UserCreatedBy_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Voucher_Vendor_Id",
                table: "Voucher",
                column: "Vendor_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RequestOrder_Store_Store_Id",
                table: "RequestOrder",
                column: "Store_Id",
                principalTable: "Store",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Store_ProductLocation_ProductLocationId",
                table: "Store",
                column: "ProductLocationId",
                principalTable: "ProductLocation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Staff_AspNetUsers_User_Id",
                table: "Staff");

            migrationBuilder.DropForeignKey(
                name: "FK_Store_AspNetUsers_UserCreatedBy_Id",
                table: "Store");

            migrationBuilder.DropForeignKey(
                name: "FK_Branch_Department_Department_Id",
                table: "Branch");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductLocation_Department_Department_Id",
                table: "ProductLocation");

            migrationBuilder.DropForeignKey(
                name: "FK_Staff_Department_Department_Id",
                table: "Staff");

            migrationBuilder.DropForeignKey(
                name: "FK_Store_Department_Department_Id",
                table: "Store");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Category_Category_Id",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_ProductShelf_ProductShelf_Id",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Store_ProductShelf_ProductShelf_Id",
                table: "Store");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Staff_Staff_Id",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_UnitOfMeasure_UnitOfMeasure_Id",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductLocation_Branch_Branch_Id",
                table: "ProductLocation");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductLocation_Branch_PreviousBranch_Id",
                table: "ProductLocation");

            migrationBuilder.DropForeignKey(
                name: "FK_Store_Branch_Branch_Id",
                table: "Store");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductLocation_Store_PreviousStore_Id",
                table: "ProductLocation");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductLocation_Store_Store_Id",
                table: "ProductLocation");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "PurchaseOrderDetail");

            migrationBuilder.DropTable(
                name: "RequestOrderDetail");

            migrationBuilder.DropTable(
                name: "SellingPrice");

            migrationBuilder.DropTable(
                name: "Voucher");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "PurchaseOder");

            migrationBuilder.DropTable(
                name: "RequestOrder");

            migrationBuilder.DropTable(
                name: "BankAccount");

            migrationBuilder.DropTable(
                name: "Vendor");

            migrationBuilder.DropTable(
                name: "Bank");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "ProductShelf");

            migrationBuilder.DropTable(
                name: "Staff");

            migrationBuilder.DropTable(
                name: "UnitOfMeasure");

            migrationBuilder.DropTable(
                name: "Branch");

            migrationBuilder.DropTable(
                name: "Store");

            migrationBuilder.DropTable(
                name: "ProductLocation");

            migrationBuilder.DropTable(
                name: "Product");
        }
    }
}
