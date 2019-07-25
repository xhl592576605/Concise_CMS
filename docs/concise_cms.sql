/*
Navicat MySQL Data Transfer

Source Server         : HANS许
Source Server Version : 50718
Source Host           : localhost:3306
Source Database       : concise_cms

Target Server Type    : MYSQL
Target Server Version : 50718
File Encoding         : 65001

Date: 2019-07-22 23:00:23
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for __efmigrationshistory
-- ----------------------------
DROP TABLE IF EXISTS `__efmigrationshistory`;
CREATE TABLE `__efmigrationshistory` (
`MigrationId`  varchar(95) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL ,
`ProductVersion`  varchar(32) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL ,
PRIMARY KEY (`MigrationId`)
)
ENGINE=InnoDB
DEFAULT CHARACTER SET=utf8 COLLATE=utf8_general_ci

;

-- ----------------------------
-- Records of __efmigrationshistory
-- ----------------------------
BEGIN;
INSERT INTO `__efmigrationshistory` VALUES ('20190721073658_concise_init20190721', '2.2.4-servicing-10062');
COMMIT;

-- ----------------------------
-- Table structure for abpauditlogs
-- ----------------------------
DROP TABLE IF EXISTS `abpauditlogs`;
CREATE TABLE `abpauditlogs` (
`Id`  bigint(20) NOT NULL AUTO_INCREMENT ,
`TenantId`  int(11) NULL DEFAULT NULL ,
`UserId`  bigint(20) NULL DEFAULT NULL ,
`ServiceName`  varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL ,
`MethodName`  varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL ,
`Parameters`  varchar(1024) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL ,
`ReturnValue`  longtext CHARACTER SET utf8 COLLATE utf8_general_ci NULL ,
`ExecutionTime`  datetime(6) NOT NULL ,
`ExecutionDuration`  int(11) NOT NULL ,
`ClientIpAddress`  varchar(64) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL ,
`ClientName`  varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL ,
`BrowserInfo`  varchar(512) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL ,
`Exception`  varchar(2000) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL ,
`ImpersonatorUserId`  bigint(20) NULL DEFAULT NULL ,
`ImpersonatorTenantId`  int(11) NULL DEFAULT NULL ,
`CustomData`  varchar(2000) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL ,
PRIMARY KEY (`Id`),
INDEX `IX_AbpAuditLogs_TenantId_ExecutionDuration` (`TenantId`, `ExecutionDuration`) USING BTREE ,
INDEX `IX_AbpAuditLogs_TenantId_ExecutionTime` (`TenantId`, `ExecutionTime`) USING BTREE ,
INDEX `IX_AbpAuditLogs_TenantId_UserId` (`TenantId`, `UserId`) USING BTREE 
)
ENGINE=InnoDB
DEFAULT CHARACTER SET=utf8 COLLATE=utf8_general_ci
AUTO_INCREMENT=1

;

-- ----------------------------
-- Records of abpauditlogs
-- ----------------------------
BEGIN;
COMMIT;

-- ----------------------------
-- Table structure for abpbackgroundjobs
-- ----------------------------
DROP TABLE IF EXISTS `abpbackgroundjobs`;
CREATE TABLE `abpbackgroundjobs` (
`Id`  bigint(20) NOT NULL AUTO_INCREMENT ,
`CreationTime`  datetime(6) NOT NULL ,
`CreatorUserId`  bigint(20) NULL DEFAULT NULL ,
`JobType`  varchar(512) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL ,
`JobArgs`  longtext CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL ,
`TryCount`  smallint(6) NOT NULL ,
`NextTryTime`  datetime(6) NOT NULL ,
`LastTryTime`  datetime(6) NULL DEFAULT NULL ,
`IsAbandoned`  bit(1) NOT NULL ,
`Priority`  tinyint(3) UNSIGNED NOT NULL ,
PRIMARY KEY (`Id`),
INDEX `IX_AbpBackgroundJobs_IsAbandoned_NextTryTime` (`IsAbandoned`, `NextTryTime`) USING BTREE 
)
ENGINE=InnoDB
DEFAULT CHARACTER SET=utf8 COLLATE=utf8_general_ci
AUTO_INCREMENT=1

;

-- ----------------------------
-- Records of abpbackgroundjobs
-- ----------------------------
BEGIN;
COMMIT;

-- ----------------------------
-- Table structure for abpeditions
-- ----------------------------
DROP TABLE IF EXISTS `abpeditions`;
CREATE TABLE `abpeditions` (
`Id`  int(11) NOT NULL AUTO_INCREMENT ,
`CreationTime`  datetime(6) NOT NULL ,
`CreatorUserId`  bigint(20) NULL DEFAULT NULL ,
`LastModificationTime`  datetime(6) NULL DEFAULT NULL ,
`LastModifierUserId`  bigint(20) NULL DEFAULT NULL ,
`IsDeleted`  bit(1) NOT NULL ,
`DeleterUserId`  bigint(20) NULL DEFAULT NULL ,
`DeletionTime`  datetime(6) NULL DEFAULT NULL ,
`Name`  varchar(32) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL ,
`DisplayName`  varchar(64) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL ,
PRIMARY KEY (`Id`)
)
ENGINE=InnoDB
DEFAULT CHARACTER SET=utf8 COLLATE=utf8_general_ci
AUTO_INCREMENT=1

;

-- ----------------------------
-- Records of abpeditions
-- ----------------------------
BEGIN;
COMMIT;

-- ----------------------------
-- Table structure for abpentitychanges
-- ----------------------------
DROP TABLE IF EXISTS `abpentitychanges`;
CREATE TABLE `abpentitychanges` (
`Id`  bigint(20) NOT NULL AUTO_INCREMENT ,
`ChangeTime`  datetime(6) NOT NULL ,
`ChangeType`  tinyint(3) UNSIGNED NOT NULL ,
`EntityChangeSetId`  bigint(20) NOT NULL ,
`EntityId`  varchar(48) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL ,
`EntityTypeFullName`  varchar(192) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL ,
`TenantId`  int(11) NULL DEFAULT NULL ,
PRIMARY KEY (`Id`),
FOREIGN KEY (`EntityChangeSetId`) REFERENCES `abpentitychangesets` (`Id`) ON DELETE CASCADE ON UPDATE RESTRICT,
INDEX `IX_AbpEntityChanges_EntityChangeSetId` (`EntityChangeSetId`) USING BTREE ,
INDEX `IX_AbpEntityChanges_EntityTypeFullName_EntityId` (`EntityTypeFullName`, `EntityId`) USING BTREE 
)
ENGINE=InnoDB
DEFAULT CHARACTER SET=utf8 COLLATE=utf8_general_ci
AUTO_INCREMENT=1

;

-- ----------------------------
-- Records of abpentitychanges
-- ----------------------------
BEGIN;
COMMIT;

-- ----------------------------
-- Table structure for abpentitychangesets
-- ----------------------------
DROP TABLE IF EXISTS `abpentitychangesets`;
CREATE TABLE `abpentitychangesets` (
`Id`  bigint(20) NOT NULL AUTO_INCREMENT ,
`BrowserInfo`  varchar(512) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL ,
`ClientIpAddress`  varchar(64) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL ,
`ClientName`  varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL ,
`CreationTime`  datetime(6) NOT NULL ,
`ExtensionData`  longtext CHARACTER SET utf8 COLLATE utf8_general_ci NULL ,
`ImpersonatorTenantId`  int(11) NULL DEFAULT NULL ,
`ImpersonatorUserId`  bigint(20) NULL DEFAULT NULL ,
`Reason`  varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL ,
`TenantId`  int(11) NULL DEFAULT NULL ,
`UserId`  bigint(20) NULL DEFAULT NULL ,
PRIMARY KEY (`Id`),
INDEX `IX_AbpEntityChangeSets_TenantId_CreationTime` (`TenantId`, `CreationTime`) USING BTREE ,
INDEX `IX_AbpEntityChangeSets_TenantId_Reason` (`TenantId`, `Reason`) USING BTREE ,
INDEX `IX_AbpEntityChangeSets_TenantId_UserId` (`TenantId`, `UserId`) USING BTREE 
)
ENGINE=InnoDB
DEFAULT CHARACTER SET=utf8 COLLATE=utf8_general_ci
AUTO_INCREMENT=1

;

-- ----------------------------
-- Records of abpentitychangesets
-- ----------------------------
BEGIN;
COMMIT;

-- ----------------------------
-- Table structure for abpentitypropertychanges
-- ----------------------------
DROP TABLE IF EXISTS `abpentitypropertychanges`;
CREATE TABLE `abpentitypropertychanges` (
`Id`  bigint(20) NOT NULL AUTO_INCREMENT ,
`EntityChangeId`  bigint(20) NOT NULL ,
`NewValue`  varchar(512) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL ,
`OriginalValue`  varchar(512) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL ,
`PropertyName`  varchar(96) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL ,
`PropertyTypeFullName`  varchar(192) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL ,
`TenantId`  int(11) NULL DEFAULT NULL ,
PRIMARY KEY (`Id`),
FOREIGN KEY (`EntityChangeId`) REFERENCES `abpentitychanges` (`Id`) ON DELETE CASCADE ON UPDATE RESTRICT,
INDEX `IX_AbpEntityPropertyChanges_EntityChangeId` (`EntityChangeId`) USING BTREE 
)
ENGINE=InnoDB
DEFAULT CHARACTER SET=utf8 COLLATE=utf8_general_ci
AUTO_INCREMENT=1

;

-- ----------------------------
-- Records of abpentitypropertychanges
-- ----------------------------
BEGIN;
COMMIT;

-- ----------------------------
-- Table structure for abpfeatures
-- ----------------------------
DROP TABLE IF EXISTS `abpfeatures`;
CREATE TABLE `abpfeatures` (
`Id`  bigint(20) NOT NULL AUTO_INCREMENT ,
`CreationTime`  datetime(6) NOT NULL ,
`CreatorUserId`  bigint(20) NULL DEFAULT NULL ,
`TenantId`  int(11) NULL DEFAULT NULL ,
`Name`  varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL ,
`Value`  varchar(2000) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL ,
`Discriminator`  longtext CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL ,
`EditionId`  int(11) NULL DEFAULT NULL ,
PRIMARY KEY (`Id`),
FOREIGN KEY (`EditionId`) REFERENCES `abpeditions` (`Id`) ON DELETE CASCADE ON UPDATE RESTRICT,
INDEX `IX_AbpFeatures_EditionId_Name` (`EditionId`, `Name`) USING BTREE ,
INDEX `IX_AbpFeatures_TenantId_Name` (`TenantId`, `Name`) USING BTREE 
)
ENGINE=InnoDB
DEFAULT CHARACTER SET=utf8 COLLATE=utf8_general_ci
AUTO_INCREMENT=1

;

-- ----------------------------
-- Records of abpfeatures
-- ----------------------------
BEGIN;
COMMIT;

-- ----------------------------
-- Table structure for abplanguages
-- ----------------------------
DROP TABLE IF EXISTS `abplanguages`;
CREATE TABLE `abplanguages` (
`Id`  int(11) NOT NULL AUTO_INCREMENT ,
`CreationTime`  datetime(6) NOT NULL ,
`CreatorUserId`  bigint(20) NULL DEFAULT NULL ,
`LastModificationTime`  datetime(6) NULL DEFAULT NULL ,
`LastModifierUserId`  bigint(20) NULL DEFAULT NULL ,
`IsDeleted`  bit(1) NOT NULL ,
`DeleterUserId`  bigint(20) NULL DEFAULT NULL ,
`DeletionTime`  datetime(6) NULL DEFAULT NULL ,
`TenantId`  int(11) NULL DEFAULT NULL ,
`Name`  varchar(10) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL ,
`DisplayName`  varchar(64) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL ,
`Icon`  varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL ,
`IsDisabled`  bit(1) NOT NULL ,
PRIMARY KEY (`Id`),
INDEX `IX_AbpLanguages_TenantId_Name` (`TenantId`, `Name`) USING BTREE 
)
ENGINE=InnoDB
DEFAULT CHARACTER SET=utf8 COLLATE=utf8_general_ci
AUTO_INCREMENT=1

;

-- ----------------------------
-- Records of abplanguages
-- ----------------------------
BEGIN;
COMMIT;

-- ----------------------------
-- Table structure for abplanguagetexts
-- ----------------------------
DROP TABLE IF EXISTS `abplanguagetexts`;
CREATE TABLE `abplanguagetexts` (
`Id`  bigint(20) NOT NULL AUTO_INCREMENT ,
`CreationTime`  datetime(6) NOT NULL ,
`CreatorUserId`  bigint(20) NULL DEFAULT NULL ,
`LastModificationTime`  datetime(6) NULL DEFAULT NULL ,
`LastModifierUserId`  bigint(20) NULL DEFAULT NULL ,
`TenantId`  int(11) NULL DEFAULT NULL ,
`LanguageName`  varchar(10) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL ,
`Source`  varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL ,
`Key`  varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL ,
`Value`  longtext CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL ,
PRIMARY KEY (`Id`),
INDEX `IX_AbpLanguageTexts_TenantId_Source_LanguageName_Key` (`TenantId`, `Source`, `LanguageName`, `Key`) USING BTREE 
)
ENGINE=InnoDB
DEFAULT CHARACTER SET=utf8 COLLATE=utf8_general_ci
AUTO_INCREMENT=1

;

-- ----------------------------
-- Records of abplanguagetexts
-- ----------------------------
BEGIN;
COMMIT;

-- ----------------------------
-- Table structure for abpnotifications
-- ----------------------------
DROP TABLE IF EXISTS `abpnotifications`;
CREATE TABLE `abpnotifications` (
`Id`  char(36) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL ,
`CreationTime`  datetime(6) NOT NULL ,
`CreatorUserId`  bigint(20) NULL DEFAULT NULL ,
`NotificationName`  varchar(96) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL ,
`Data`  longtext CHARACTER SET utf8 COLLATE utf8_general_ci NULL ,
`DataTypeName`  varchar(512) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL ,
`EntityTypeName`  varchar(250) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL ,
`EntityTypeAssemblyQualifiedName`  varchar(512) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL ,
`EntityId`  varchar(96) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL ,
`Severity`  tinyint(3) UNSIGNED NOT NULL ,
`UserIds`  longtext CHARACTER SET utf8 COLLATE utf8_general_ci NULL ,
`ExcludedUserIds`  longtext CHARACTER SET utf8 COLLATE utf8_general_ci NULL ,
`TenantIds`  longtext CHARACTER SET utf8 COLLATE utf8_general_ci NULL ,
PRIMARY KEY (`Id`)
)
ENGINE=InnoDB
DEFAULT CHARACTER SET=utf8 COLLATE=utf8_general_ci

;

-- ----------------------------
-- Records of abpnotifications
-- ----------------------------
BEGIN;
COMMIT;

-- ----------------------------
-- Table structure for abpnotificationsubscriptions
-- ----------------------------
DROP TABLE IF EXISTS `abpnotificationsubscriptions`;
CREATE TABLE `abpnotificationsubscriptions` (
`Id`  char(36) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL ,
`CreationTime`  datetime(6) NOT NULL ,
`CreatorUserId`  bigint(20) NULL DEFAULT NULL ,
`TenantId`  int(11) NULL DEFAULT NULL ,
`UserId`  bigint(20) NOT NULL ,
`NotificationName`  varchar(96) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL ,
`EntityTypeName`  varchar(250) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL ,
`EntityTypeAssemblyQualifiedName`  varchar(512) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL ,
`EntityId`  varchar(96) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL ,
PRIMARY KEY (`Id`),
INDEX `IX_AbpNotificationSubscriptions_NotificationName_EntityTypeName~` (`NotificationName`, `EntityTypeName`, `EntityId`, `UserId`) USING BTREE ,
INDEX `IX_AbpNotificationSubscriptions_TenantId_NotificationName_Entit~` (`TenantId`, `NotificationName`, `EntityTypeName`, `EntityId`, `UserId`) USING BTREE 
)
ENGINE=InnoDB
DEFAULT CHARACTER SET=utf8 COLLATE=utf8_general_ci

;

-- ----------------------------
-- Records of abpnotificationsubscriptions
-- ----------------------------
BEGIN;
COMMIT;

-- ----------------------------
-- Table structure for abporganizationunitroles
-- ----------------------------
DROP TABLE IF EXISTS `abporganizationunitroles`;
CREATE TABLE `abporganizationunitroles` (
`Id`  bigint(20) NOT NULL AUTO_INCREMENT ,
`CreationTime`  datetime(6) NOT NULL ,
`CreatorUserId`  bigint(20) NULL DEFAULT NULL ,
`TenantId`  int(11) NULL DEFAULT NULL ,
`RoleId`  int(11) NOT NULL ,
`OrganizationUnitId`  bigint(20) NOT NULL ,
`IsDeleted`  bit(1) NOT NULL ,
PRIMARY KEY (`Id`),
INDEX `IX_AbpOrganizationUnitRoles_TenantId_OrganizationUnitId` (`TenantId`, `OrganizationUnitId`) USING BTREE ,
INDEX `IX_AbpOrganizationUnitRoles_TenantId_RoleId` (`TenantId`, `RoleId`) USING BTREE 
)
ENGINE=InnoDB
DEFAULT CHARACTER SET=utf8 COLLATE=utf8_general_ci
AUTO_INCREMENT=1

;

-- ----------------------------
-- Records of abporganizationunitroles
-- ----------------------------
BEGIN;
COMMIT;

-- ----------------------------
-- Table structure for abporganizationunits
-- ----------------------------
DROP TABLE IF EXISTS `abporganizationunits`;
CREATE TABLE `abporganizationunits` (
`Id`  bigint(20) NOT NULL AUTO_INCREMENT ,
`CreationTime`  datetime(6) NOT NULL ,
`CreatorUserId`  bigint(20) NULL DEFAULT NULL ,
`LastModificationTime`  datetime(6) NULL DEFAULT NULL ,
`LastModifierUserId`  bigint(20) NULL DEFAULT NULL ,
`IsDeleted`  bit(1) NOT NULL ,
`DeleterUserId`  bigint(20) NULL DEFAULT NULL ,
`DeletionTime`  datetime(6) NULL DEFAULT NULL ,
`TenantId`  int(11) NULL DEFAULT NULL ,
`ParentId`  bigint(20) NULL DEFAULT NULL ,
`Code`  varchar(95) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL ,
`DisplayName`  varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL ,
PRIMARY KEY (`Id`),
FOREIGN KEY (`ParentId`) REFERENCES `abporganizationunits` (`Id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
INDEX `IX_AbpOrganizationUnits_ParentId` (`ParentId`) USING BTREE ,
INDEX `IX_AbpOrganizationUnits_TenantId_Code` (`TenantId`, `Code`) USING BTREE 
)
ENGINE=InnoDB
DEFAULT CHARACTER SET=utf8 COLLATE=utf8_general_ci
AUTO_INCREMENT=1

;

-- ----------------------------
-- Records of abporganizationunits
-- ----------------------------
BEGIN;
COMMIT;

-- ----------------------------
-- Table structure for abppermissions
-- ----------------------------
DROP TABLE IF EXISTS `abppermissions`;
CREATE TABLE `abppermissions` (
`Id`  bigint(20) NOT NULL AUTO_INCREMENT ,
`CreationTime`  datetime(6) NOT NULL ,
`CreatorUserId`  bigint(20) NULL DEFAULT NULL ,
`TenantId`  int(11) NULL DEFAULT NULL ,
`Name`  varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL ,
`IsGranted`  bit(1) NOT NULL ,
`Discriminator`  longtext CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL ,
`RoleId`  int(11) NULL DEFAULT NULL ,
`UserId`  bigint(20) NULL DEFAULT NULL ,
PRIMARY KEY (`Id`),
FOREIGN KEY (`RoleId`) REFERENCES `abproles` (`Id`) ON DELETE CASCADE ON UPDATE RESTRICT,
FOREIGN KEY (`UserId`) REFERENCES `abpusers` (`Id`) ON DELETE CASCADE ON UPDATE RESTRICT,
INDEX `IX_AbpPermissions_TenantId_Name` (`TenantId`, `Name`) USING BTREE ,
INDEX `IX_AbpPermissions_RoleId` (`RoleId`) USING BTREE ,
INDEX `IX_AbpPermissions_UserId` (`UserId`) USING BTREE 
)
ENGINE=InnoDB
DEFAULT CHARACTER SET=utf8 COLLATE=utf8_general_ci
AUTO_INCREMENT=1

;

-- ----------------------------
-- Records of abppermissions
-- ----------------------------
BEGIN;
COMMIT;

-- ----------------------------
-- Table structure for abproleclaims
-- ----------------------------
DROP TABLE IF EXISTS `abproleclaims`;
CREATE TABLE `abproleclaims` (
`Id`  bigint(20) NOT NULL AUTO_INCREMENT ,
`CreationTime`  datetime(6) NOT NULL ,
`CreatorUserId`  bigint(20) NULL DEFAULT NULL ,
`TenantId`  int(11) NULL DEFAULT NULL ,
`RoleId`  int(11) NOT NULL ,
`ClaimType`  varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL ,
`ClaimValue`  longtext CHARACTER SET utf8 COLLATE utf8_general_ci NULL ,
PRIMARY KEY (`Id`),
FOREIGN KEY (`RoleId`) REFERENCES `abproles` (`Id`) ON DELETE CASCADE ON UPDATE RESTRICT,
INDEX `IX_AbpRoleClaims_RoleId` (`RoleId`) USING BTREE ,
INDEX `IX_AbpRoleClaims_TenantId_ClaimType` (`TenantId`, `ClaimType`) USING BTREE 
)
ENGINE=InnoDB
DEFAULT CHARACTER SET=utf8 COLLATE=utf8_general_ci
AUTO_INCREMENT=1

;

-- ----------------------------
-- Records of abproleclaims
-- ----------------------------
BEGIN;
COMMIT;

-- ----------------------------
-- Table structure for abproles
-- ----------------------------
DROP TABLE IF EXISTS `abproles`;
CREATE TABLE `abproles` (
`Id`  int(11) NOT NULL AUTO_INCREMENT ,
`CreationTime`  datetime(6) NOT NULL ,
`CreatorUserId`  bigint(20) NULL DEFAULT NULL ,
`LastModificationTime`  datetime(6) NULL DEFAULT NULL ,
`LastModifierUserId`  bigint(20) NULL DEFAULT NULL ,
`IsDeleted`  bit(1) NOT NULL ,
`DeleterUserId`  bigint(20) NULL DEFAULT NULL ,
`DeletionTime`  datetime(6) NULL DEFAULT NULL ,
`TenantId`  int(11) NULL DEFAULT NULL ,
`Name`  varchar(32) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL ,
`DisplayName`  varchar(64) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL ,
`IsStatic`  bit(1) NOT NULL ,
`IsDefault`  bit(1) NOT NULL ,
`NormalizedName`  varchar(32) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL ,
`ConcurrencyStamp`  varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL ,
`Description`  longtext CHARACTER SET utf8 COLLATE utf8_general_ci NULL ,
PRIMARY KEY (`Id`),
FOREIGN KEY (`CreatorUserId`) REFERENCES `abpusers` (`Id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
FOREIGN KEY (`DeleterUserId`) REFERENCES `abpusers` (`Id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
FOREIGN KEY (`LastModifierUserId`) REFERENCES `abpusers` (`Id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
INDEX `IX_AbpRoles_CreatorUserId` (`CreatorUserId`) USING BTREE ,
INDEX `IX_AbpRoles_DeleterUserId` (`DeleterUserId`) USING BTREE ,
INDEX `IX_AbpRoles_LastModifierUserId` (`LastModifierUserId`) USING BTREE ,
INDEX `IX_AbpRoles_TenantId_NormalizedName` (`TenantId`, `NormalizedName`) USING BTREE 
)
ENGINE=InnoDB
DEFAULT CHARACTER SET=utf8 COLLATE=utf8_general_ci
AUTO_INCREMENT=1

;

-- ----------------------------
-- Records of abproles
-- ----------------------------
BEGIN;
COMMIT;

-- ----------------------------
-- Table structure for abpsettings
-- ----------------------------
DROP TABLE IF EXISTS `abpsettings`;
CREATE TABLE `abpsettings` (
`Id`  bigint(20) NOT NULL AUTO_INCREMENT ,
`CreationTime`  datetime(6) NOT NULL ,
`CreatorUserId`  bigint(20) NULL DEFAULT NULL ,
`LastModificationTime`  datetime(6) NULL DEFAULT NULL ,
`LastModifierUserId`  bigint(20) NULL DEFAULT NULL ,
`TenantId`  int(11) NULL DEFAULT NULL ,
`UserId`  bigint(20) NULL DEFAULT NULL ,
`Name`  varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL ,
`Value`  varchar(2000) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL ,
PRIMARY KEY (`Id`),
FOREIGN KEY (`UserId`) REFERENCES `abpusers` (`Id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
INDEX `IX_AbpSettings_UserId` (`UserId`) USING BTREE ,
INDEX `IX_AbpSettings_TenantId_Name` (`TenantId`, `Name`) USING BTREE 
)
ENGINE=InnoDB
DEFAULT CHARACTER SET=utf8 COLLATE=utf8_general_ci
AUTO_INCREMENT=1

;

-- ----------------------------
-- Records of abpsettings
-- ----------------------------
BEGIN;
COMMIT;

-- ----------------------------
-- Table structure for abptenantnotifications
-- ----------------------------
DROP TABLE IF EXISTS `abptenantnotifications`;
CREATE TABLE `abptenantnotifications` (
`Id`  char(36) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL ,
`CreationTime`  datetime(6) NOT NULL ,
`CreatorUserId`  bigint(20) NULL DEFAULT NULL ,
`TenantId`  int(11) NULL DEFAULT NULL ,
`NotificationName`  varchar(96) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL ,
`Data`  longtext CHARACTER SET utf8 COLLATE utf8_general_ci NULL ,
`DataTypeName`  varchar(512) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL ,
`EntityTypeName`  varchar(250) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL ,
`EntityTypeAssemblyQualifiedName`  varchar(512) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL ,
`EntityId`  varchar(96) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL ,
`Severity`  tinyint(3) UNSIGNED NOT NULL ,
PRIMARY KEY (`Id`),
INDEX `IX_AbpTenantNotifications_TenantId` (`TenantId`) USING BTREE 
)
ENGINE=InnoDB
DEFAULT CHARACTER SET=utf8 COLLATE=utf8_general_ci

;

-- ----------------------------
-- Records of abptenantnotifications
-- ----------------------------
BEGIN;
COMMIT;

-- ----------------------------
-- Table structure for abptenants
-- ----------------------------
DROP TABLE IF EXISTS `abptenants`;
CREATE TABLE `abptenants` (
`Id`  int(11) NOT NULL AUTO_INCREMENT ,
`CreationTime`  datetime(6) NOT NULL ,
`CreatorUserId`  bigint(20) NULL DEFAULT NULL ,
`LastModificationTime`  datetime(6) NULL DEFAULT NULL ,
`LastModifierUserId`  bigint(20) NULL DEFAULT NULL ,
`IsDeleted`  bit(1) NOT NULL ,
`DeleterUserId`  bigint(20) NULL DEFAULT NULL ,
`DeletionTime`  datetime(6) NULL DEFAULT NULL ,
`TenancyName`  varchar(64) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL ,
`Name`  varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL ,
`ConnectionString`  varchar(1024) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL ,
`IsActive`  bit(1) NOT NULL ,
`EditionId`  int(11) NULL DEFAULT NULL ,
PRIMARY KEY (`Id`),
FOREIGN KEY (`EditionId`) REFERENCES `abpeditions` (`Id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
FOREIGN KEY (`CreatorUserId`) REFERENCES `abpusers` (`Id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
FOREIGN KEY (`DeleterUserId`) REFERENCES `abpusers` (`Id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
FOREIGN KEY (`LastModifierUserId`) REFERENCES `abpusers` (`Id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
INDEX `IX_AbpTenants_CreatorUserId` (`CreatorUserId`) USING BTREE ,
INDEX `IX_AbpTenants_DeleterUserId` (`DeleterUserId`) USING BTREE ,
INDEX `IX_AbpTenants_EditionId` (`EditionId`) USING BTREE ,
INDEX `IX_AbpTenants_LastModifierUserId` (`LastModifierUserId`) USING BTREE ,
INDEX `IX_AbpTenants_TenancyName` (`TenancyName`) USING BTREE 
)
ENGINE=InnoDB
DEFAULT CHARACTER SET=utf8 COLLATE=utf8_general_ci
AUTO_INCREMENT=1

;

-- ----------------------------
-- Records of abptenants
-- ----------------------------
BEGIN;
COMMIT;

-- ----------------------------
-- Table structure for abpuseraccounts
-- ----------------------------
DROP TABLE IF EXISTS `abpuseraccounts`;
CREATE TABLE `abpuseraccounts` (
`Id`  bigint(20) NOT NULL AUTO_INCREMENT ,
`CreationTime`  datetime(6) NOT NULL ,
`CreatorUserId`  bigint(20) NULL DEFAULT NULL ,
`LastModificationTime`  datetime(6) NULL DEFAULT NULL ,
`LastModifierUserId`  bigint(20) NULL DEFAULT NULL ,
`IsDeleted`  bit(1) NOT NULL ,
`DeleterUserId`  bigint(20) NULL DEFAULT NULL ,
`DeletionTime`  datetime(6) NULL DEFAULT NULL ,
`TenantId`  int(11) NULL DEFAULT NULL ,
`UserId`  bigint(20) NOT NULL ,
`UserLinkId`  bigint(20) NULL DEFAULT NULL ,
`UserName`  varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL ,
`EmailAddress`  varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL ,
PRIMARY KEY (`Id`),
INDEX `IX_AbpUserAccounts_EmailAddress` (`EmailAddress`) USING BTREE ,
INDEX `IX_AbpUserAccounts_UserName` (`UserName`) USING BTREE ,
INDEX `IX_AbpUserAccounts_TenantId_EmailAddress` (`TenantId`, `EmailAddress`) USING BTREE ,
INDEX `IX_AbpUserAccounts_TenantId_UserId` (`TenantId`, `UserId`) USING BTREE ,
INDEX `IX_AbpUserAccounts_TenantId_UserName` (`TenantId`, `UserName`) USING BTREE 
)
ENGINE=InnoDB
DEFAULT CHARACTER SET=utf8 COLLATE=utf8_general_ci
AUTO_INCREMENT=1

;

-- ----------------------------
-- Records of abpuseraccounts
-- ----------------------------
BEGIN;
COMMIT;

-- ----------------------------
-- Table structure for abpuserclaims
-- ----------------------------
DROP TABLE IF EXISTS `abpuserclaims`;
CREATE TABLE `abpuserclaims` (
`Id`  bigint(20) NOT NULL AUTO_INCREMENT ,
`CreationTime`  datetime(6) NOT NULL ,
`CreatorUserId`  bigint(20) NULL DEFAULT NULL ,
`TenantId`  int(11) NULL DEFAULT NULL ,
`UserId`  bigint(20) NOT NULL ,
`ClaimType`  varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL ,
`ClaimValue`  longtext CHARACTER SET utf8 COLLATE utf8_general_ci NULL ,
PRIMARY KEY (`Id`),
FOREIGN KEY (`UserId`) REFERENCES `abpusers` (`Id`) ON DELETE CASCADE ON UPDATE RESTRICT,
INDEX `IX_AbpUserClaims_UserId` (`UserId`) USING BTREE ,
INDEX `IX_AbpUserClaims_TenantId_ClaimType` (`TenantId`, `ClaimType`) USING BTREE 
)
ENGINE=InnoDB
DEFAULT CHARACTER SET=utf8 COLLATE=utf8_general_ci
AUTO_INCREMENT=1

;

-- ----------------------------
-- Records of abpuserclaims
-- ----------------------------
BEGIN;
COMMIT;

-- ----------------------------
-- Table structure for abpuserloginattempts
-- ----------------------------
DROP TABLE IF EXISTS `abpuserloginattempts`;
CREATE TABLE `abpuserloginattempts` (
`Id`  bigint(20) NOT NULL AUTO_INCREMENT ,
`TenantId`  int(11) NULL DEFAULT NULL ,
`TenancyName`  varchar(64) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL ,
`UserId`  bigint(20) NULL DEFAULT NULL ,
`UserNameOrEmailAddress`  varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL ,
`ClientIpAddress`  varchar(64) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL ,
`ClientName`  varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL ,
`BrowserInfo`  varchar(512) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL ,
`Result`  tinyint(3) UNSIGNED NOT NULL ,
`CreationTime`  datetime(6) NOT NULL ,
PRIMARY KEY (`Id`),
INDEX `IX_AbpUserLoginAttempts_UserId_TenantId` (`UserId`, `TenantId`) USING BTREE ,
INDEX `IX_AbpUserLoginAttempts_TenancyName_UserNameOrEmailAddress_Resu~` (`TenancyName`, `UserNameOrEmailAddress`, `Result`) USING BTREE 
)
ENGINE=InnoDB
DEFAULT CHARACTER SET=utf8 COLLATE=utf8_general_ci
AUTO_INCREMENT=1

;

-- ----------------------------
-- Records of abpuserloginattempts
-- ----------------------------
BEGIN;
COMMIT;

-- ----------------------------
-- Table structure for abpuserlogins
-- ----------------------------
DROP TABLE IF EXISTS `abpuserlogins`;
CREATE TABLE `abpuserlogins` (
`Id`  bigint(20) NOT NULL AUTO_INCREMENT ,
`TenantId`  int(11) NULL DEFAULT NULL ,
`UserId`  bigint(20) NOT NULL ,
`LoginProvider`  varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL ,
`ProviderKey`  varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL ,
PRIMARY KEY (`Id`),
FOREIGN KEY (`UserId`) REFERENCES `abpusers` (`Id`) ON DELETE CASCADE ON UPDATE RESTRICT,
INDEX `IX_AbpUserLogins_UserId` (`UserId`) USING BTREE ,
INDEX `IX_AbpUserLogins_TenantId_UserId` (`TenantId`, `UserId`) USING BTREE ,
INDEX `IX_AbpUserLogins_TenantId_LoginProvider_ProviderKey` (`TenantId`, `LoginProvider`, `ProviderKey`) USING BTREE 
)
ENGINE=InnoDB
DEFAULT CHARACTER SET=utf8 COLLATE=utf8_general_ci
AUTO_INCREMENT=1

;

-- ----------------------------
-- Records of abpuserlogins
-- ----------------------------
BEGIN;
COMMIT;

-- ----------------------------
-- Table structure for abpusernotifications
-- ----------------------------
DROP TABLE IF EXISTS `abpusernotifications`;
CREATE TABLE `abpusernotifications` (
`Id`  char(36) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL ,
`TenantId`  int(11) NULL DEFAULT NULL ,
`UserId`  bigint(20) NOT NULL ,
`TenantNotificationId`  char(36) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL ,
`State`  int(11) NOT NULL ,
`CreationTime`  datetime(6) NOT NULL ,
PRIMARY KEY (`Id`),
INDEX `IX_AbpUserNotifications_UserId_State_CreationTime` (`UserId`, `State`, `CreationTime`) USING BTREE 
)
ENGINE=InnoDB
DEFAULT CHARACTER SET=utf8 COLLATE=utf8_general_ci

;

-- ----------------------------
-- Records of abpusernotifications
-- ----------------------------
BEGIN;
COMMIT;

-- ----------------------------
-- Table structure for abpuserorganizationunits
-- ----------------------------
DROP TABLE IF EXISTS `abpuserorganizationunits`;
CREATE TABLE `abpuserorganizationunits` (
`Id`  bigint(20) NOT NULL AUTO_INCREMENT ,
`CreationTime`  datetime(6) NOT NULL ,
`CreatorUserId`  bigint(20) NULL DEFAULT NULL ,
`TenantId`  int(11) NULL DEFAULT NULL ,
`UserId`  bigint(20) NOT NULL ,
`OrganizationUnitId`  bigint(20) NOT NULL ,
`IsDeleted`  bit(1) NOT NULL ,
PRIMARY KEY (`Id`),
INDEX `IX_AbpUserOrganizationUnits_TenantId_OrganizationUnitId` (`TenantId`, `OrganizationUnitId`) USING BTREE ,
INDEX `IX_AbpUserOrganizationUnits_TenantId_UserId` (`TenantId`, `UserId`) USING BTREE 
)
ENGINE=InnoDB
DEFAULT CHARACTER SET=utf8 COLLATE=utf8_general_ci
AUTO_INCREMENT=1

;

-- ----------------------------
-- Records of abpuserorganizationunits
-- ----------------------------
BEGIN;
COMMIT;

-- ----------------------------
-- Table structure for abpuserroles
-- ----------------------------
DROP TABLE IF EXISTS `abpuserroles`;
CREATE TABLE `abpuserroles` (
`Id`  bigint(20) NOT NULL AUTO_INCREMENT ,
`CreationTime`  datetime(6) NOT NULL ,
`CreatorUserId`  bigint(20) NULL DEFAULT NULL ,
`TenantId`  int(11) NULL DEFAULT NULL ,
`UserId`  bigint(20) NOT NULL ,
`RoleId`  int(11) NOT NULL ,
PRIMARY KEY (`Id`),
FOREIGN KEY (`UserId`) REFERENCES `abpusers` (`Id`) ON DELETE CASCADE ON UPDATE RESTRICT,
INDEX `IX_AbpUserRoles_UserId` (`UserId`) USING BTREE ,
INDEX `IX_AbpUserRoles_TenantId_RoleId` (`TenantId`, `RoleId`) USING BTREE ,
INDEX `IX_AbpUserRoles_TenantId_UserId` (`TenantId`, `UserId`) USING BTREE 
)
ENGINE=InnoDB
DEFAULT CHARACTER SET=utf8 COLLATE=utf8_general_ci
AUTO_INCREMENT=1

;

-- ----------------------------
-- Records of abpuserroles
-- ----------------------------
BEGIN;
COMMIT;

-- ----------------------------
-- Table structure for abpusers
-- ----------------------------
DROP TABLE IF EXISTS `abpusers`;
CREATE TABLE `abpusers` (
`Id`  bigint(20) NOT NULL AUTO_INCREMENT ,
`CreationTime`  datetime(6) NOT NULL ,
`CreatorUserId`  bigint(20) NULL DEFAULT NULL ,
`LastModificationTime`  datetime(6) NULL DEFAULT NULL ,
`LastModifierUserId`  bigint(20) NULL DEFAULT NULL ,
`IsDeleted`  bit(1) NOT NULL ,
`DeleterUserId`  bigint(20) NULL DEFAULT NULL ,
`DeletionTime`  datetime(6) NULL DEFAULT NULL ,
`AuthenticationSource`  varchar(64) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL ,
`UserName`  varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL ,
`TenantId`  int(11) NULL DEFAULT NULL ,
`EmailAddress`  varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL ,
`Name`  varchar(64) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL ,
`Surname`  varchar(64) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL ,
`Password`  varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL ,
`EmailConfirmationCode`  varchar(328) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL ,
`PasswordResetCode`  varchar(328) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL ,
`LockoutEndDateUtc`  datetime(6) NULL DEFAULT NULL ,
`AccessFailedCount`  int(11) NOT NULL ,
`IsLockoutEnabled`  bit(1) NOT NULL ,
`PhoneNumber`  varchar(32) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL ,
`IsPhoneNumberConfirmed`  bit(1) NOT NULL ,
`SecurityStamp`  varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL ,
`IsTwoFactorEnabled`  bit(1) NOT NULL ,
`IsEmailConfirmed`  bit(1) NOT NULL ,
`IsActive`  bit(1) NOT NULL ,
`NormalizedUserName`  varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL ,
`NormalizedEmailAddress`  varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL ,
`ConcurrencyStamp`  varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL ,
PRIMARY KEY (`Id`),
FOREIGN KEY (`CreatorUserId`) REFERENCES `abpusers` (`Id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
FOREIGN KEY (`DeleterUserId`) REFERENCES `abpusers` (`Id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
FOREIGN KEY (`LastModifierUserId`) REFERENCES `abpusers` (`Id`) ON DELETE RESTRICT ON UPDATE RESTRICT,
INDEX `IX_AbpUsers_CreatorUserId` (`CreatorUserId`) USING BTREE ,
INDEX `IX_AbpUsers_DeleterUserId` (`DeleterUserId`) USING BTREE ,
INDEX `IX_AbpUsers_LastModifierUserId` (`LastModifierUserId`) USING BTREE ,
INDEX `IX_AbpUsers_TenantId_NormalizedEmailAddress` (`TenantId`, `NormalizedEmailAddress`) USING BTREE ,
INDEX `IX_AbpUsers_TenantId_NormalizedUserName` (`TenantId`, `NormalizedUserName`) USING BTREE 
)
ENGINE=InnoDB
DEFAULT CHARACTER SET=utf8 COLLATE=utf8_general_ci
AUTO_INCREMENT=1

;

-- ----------------------------
-- Records of abpusers
-- ----------------------------
BEGIN;
COMMIT;

-- ----------------------------
-- Table structure for abpusertokens
-- ----------------------------
DROP TABLE IF EXISTS `abpusertokens`;
CREATE TABLE `abpusertokens` (
`Id`  bigint(20) NOT NULL AUTO_INCREMENT ,
`TenantId`  int(11) NULL DEFAULT NULL ,
`UserId`  bigint(20) NOT NULL ,
`LoginProvider`  varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL ,
`Name`  varchar(128) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL ,
`Value`  varchar(512) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL ,
`ExpireDate`  datetime(6) NULL DEFAULT NULL ,
PRIMARY KEY (`Id`),
FOREIGN KEY (`UserId`) REFERENCES `abpusers` (`Id`) ON DELETE CASCADE ON UPDATE RESTRICT,
INDEX `IX_AbpUserTokens_UserId` (`UserId`) USING BTREE ,
INDEX `IX_AbpUserTokens_TenantId_UserId` (`TenantId`, `UserId`) USING BTREE 
)
ENGINE=InnoDB
DEFAULT CHARACTER SET=utf8 COLLATE=utf8_general_ci
AUTO_INCREMENT=1

;

-- ----------------------------
-- Records of abpusertokens
-- ----------------------------
BEGIN;
COMMIT;

-- ----------------------------
-- Auto increment value for abpauditlogs
-- ----------------------------
ALTER TABLE `abpauditlogs` AUTO_INCREMENT=1;

-- ----------------------------
-- Auto increment value for abpbackgroundjobs
-- ----------------------------
ALTER TABLE `abpbackgroundjobs` AUTO_INCREMENT=1;

-- ----------------------------
-- Auto increment value for abpeditions
-- ----------------------------
ALTER TABLE `abpeditions` AUTO_INCREMENT=1;

-- ----------------------------
-- Auto increment value for abpentitychanges
-- ----------------------------
ALTER TABLE `abpentitychanges` AUTO_INCREMENT=1;

-- ----------------------------
-- Auto increment value for abpentitychangesets
-- ----------------------------
ALTER TABLE `abpentitychangesets` AUTO_INCREMENT=1;

-- ----------------------------
-- Auto increment value for abpentitypropertychanges
-- ----------------------------
ALTER TABLE `abpentitypropertychanges` AUTO_INCREMENT=1;

-- ----------------------------
-- Auto increment value for abpfeatures
-- ----------------------------
ALTER TABLE `abpfeatures` AUTO_INCREMENT=1;

-- ----------------------------
-- Auto increment value for abplanguages
-- ----------------------------
ALTER TABLE `abplanguages` AUTO_INCREMENT=1;

-- ----------------------------
-- Auto increment value for abplanguagetexts
-- ----------------------------
ALTER TABLE `abplanguagetexts` AUTO_INCREMENT=1;

-- ----------------------------
-- Auto increment value for abporganizationunitroles
-- ----------------------------
ALTER TABLE `abporganizationunitroles` AUTO_INCREMENT=1;

-- ----------------------------
-- Auto increment value for abporganizationunits
-- ----------------------------
ALTER TABLE `abporganizationunits` AUTO_INCREMENT=1;

-- ----------------------------
-- Auto increment value for abppermissions
-- ----------------------------
ALTER TABLE `abppermissions` AUTO_INCREMENT=1;

-- ----------------------------
-- Auto increment value for abproleclaims
-- ----------------------------
ALTER TABLE `abproleclaims` AUTO_INCREMENT=1;

-- ----------------------------
-- Auto increment value for abproles
-- ----------------------------
ALTER TABLE `abproles` AUTO_INCREMENT=1;

-- ----------------------------
-- Auto increment value for abpsettings
-- ----------------------------
ALTER TABLE `abpsettings` AUTO_INCREMENT=1;

-- ----------------------------
-- Auto increment value for abptenants
-- ----------------------------
ALTER TABLE `abptenants` AUTO_INCREMENT=1;

-- ----------------------------
-- Auto increment value for abpuseraccounts
-- ----------------------------
ALTER TABLE `abpuseraccounts` AUTO_INCREMENT=1;

-- ----------------------------
-- Auto increment value for abpuserclaims
-- ----------------------------
ALTER TABLE `abpuserclaims` AUTO_INCREMENT=1;

-- ----------------------------
-- Auto increment value for abpuserloginattempts
-- ----------------------------
ALTER TABLE `abpuserloginattempts` AUTO_INCREMENT=1;

-- ----------------------------
-- Auto increment value for abpuserlogins
-- ----------------------------
ALTER TABLE `abpuserlogins` AUTO_INCREMENT=1;

-- ----------------------------
-- Auto increment value for abpuserorganizationunits
-- ----------------------------
ALTER TABLE `abpuserorganizationunits` AUTO_INCREMENT=1;

-- ----------------------------
-- Auto increment value for abpuserroles
-- ----------------------------
ALTER TABLE `abpuserroles` AUTO_INCREMENT=1;

-- ----------------------------
-- Auto increment value for abpusers
-- ----------------------------
ALTER TABLE `abpusers` AUTO_INCREMENT=1;

-- ----------------------------
-- Auto increment value for abpusertokens
-- ----------------------------
ALTER TABLE `abpusertokens` AUTO_INCREMENT=1;
