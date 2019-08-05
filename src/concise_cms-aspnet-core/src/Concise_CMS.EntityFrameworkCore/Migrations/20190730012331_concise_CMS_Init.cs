using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Concise_CMS.Migrations
{
    public partial class concise_CMS_Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "concise_AuditLogs",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TenantId = table.Column<int>(nullable: true),
                    UserId = table.Column<long>(nullable: true),
                    ServiceName = table.Column<string>(maxLength: 256, nullable: true),
                    MethodName = table.Column<string>(maxLength: 256, nullable: true),
                    Parameters = table.Column<string>(maxLength: 1024, nullable: true),
                    ReturnValue = table.Column<string>(nullable: true),
                    ExecutionTime = table.Column<DateTime>(nullable: false),
                    ExecutionDuration = table.Column<int>(nullable: false),
                    ClientIpAddress = table.Column<string>(maxLength: 64, nullable: true),
                    ClientName = table.Column<string>(maxLength: 128, nullable: true),
                    BrowserInfo = table.Column<string>(maxLength: 512, nullable: true),
                    Exception = table.Column<string>(maxLength: 2000, nullable: true),
                    ImpersonatorUserId = table.Column<long>(nullable: true),
                    ImpersonatorTenantId = table.Column<int>(nullable: true),
                    CustomData = table.Column<string>(maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_concise_AuditLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "concise_BackgroundJobs",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    JobType = table.Column<string>(maxLength: 512, nullable: false),
                    JobArgs = table.Column<string>(maxLength: 1048576, nullable: false),
                    TryCount = table.Column<short>(nullable: false),
                    NextTryTime = table.Column<DateTime>(nullable: false),
                    LastTryTime = table.Column<DateTime>(nullable: true),
                    IsAbandoned = table.Column<bool>(nullable: false),
                    Priority = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_concise_BackgroundJobs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "concise_Editions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 32, nullable: false),
                    DisplayName = table.Column<string>(maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_concise_Editions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "concise_EntityChangeSets",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    BrowserInfo = table.Column<string>(maxLength: 512, nullable: true),
                    ClientIpAddress = table.Column<string>(maxLength: 64, nullable: true),
                    ClientName = table.Column<string>(maxLength: 128, nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    ExtensionData = table.Column<string>(nullable: true),
                    ImpersonatorTenantId = table.Column<int>(nullable: true),
                    ImpersonatorUserId = table.Column<long>(nullable: true),
                    Reason = table.Column<string>(maxLength: 256, nullable: true),
                    TenantId = table.Column<int>(nullable: true),
                    UserId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_concise_EntityChangeSets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "concise_Languages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    TenantId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(maxLength: 10, nullable: false),
                    DisplayName = table.Column<string>(maxLength: 64, nullable: false),
                    Icon = table.Column<string>(maxLength: 128, nullable: true),
                    IsDisabled = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_concise_Languages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "concise_LanguageTexts",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    TenantId = table.Column<int>(nullable: true),
                    LanguageName = table.Column<string>(maxLength: 10, nullable: false),
                    Source = table.Column<string>(maxLength: 128, nullable: false),
                    Key = table.Column<string>(maxLength: 256, nullable: false),
                    Value = table.Column<string>(maxLength: 67108864, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_concise_LanguageTexts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "concise_Notifications",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    NotificationName = table.Column<string>(maxLength: 96, nullable: false),
                    Data = table.Column<string>(maxLength: 1048576, nullable: true),
                    DataTypeName = table.Column<string>(maxLength: 512, nullable: true),
                    EntityTypeName = table.Column<string>(maxLength: 250, nullable: true),
                    EntityTypeAssemblyQualifiedName = table.Column<string>(maxLength: 512, nullable: true),
                    EntityId = table.Column<string>(maxLength: 96, nullable: true),
                    Severity = table.Column<byte>(nullable: false),
                    UserIds = table.Column<string>(maxLength: 131072, nullable: true),
                    ExcludedUserIds = table.Column<string>(maxLength: 131072, nullable: true),
                    TenantIds = table.Column<string>(maxLength: 131072, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_concise_Notifications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "concise_NotificationSubscriptions",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    TenantId = table.Column<int>(nullable: true),
                    UserId = table.Column<long>(nullable: false),
                    NotificationName = table.Column<string>(maxLength: 96, nullable: true),
                    EntityTypeName = table.Column<string>(maxLength: 250, nullable: true),
                    EntityTypeAssemblyQualifiedName = table.Column<string>(maxLength: 512, nullable: true),
                    EntityId = table.Column<string>(maxLength: 96, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_concise_NotificationSubscriptions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "concise_OrganizationUnitRoles",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    TenantId = table.Column<int>(nullable: true),
                    RoleId = table.Column<int>(nullable: false),
                    OrganizationUnitId = table.Column<long>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_concise_OrganizationUnitRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "concise_OrganizationUnits",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    TenantId = table.Column<int>(nullable: true),
                    ParentId = table.Column<long>(nullable: true),
                    Code = table.Column<string>(maxLength: 95, nullable: false),
                    DisplayName = table.Column<string>(maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_concise_OrganizationUnits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_concise_OrganizationUnits_concise_OrganizationUnits_ParentId",
                        column: x => x.ParentId,
                        principalTable: "concise_OrganizationUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "concise_TenantNotifications",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    TenantId = table.Column<int>(nullable: true),
                    NotificationName = table.Column<string>(maxLength: 96, nullable: false),
                    Data = table.Column<string>(maxLength: 1048576, nullable: true),
                    DataTypeName = table.Column<string>(maxLength: 512, nullable: true),
                    EntityTypeName = table.Column<string>(maxLength: 250, nullable: true),
                    EntityTypeAssemblyQualifiedName = table.Column<string>(maxLength: 512, nullable: true),
                    EntityId = table.Column<string>(maxLength: 96, nullable: true),
                    Severity = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_concise_TenantNotifications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "concise_UserAccounts",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    TenantId = table.Column<int>(nullable: true),
                    UserId = table.Column<long>(nullable: false),
                    UserLinkId = table.Column<long>(nullable: true),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    EmailAddress = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_concise_UserAccounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "concise_UserLoginAttempts",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TenantId = table.Column<int>(nullable: true),
                    TenancyName = table.Column<string>(maxLength: 64, nullable: true),
                    UserId = table.Column<long>(nullable: true),
                    UserNameOrEmailAddress = table.Column<string>(maxLength: 255, nullable: true),
                    ClientIpAddress = table.Column<string>(maxLength: 64, nullable: true),
                    ClientName = table.Column<string>(maxLength: 128, nullable: true),
                    BrowserInfo = table.Column<string>(maxLength: 512, nullable: true),
                    Result = table.Column<byte>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_concise_UserLoginAttempts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "concise_UserNotifications",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    TenantId = table.Column<int>(nullable: true),
                    UserId = table.Column<long>(nullable: false),
                    TenantNotificationId = table.Column<Guid>(nullable: false),
                    State = table.Column<int>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_concise_UserNotifications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "concise_UserOrganizationUnits",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    TenantId = table.Column<int>(nullable: true),
                    UserId = table.Column<long>(nullable: false),
                    OrganizationUnitId = table.Column<long>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_concise_UserOrganizationUnits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "concise_Users",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    AuthenticationSource = table.Column<string>(maxLength: 64, nullable: true),
                    UserName = table.Column<string>(maxLength: 256, nullable: false),
                    TenantId = table.Column<int>(nullable: true),
                    EmailAddress = table.Column<string>(maxLength: 256, nullable: false),
                    Name = table.Column<string>(maxLength: 64, nullable: false),
                    Surname = table.Column<string>(maxLength: 64, nullable: false),
                    Password = table.Column<string>(maxLength: 128, nullable: false),
                    EmailConfirmationCode = table.Column<string>(maxLength: 328, nullable: true),
                    PasswordResetCode = table.Column<string>(maxLength: 328, nullable: true),
                    LockoutEndDateUtc = table.Column<DateTime>(nullable: true),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    IsLockoutEnabled = table.Column<bool>(nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 32, nullable: true),
                    IsPhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    SecurityStamp = table.Column<string>(maxLength: 128, nullable: true),
                    IsTwoFactorEnabled = table.Column<bool>(nullable: false),
                    IsEmailConfirmed = table.Column<bool>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: false),
                    NormalizedEmailAddress = table.Column<string>(maxLength: 256, nullable: false),
                    ConcurrencyStamp = table.Column<string>(maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_concise_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_concise_Users_concise_Users_CreatorUserId",
                        column: x => x.CreatorUserId,
                        principalTable: "concise_Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_concise_Users_concise_Users_DeleterUserId",
                        column: x => x.DeleterUserId,
                        principalTable: "concise_Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_concise_Users_concise_Users_LastModifierUserId",
                        column: x => x.LastModifierUserId,
                        principalTable: "concise_Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "concise_Features",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    TenantId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(maxLength: 2000, nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    EditionId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_concise_Features", x => x.Id);
                    table.ForeignKey(
                        name: "FK_concise_Features_concise_Editions_EditionId",
                        column: x => x.EditionId,
                        principalTable: "concise_Editions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "concise_EntityChanges",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ChangeTime = table.Column<DateTime>(nullable: false),
                    ChangeType = table.Column<byte>(nullable: false),
                    EntityChangeSetId = table.Column<long>(nullable: false),
                    EntityId = table.Column<string>(maxLength: 48, nullable: true),
                    EntityTypeFullName = table.Column<string>(maxLength: 192, nullable: true),
                    TenantId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_concise_EntityChanges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_concise_EntityChanges_concise_EntityChangeSets_EntityChangeS~",
                        column: x => x.EntityChangeSetId,
                        principalTable: "concise_EntityChangeSets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "concise_Roles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    TenantId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(maxLength: 32, nullable: false),
                    DisplayName = table.Column<string>(maxLength: 64, nullable: false),
                    IsStatic = table.Column<bool>(nullable: false),
                    IsDefault = table.Column<bool>(nullable: false),
                    NormalizedName = table.Column<string>(maxLength: 32, nullable: false),
                    ConcurrencyStamp = table.Column<string>(maxLength: 128, nullable: true),
                    Description = table.Column<string>(maxLength: 5000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_concise_Roles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_concise_Roles_concise_Users_CreatorUserId",
                        column: x => x.CreatorUserId,
                        principalTable: "concise_Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_concise_Roles_concise_Users_DeleterUserId",
                        column: x => x.DeleterUserId,
                        principalTable: "concise_Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_concise_Roles_concise_Users_LastModifierUserId",
                        column: x => x.LastModifierUserId,
                        principalTable: "concise_Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "concise_Settings",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    TenantId = table.Column<int>(nullable: true),
                    UserId = table.Column<long>(nullable: true),
                    Name = table.Column<string>(maxLength: 256, nullable: false),
                    Value = table.Column<string>(maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_concise_Settings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_concise_Settings_concise_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "concise_Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "concise_Tenants",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    TenancyName = table.Column<string>(maxLength: 64, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    ConnectionString = table.Column<string>(maxLength: 1024, nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    EditionId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_concise_Tenants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_concise_Tenants_concise_Users_CreatorUserId",
                        column: x => x.CreatorUserId,
                        principalTable: "concise_Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_concise_Tenants_concise_Users_DeleterUserId",
                        column: x => x.DeleterUserId,
                        principalTable: "concise_Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_concise_Tenants_concise_Editions_EditionId",
                        column: x => x.EditionId,
                        principalTable: "concise_Editions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_concise_Tenants_concise_Users_LastModifierUserId",
                        column: x => x.LastModifierUserId,
                        principalTable: "concise_Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "concise_UserClaims",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    TenantId = table.Column<int>(nullable: true),
                    UserId = table.Column<long>(nullable: false),
                    ClaimType = table.Column<string>(maxLength: 256, nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_concise_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_concise_UserClaims_concise_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "concise_Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "concise_UserLogins",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TenantId = table.Column<int>(nullable: true),
                    UserId = table.Column<long>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_concise_UserLogins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_concise_UserLogins_concise_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "concise_Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "concise_UserRoles",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    TenantId = table.Column<int>(nullable: true),
                    UserId = table.Column<long>(nullable: false),
                    RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_concise_UserRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_concise_UserRoles_concise_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "concise_Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "concise_UserTokens",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TenantId = table.Column<int>(nullable: true),
                    UserId = table.Column<long>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: true),
                    Name = table.Column<string>(maxLength: 128, nullable: true),
                    Value = table.Column<string>(maxLength: 512, nullable: true),
                    ExpireDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_concise_UserTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_concise_UserTokens_concise_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "concise_Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "concise_EntityPropertyChanges",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EntityChangeId = table.Column<long>(nullable: false),
                    NewValue = table.Column<string>(maxLength: 512, nullable: true),
                    OriginalValue = table.Column<string>(maxLength: 512, nullable: true),
                    PropertyName = table.Column<string>(maxLength: 96, nullable: true),
                    PropertyTypeFullName = table.Column<string>(maxLength: 192, nullable: true),
                    TenantId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_concise_EntityPropertyChanges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_concise_EntityPropertyChanges_concise_EntityChanges_EntityCh~",
                        column: x => x.EntityChangeId,
                        principalTable: "concise_EntityChanges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "concise_Permissions",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    TenantId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    IsGranted = table.Column<bool>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    RoleId = table.Column<int>(nullable: true),
                    UserId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_concise_Permissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_concise_Permissions_concise_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "concise_Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_concise_Permissions_concise_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "concise_Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "concise_RoleClaims",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    TenantId = table.Column<int>(nullable: true),
                    RoleId = table.Column<int>(nullable: false),
                    ClaimType = table.Column<string>(maxLength: 256, nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_concise_RoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_concise_RoleClaims_concise_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "concise_Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_concise_AuditLogs_TenantId_ExecutionDuration",
                table: "concise_AuditLogs",
                columns: new[] { "TenantId", "ExecutionDuration" });

            migrationBuilder.CreateIndex(
                name: "IX_concise_AuditLogs_TenantId_ExecutionTime",
                table: "concise_AuditLogs",
                columns: new[] { "TenantId", "ExecutionTime" });

            migrationBuilder.CreateIndex(
                name: "IX_concise_AuditLogs_TenantId_UserId",
                table: "concise_AuditLogs",
                columns: new[] { "TenantId", "UserId" });

            migrationBuilder.CreateIndex(
                name: "IX_concise_BackgroundJobs_IsAbandoned_NextTryTime",
                table: "concise_BackgroundJobs",
                columns: new[] { "IsAbandoned", "NextTryTime" });

            migrationBuilder.CreateIndex(
                name: "IX_concise_EntityChanges_EntityChangeSetId",
                table: "concise_EntityChanges",
                column: "EntityChangeSetId");

            migrationBuilder.CreateIndex(
                name: "IX_concise_EntityChanges_EntityTypeFullName_EntityId",
                table: "concise_EntityChanges",
                columns: new[] { "EntityTypeFullName", "EntityId" });

            migrationBuilder.CreateIndex(
                name: "IX_concise_EntityChangeSets_TenantId_CreationTime",
                table: "concise_EntityChangeSets",
                columns: new[] { "TenantId", "CreationTime" });

            migrationBuilder.CreateIndex(
                name: "IX_concise_EntityChangeSets_TenantId_Reason",
                table: "concise_EntityChangeSets",
                columns: new[] { "TenantId", "Reason" });

            migrationBuilder.CreateIndex(
                name: "IX_concise_EntityChangeSets_TenantId_UserId",
                table: "concise_EntityChangeSets",
                columns: new[] { "TenantId", "UserId" });

            migrationBuilder.CreateIndex(
                name: "IX_concise_EntityPropertyChanges_EntityChangeId",
                table: "concise_EntityPropertyChanges",
                column: "EntityChangeId");

            migrationBuilder.CreateIndex(
                name: "IX_concise_Features_EditionId_Name",
                table: "concise_Features",
                columns: new[] { "EditionId", "Name" });

            migrationBuilder.CreateIndex(
                name: "IX_concise_Features_TenantId_Name",
                table: "concise_Features",
                columns: new[] { "TenantId", "Name" });

            migrationBuilder.CreateIndex(
                name: "IX_concise_Languages_TenantId_Name",
                table: "concise_Languages",
                columns: new[] { "TenantId", "Name" });

            migrationBuilder.CreateIndex(
                name: "IX_concise_LanguageTexts_TenantId_Source_LanguageName_Key",
                table: "concise_LanguageTexts",
                columns: new[] { "TenantId", "Source", "LanguageName", "Key" });

            migrationBuilder.CreateIndex(
                name: "IX_concise_NotificationSubscriptions_NotificationName_EntityTyp~",
                table: "concise_NotificationSubscriptions",
                columns: new[] { "NotificationName", "EntityTypeName", "EntityId", "UserId" });

            migrationBuilder.CreateIndex(
                name: "IX_concise_NotificationSubscriptions_TenantId_NotificationName_~",
                table: "concise_NotificationSubscriptions",
                columns: new[] { "TenantId", "NotificationName", "EntityTypeName", "EntityId", "UserId" });

            migrationBuilder.CreateIndex(
                name: "IX_concise_OrganizationUnitRoles_TenantId_OrganizationUnitId",
                table: "concise_OrganizationUnitRoles",
                columns: new[] { "TenantId", "OrganizationUnitId" });

            migrationBuilder.CreateIndex(
                name: "IX_concise_OrganizationUnitRoles_TenantId_RoleId",
                table: "concise_OrganizationUnitRoles",
                columns: new[] { "TenantId", "RoleId" });

            migrationBuilder.CreateIndex(
                name: "IX_concise_OrganizationUnits_ParentId",
                table: "concise_OrganizationUnits",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_concise_OrganizationUnits_TenantId_Code",
                table: "concise_OrganizationUnits",
                columns: new[] { "TenantId", "Code" });

            migrationBuilder.CreateIndex(
                name: "IX_concise_Permissions_TenantId_Name",
                table: "concise_Permissions",
                columns: new[] { "TenantId", "Name" });

            migrationBuilder.CreateIndex(
                name: "IX_concise_Permissions_RoleId",
                table: "concise_Permissions",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_concise_Permissions_UserId",
                table: "concise_Permissions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_concise_RoleClaims_RoleId",
                table: "concise_RoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_concise_RoleClaims_TenantId_ClaimType",
                table: "concise_RoleClaims",
                columns: new[] { "TenantId", "ClaimType" });

            migrationBuilder.CreateIndex(
                name: "IX_concise_Roles_CreatorUserId",
                table: "concise_Roles",
                column: "CreatorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_concise_Roles_DeleterUserId",
                table: "concise_Roles",
                column: "DeleterUserId");

            migrationBuilder.CreateIndex(
                name: "IX_concise_Roles_LastModifierUserId",
                table: "concise_Roles",
                column: "LastModifierUserId");

            migrationBuilder.CreateIndex(
                name: "IX_concise_Roles_TenantId_NormalizedName",
                table: "concise_Roles",
                columns: new[] { "TenantId", "NormalizedName" });

            migrationBuilder.CreateIndex(
                name: "IX_concise_Settings_UserId",
                table: "concise_Settings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_concise_Settings_TenantId_Name",
                table: "concise_Settings",
                columns: new[] { "TenantId", "Name" });

            migrationBuilder.CreateIndex(
                name: "IX_concise_TenantNotifications_TenantId",
                table: "concise_TenantNotifications",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_concise_Tenants_CreatorUserId",
                table: "concise_Tenants",
                column: "CreatorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_concise_Tenants_DeleterUserId",
                table: "concise_Tenants",
                column: "DeleterUserId");

            migrationBuilder.CreateIndex(
                name: "IX_concise_Tenants_EditionId",
                table: "concise_Tenants",
                column: "EditionId");

            migrationBuilder.CreateIndex(
                name: "IX_concise_Tenants_LastModifierUserId",
                table: "concise_Tenants",
                column: "LastModifierUserId");

            migrationBuilder.CreateIndex(
                name: "IX_concise_Tenants_TenancyName",
                table: "concise_Tenants",
                column: "TenancyName");

            migrationBuilder.CreateIndex(
                name: "IX_concise_UserAccounts_EmailAddress",
                table: "concise_UserAccounts",
                column: "EmailAddress");

            migrationBuilder.CreateIndex(
                name: "IX_concise_UserAccounts_UserName",
                table: "concise_UserAccounts",
                column: "UserName");

            migrationBuilder.CreateIndex(
                name: "IX_concise_UserAccounts_TenantId_EmailAddress",
                table: "concise_UserAccounts",
                columns: new[] { "TenantId", "EmailAddress" });

            migrationBuilder.CreateIndex(
                name: "IX_concise_UserAccounts_TenantId_UserId",
                table: "concise_UserAccounts",
                columns: new[] { "TenantId", "UserId" });

            migrationBuilder.CreateIndex(
                name: "IX_concise_UserAccounts_TenantId_UserName",
                table: "concise_UserAccounts",
                columns: new[] { "TenantId", "UserName" });

            migrationBuilder.CreateIndex(
                name: "IX_concise_UserClaims_UserId",
                table: "concise_UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_concise_UserClaims_TenantId_ClaimType",
                table: "concise_UserClaims",
                columns: new[] { "TenantId", "ClaimType" });

            migrationBuilder.CreateIndex(
                name: "IX_concise_UserLoginAttempts_UserId_TenantId",
                table: "concise_UserLoginAttempts",
                columns: new[] { "UserId", "TenantId" });

            migrationBuilder.CreateIndex(
                name: "IX_concise_UserLoginAttempts_TenancyName_UserNameOrEmailAddress~",
                table: "concise_UserLoginAttempts",
                columns: new[] { "TenancyName", "UserNameOrEmailAddress", "Result" });

            migrationBuilder.CreateIndex(
                name: "IX_concise_UserLogins_UserId",
                table: "concise_UserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_concise_UserLogins_TenantId_UserId",
                table: "concise_UserLogins",
                columns: new[] { "TenantId", "UserId" });

            migrationBuilder.CreateIndex(
                name: "IX_concise_UserLogins_TenantId_LoginProvider_ProviderKey",
                table: "concise_UserLogins",
                columns: new[] { "TenantId", "LoginProvider", "ProviderKey" });

            migrationBuilder.CreateIndex(
                name: "IX_concise_UserNotifications_UserId_State_CreationTime",
                table: "concise_UserNotifications",
                columns: new[] { "UserId", "State", "CreationTime" });

            migrationBuilder.CreateIndex(
                name: "IX_concise_UserOrganizationUnits_TenantId_OrganizationUnitId",
                table: "concise_UserOrganizationUnits",
                columns: new[] { "TenantId", "OrganizationUnitId" });

            migrationBuilder.CreateIndex(
                name: "IX_concise_UserOrganizationUnits_TenantId_UserId",
                table: "concise_UserOrganizationUnits",
                columns: new[] { "TenantId", "UserId" });

            migrationBuilder.CreateIndex(
                name: "IX_concise_UserRoles_UserId",
                table: "concise_UserRoles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_concise_UserRoles_TenantId_RoleId",
                table: "concise_UserRoles",
                columns: new[] { "TenantId", "RoleId" });

            migrationBuilder.CreateIndex(
                name: "IX_concise_UserRoles_TenantId_UserId",
                table: "concise_UserRoles",
                columns: new[] { "TenantId", "UserId" });

            migrationBuilder.CreateIndex(
                name: "IX_concise_Users_CreatorUserId",
                table: "concise_Users",
                column: "CreatorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_concise_Users_DeleterUserId",
                table: "concise_Users",
                column: "DeleterUserId");

            migrationBuilder.CreateIndex(
                name: "IX_concise_Users_LastModifierUserId",
                table: "concise_Users",
                column: "LastModifierUserId");

            migrationBuilder.CreateIndex(
                name: "IX_concise_Users_TenantId_NormalizedEmailAddress",
                table: "concise_Users",
                columns: new[] { "TenantId", "NormalizedEmailAddress" });

            migrationBuilder.CreateIndex(
                name: "IX_concise_Users_TenantId_NormalizedUserName",
                table: "concise_Users",
                columns: new[] { "TenantId", "NormalizedUserName" });

            migrationBuilder.CreateIndex(
                name: "IX_concise_UserTokens_UserId",
                table: "concise_UserTokens",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_concise_UserTokens_TenantId_UserId",
                table: "concise_UserTokens",
                columns: new[] { "TenantId", "UserId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "concise_AuditLogs");

            migrationBuilder.DropTable(
                name: "concise_BackgroundJobs");

            migrationBuilder.DropTable(
                name: "concise_EntityPropertyChanges");

            migrationBuilder.DropTable(
                name: "concise_Features");

            migrationBuilder.DropTable(
                name: "concise_Languages");

            migrationBuilder.DropTable(
                name: "concise_LanguageTexts");

            migrationBuilder.DropTable(
                name: "concise_Notifications");

            migrationBuilder.DropTable(
                name: "concise_NotificationSubscriptions");

            migrationBuilder.DropTable(
                name: "concise_OrganizationUnitRoles");

            migrationBuilder.DropTable(
                name: "concise_OrganizationUnits");

            migrationBuilder.DropTable(
                name: "concise_Permissions");

            migrationBuilder.DropTable(
                name: "concise_RoleClaims");

            migrationBuilder.DropTable(
                name: "concise_Settings");

            migrationBuilder.DropTable(
                name: "concise_TenantNotifications");

            migrationBuilder.DropTable(
                name: "concise_Tenants");

            migrationBuilder.DropTable(
                name: "concise_UserAccounts");

            migrationBuilder.DropTable(
                name: "concise_UserClaims");

            migrationBuilder.DropTable(
                name: "concise_UserLoginAttempts");

            migrationBuilder.DropTable(
                name: "concise_UserLogins");

            migrationBuilder.DropTable(
                name: "concise_UserNotifications");

            migrationBuilder.DropTable(
                name: "concise_UserOrganizationUnits");

            migrationBuilder.DropTable(
                name: "concise_UserRoles");

            migrationBuilder.DropTable(
                name: "concise_UserTokens");

            migrationBuilder.DropTable(
                name: "concise_EntityChanges");

            migrationBuilder.DropTable(
                name: "concise_Roles");

            migrationBuilder.DropTable(
                name: "concise_Editions");

            migrationBuilder.DropTable(
                name: "concise_EntityChangeSets");

            migrationBuilder.DropTable(
                name: "concise_Users");
        }
    }
}
