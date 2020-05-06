using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartStoreInventoryManagement.Core.Migrations
{
    public partial class Initial : Migration
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
                    Description = table.Column<string>(maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductLocation", x => x.Id);
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
                    Address = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    OfficeNo = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false),
                    Staff_Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staff", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Staff_AspNetUsers_User_Id",
                        column: x => x.User_Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    RFID = table.Column<string>(nullable: true),
                    Barcode = table.Column<string>(nullable: true),
                    Color = table.Column<string>(maxLength: 150, nullable: true),
                    OpenBalance = table.Column<int>(nullable: false),
                    StandardCost = table.Column<decimal>(nullable: true),
                    UnitCost = table.Column<decimal>(nullable: true),
                    UnitPrice = table.Column<decimal>(nullable: true),
                    StockOutWarning = table.Column<bool>(nullable: false),
                    Category_Id = table.Column<Guid>(nullable: true),
                    ProductLocation_Id = table.Column<Guid>(nullable: true),
                    ProductShelf_Id = table.Column<Guid>(nullable: true),
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
                        name: "FK_Product_ProductLocation_ProductLocation_Id",
                        column: x => x.ProductLocation_Id,
                        principalTable: "ProductLocation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Product_ProductShelf_ProductShelf_Id",
                        column: x => x.ProductShelf_Id,
                        principalTable: "ProductShelf",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Product_UnitOfMeasure_UnitOfMeasure_Id",
                        column: x => x.UnitOfMeasure_Id,
                        principalTable: "UnitOfMeasure",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("a1b6b6b0-0825-4975-a93d-df3dc86f8cc7"), "236b682f3a444788aa7f8b4d4de8ef37", "SYS_ADMIN", "SYS_ADMIN" },
                    { new Guid("0718ddef-4067-4f29-aaa1-98c1548c1807"), "97dd81f0508145a9981b25c741ae482f", "SUPER_ADMIN", "SUPER_ADMIN" },
                    { new Guid("8b93d395-a71a-4620-9352-5b9e6b3b6045"), "bb68078c46e04a94b2f95d4da7994d0c", "SUPERUSER", "SUPERUSER" },
                    { new Guid("02bde570-4aa8-4c60-a462-07154aa69520"), "c0fb1a26e17947cb8c77a027365b204e", "STAFF_USER", "STAFF_USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Activated", "CanUseApplication", "ConcurrencyStamp", "CreatedOnUtc", "Email", "EmailConfirmed", "FirstName", "Gender", "IsDeleted", "JoinDate", "LastLoginDate", "LastLoginDateUtc", "LastName", "LockoutEnabled", "LockoutEnd", "MiddleName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PictureUrl", "ProviderKey", "RefreshToken", "SecurityStamp", "SystemUser", "TwoFactorEnabled", "UserName", "UserType" },
                values: new object[,]
                {
                    { new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), 0, true, false, "3e756485-c7db-4288-bf36-73888944b33c", new DateTime(2019, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "system@smartstore.com", true, "Olaleye", 0, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Walure", false, null, null, "SYSTEM@SMARTSTORE.COM", "SYSTEM@SMARTSTORE.COM", "AQAAAAEAACcQAAAAEPCUvYFU6L6CNxkpfAkIrg77O86IQUdn0Vsg/lt6EPAHJqdtm8v+FgaBnw6WJKbnyg==", "08067623699", true, null, null, null, "99ae0c45-d682-4542-9ba7-1281e471916b", false, false, "system@smartstore.com", 0 },
                    { new Guid("3fb897c8-c25d-4328-9813-cb1544369fba"), 0, true, false, "271ca2bf-9ee7-458f-9f46-43e57bce4a7b", new DateTime(2019, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "superadmin@smartstore.com", true, "Olaleye", 0, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Walure", false, null, null, "SUPERADMIN@SMARTSTORE.COM", "SUPERADMIN@SMARTSTORE.COM", "AQAAAAEAACcQAAAAEEh8MTEG+psrvl1bZ1zsFiedP5o61tTKghBfsUnb4kwuwI8VvI0A56IrttVGVCLGTA==", "08067623699", true, null, null, null, "016020e3-5c50-40b4-9e66-bba56c9f5bf2", false, false, "superadmin@smartstore.com", 1 },
                    { new Guid("973af7a9-7f18-4e8b-acd3-bc906580561a"), 0, true, false, "43db738c-a0f2-462c-b998-2716fc04e348", new DateTime(2019, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "storemanager@vericore.com", true, "Prolifik", 0, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Lexzy", false, null, null, "STOREMANAGER@VERICORE.COM", "STOREMANAGER@VERICORE.COM", "AQAAAAEAACcQAAAAEEhCB0MAR31LnATGRM0QsgteAyGn/VKq6CJNNNI+mJPLhselT3V/Z2QvZk0SfyOLBQ==", "08062066851", true, null, null, null, "7d728c76-1c51-491a-99db-bde6a5b0655b", false, false, "storemanager@vericore.com", 2 },
                    { new Guid("129712e3-9214-4dd3-9c03-cfc4eb9ba979"), 0, true, false, "8fc81bbc-16b6-4455-b8bf-e52dfd9c3709", new DateTime(2019, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "staff@smartstore.com", true, "Bolaji", 0, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 9, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Siraj", false, null, null, "STAFF@SMARTSTORE.COM", "STAFF@SMARTSTORE.COM", "AQAAAAEAACcQAAAAEHSdHo6UH+3EIuEaxyw3X4d7ca2+F//Eo7SNQ0xBi1ERzZSGl8b+UtbdjO5Puv4AgQ==", "08062066851", true, null, null, null, "953d3fd1-99e3-4fe7-a20d-3598baa96099", false, false, "staff@smartstore.com", 1 }
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
                columns: new[] { "Id", "Address", "CreateOn", "CreatedBy", "CreatedOn", "DeletedBy", "DeletedOn", "IsDeleted", "ModifiedBy", "ModifiedOn", "OfficeNo", "PhoneNumber", "StaffNo", "Staff_Type", "Status", "Title", "User_Id" },
                values: new object[,]
                {
                    { new Guid("1f1c57d1-14d9-4aca-8457-543b5874568b"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 9, 17, 6, 54, 57, 860, DateTimeKind.Utc), null, null, false, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 9, 17, 6, 54, 57, 860, DateTimeKind.Utc), null, null, "0001", 0, false, "Mrs.", new Guid("973af7a9-7f18-4e8b-acd3-bc906580561a") },
                    { new Guid("dbb5809d-b496-45c0-a3f3-db2ac9e84251"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 9, 17, 6, 54, 57, 860, DateTimeKind.Utc), null, null, false, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 9, 17, 6, 54, 57, 860, DateTimeKind.Utc), null, null, "0002", 0, false, "Mr", new Guid("129712e3-9214-4dd3-9c03-cfc4eb9ba979") },
                    { new Guid("8270691f-b40e-4794-8960-6b6b7ddc8e2c"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 9, 17, 6, 54, 57, 860, DateTimeKind.Utc), null, null, false, new Guid("1989883f-4f99-43bf-a754-239bbbfec00e"), new DateTime(2019, 9, 17, 6, 54, 57, 860, DateTimeKind.Utc), null, null, "0003", 0, false, "Mr", new Guid("129712e3-9214-4dd3-9c03-cfc4eb9ba979") }
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
                name: "IX_Product_Category_Id",
                table: "Product",
                column: "Category_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProductLocation_Id",
                table: "Product",
                column: "ProductLocation_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProductShelf_Id",
                table: "Product",
                column: "ProductShelf_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Product_UnitOfMeasure_Id",
                table: "Product",
                column: "UnitOfMeasure_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Staff_User_Id",
                table: "Staff",
                column: "User_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Vendor_Company_Id",
                table: "Vendor",
                column: "Company_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Vendor_MyAppUserId",
                table: "Vendor",
                column: "MyAppUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "Product");

            migrationBuilder.DropTable(
                name: "Staff");

            migrationBuilder.DropTable(
                name: "Vendor");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "ProductLocation");

            migrationBuilder.DropTable(
                name: "ProductShelf");

            migrationBuilder.DropTable(
                name: "UnitOfMeasure");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
