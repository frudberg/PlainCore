using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PlainCore.Infrastructure.Migrations
{
    public partial class UpgradeOpenIdDict : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_OpenIddictTokens_Hash",
                table: "OpenIddictTokens");

            migrationBuilder.DropIndex(
                name: "IX_OpenIddictApplications_ClientId",
                table: "OpenIddictApplications");

            migrationBuilder.RenameColumn(
                name: "Hash",
                table: "OpenIddictTokens",
                newName: "ReferenceId");

            migrationBuilder.RenameColumn(
                name: "Ciphertext",
                table: "OpenIddictTokens",
                newName: "Properties");

            migrationBuilder.RenameColumn(
                name: "Scope",
                table: "OpenIddictAuthorizations",
                newName: "Scopes");

            migrationBuilder.RenameColumn(
                name: "RedirectUri",
                table: "OpenIddictApplications",
                newName: "RedirectUris");

            migrationBuilder.RenameColumn(
                name: "LogoutRedirectUri",
                table: "OpenIddictApplications",
                newName: "Properties");

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "OpenIddictTokens",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Subject",
                table: "OpenIddictTokens",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyToken",
                table: "OpenIddictTokens",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Payload",
                table: "OpenIddictTokens",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyToken",
                table: "OpenIddictScopes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DisplayName",
                table: "OpenIddictScopes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "OpenIddictScopes",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Properties",
                table: "OpenIddictScopes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Resources",
                table: "OpenIddictScopes",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Subject",
                table: "OpenIddictAuthorizations",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "OpenIddictAuthorizations",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyToken",
                table: "OpenIddictAuthorizations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Properties",
                table: "OpenIddictAuthorizations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "OpenIddictAuthorizations",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "OpenIddictApplications",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ClientId",
                table: "OpenIddictApplications",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyToken",
                table: "OpenIddictApplications",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ConsentType",
                table: "OpenIddictApplications",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Permissions",
                table: "OpenIddictApplications",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PostLogoutRedirectUris",
                table: "OpenIddictApplications",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OpenIddictTokens_ReferenceId",
                table: "OpenIddictTokens",
                column: "ReferenceId",
                unique: true,
                filter: "[ReferenceId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_OpenIddictScopes_Name",
                table: "OpenIddictScopes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OpenIddictApplications_ClientId",
                table: "OpenIddictApplications",
                column: "ClientId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_OpenIddictTokens_ReferenceId",
                table: "OpenIddictTokens");

            migrationBuilder.DropIndex(
                name: "IX_OpenIddictScopes_Name",
                table: "OpenIddictScopes");

            migrationBuilder.DropIndex(
                name: "IX_OpenIddictApplications_ClientId",
                table: "OpenIddictApplications");

            migrationBuilder.DropColumn(
                name: "ConcurrencyToken",
                table: "OpenIddictTokens");

            migrationBuilder.DropColumn(
                name: "Payload",
                table: "OpenIddictTokens");

            migrationBuilder.DropColumn(
                name: "ConcurrencyToken",
                table: "OpenIddictScopes");

            migrationBuilder.DropColumn(
                name: "DisplayName",
                table: "OpenIddictScopes");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "OpenIddictScopes");

            migrationBuilder.DropColumn(
                name: "Properties",
                table: "OpenIddictScopes");

            migrationBuilder.DropColumn(
                name: "Resources",
                table: "OpenIddictScopes");

            migrationBuilder.DropColumn(
                name: "ConcurrencyToken",
                table: "OpenIddictAuthorizations");

            migrationBuilder.DropColumn(
                name: "Properties",
                table: "OpenIddictAuthorizations");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "OpenIddictAuthorizations");

            migrationBuilder.DropColumn(
                name: "ConcurrencyToken",
                table: "OpenIddictApplications");

            migrationBuilder.DropColumn(
                name: "ConsentType",
                table: "OpenIddictApplications");

            migrationBuilder.DropColumn(
                name: "Permissions",
                table: "OpenIddictApplications");

            migrationBuilder.DropColumn(
                name: "PostLogoutRedirectUris",
                table: "OpenIddictApplications");

            migrationBuilder.RenameColumn(
                name: "ReferenceId",
                table: "OpenIddictTokens",
                newName: "Hash");

            migrationBuilder.RenameColumn(
                name: "Properties",
                table: "OpenIddictTokens",
                newName: "Ciphertext");

            migrationBuilder.RenameColumn(
                name: "Scopes",
                table: "OpenIddictAuthorizations",
                newName: "Scope");

            migrationBuilder.RenameColumn(
                name: "RedirectUris",
                table: "OpenIddictApplications",
                newName: "RedirectUri");

            migrationBuilder.RenameColumn(
                name: "Properties",
                table: "OpenIddictApplications",
                newName: "LogoutRedirectUri");

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "OpenIddictTokens",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Subject",
                table: "OpenIddictTokens",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Subject",
                table: "OpenIddictAuthorizations",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "OpenIddictAuthorizations",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "OpenIddictApplications",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "ClientId",
                table: "OpenIddictApplications",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.CreateIndex(
                name: "IX_OpenIddictTokens_Hash",
                table: "OpenIddictTokens",
                column: "Hash",
                unique: true,
                filter: "[Hash] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_OpenIddictApplications_ClientId",
                table: "OpenIddictApplications",
                column: "ClientId",
                unique: true,
                filter: "[ClientId] IS NOT NULL");
        }
    }
}
