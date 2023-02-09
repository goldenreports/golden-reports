using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoldenReports.Persistence.PostgreSQL.Migrations
{
    /// <inheritdoc />
    public partial class MakeUserAuditingColumnsNotNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DataContext_User_CreatedBy",
                schema: "golden_reports",
                table: "data_context");

            migrationBuilder.DropForeignKey(
                name: "FK_DataContext_User_ModifiedBy",
                schema: "golden_reports",
                table: "data_context");

            migrationBuilder.DropForeignKey(
                name: "FK_DataSource_User_CreatedBy",
                schema: "golden_reports",
                table: "data_source");

            migrationBuilder.DropForeignKey(
                name: "FK_DataSource_User_ModifiedBy",
                schema: "golden_reports",
                table: "data_source");

            migrationBuilder.DropForeignKey(
                name: "FK_Namespace_User_CreatedBy",
                schema: "golden_reports",
                table: "namespace");

            migrationBuilder.DropForeignKey(
                name: "FK_Namespace_User_ModifiedBy",
                schema: "golden_reports",
                table: "namespace");

            migrationBuilder.DropForeignKey(
                name: "FK_NamespaceAsset_User_CreatedBy",
                schema: "golden_reports",
                table: "namespace_asset");

            migrationBuilder.DropForeignKey(
                name: "FK_NamespaceAsset_User_ModifiedBy",
                schema: "golden_reports",
                table: "namespace_asset");

            migrationBuilder.DropForeignKey(
                name: "fk_permission_users_created_by_id",
                table: "permission");

            migrationBuilder.DropForeignKey(
                name: "fk_permission_users_modified_by_id",
                table: "permission");

            migrationBuilder.DropForeignKey(
                name: "FK_ReportAsset_User_CreatedBy",
                schema: "golden_reports",
                table: "report_asset");

            migrationBuilder.DropForeignKey(
                name: "FK_ReportAsset_User_ModifiedBy",
                schema: "golden_reports",
                table: "report_asset");

            migrationBuilder.DropForeignKey(
                name: "FK_ReportDefinition_User_CreatedBy",
                schema: "golden_reports",
                table: "report_definition");

            migrationBuilder.DropForeignKey(
                name: "FK_ReportDefinition_User_ModifiedBy",
                schema: "golden_reports",
                table: "report_definition");

            migrationBuilder.DropForeignKey(
                name: "FK_ReportParameter_User_CreatedBy",
                schema: "golden_reports",
                table: "report_parameter");

            migrationBuilder.DropForeignKey(
                name: "FK_ReportParameter_User_ModifiedBy",
                schema: "golden_reports",
                table: "report_parameter");

            migrationBuilder.DropForeignKey(
                name: "FK_ReportVariable_User_CreatedBy",
                schema: "golden_reports",
                table: "report_variable");

            migrationBuilder.DropForeignKey(
                name: "FK_ReportVariable_User_ModifiedBy",
                schema: "golden_reports",
                table: "report_variable");

            migrationBuilder.DropForeignKey(
                name: "FK_User_User_CreatedBy",
                schema: "golden_reports",
                table: "user");

            migrationBuilder.DropForeignKey(
                name: "FK_User_User_ModifiedBy",
                schema: "golden_reports",
                table: "user");

            migrationBuilder.AlterColumn<Guid>(
                name: "id_modified_by",
                schema: "golden_reports",
                table: "user",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "id_created_by",
                schema: "golden_reports",
                table: "user",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "id_modified_by",
                schema: "golden_reports",
                table: "report_variable",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "id_created_by",
                schema: "golden_reports",
                table: "report_variable",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "id_modified_by",
                schema: "golden_reports",
                table: "report_parameter",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "id_created_by",
                schema: "golden_reports",
                table: "report_parameter",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "id_modified_by",
                schema: "golden_reports",
                table: "report_definition",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "id_created_by",
                schema: "golden_reports",
                table: "report_definition",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "id_modified_by",
                schema: "golden_reports",
                table: "report_asset",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "id_created_by",
                schema: "golden_reports",
                table: "report_asset",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "modified_by_id",
                table: "permission",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "created_by_id",
                table: "permission",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "id_modified_by",
                schema: "golden_reports",
                table: "namespace_asset",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "id_created_by",
                schema: "golden_reports",
                table: "namespace_asset",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "id_modified_by",
                schema: "golden_reports",
                table: "namespace",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "id_created_by",
                schema: "golden_reports",
                table: "namespace",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "id_modified_by",
                schema: "golden_reports",
                table: "data_source",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "id_created_by",
                schema: "golden_reports",
                table: "data_source",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "id_modified_by",
                schema: "golden_reports",
                table: "data_context",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "id_created_by",
                schema: "golden_reports",
                table: "data_context",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.UpdateData(
                schema: "golden_reports",
                table: "namespace",
                keyColumn: "id_namespace",
                keyValue: new Guid("745e002d-9b7b-452c-9f1e-bcd439bde28f"),
                columns: new[] { "id_created_by", "id_modified_by" },
                values: new object[] { new Guid("83a661ae-9e59-4777-b3ef-bf3586f7798e"), new Guid("83a661ae-9e59-4777-b3ef-bf3586f7798e") });

            migrationBuilder.UpdateData(
                schema: "golden_reports",
                table: "user",
                keyColumn: "id_user",
                keyValue: new Guid("83a661ae-9e59-4777-b3ef-bf3586f7798e"),
                columns: new[] { "id_created_by", "id_modified_by" },
                values: new object[] { new Guid("83a661ae-9e59-4777-b3ef-bf3586f7798e"), new Guid("83a661ae-9e59-4777-b3ef-bf3586f7798e") });

            migrationBuilder.AddForeignKey(
                name: "FK_DataContext_User_CreatedBy",
                schema: "golden_reports",
                table: "data_context",
                column: "id_created_by",
                principalSchema: "golden_reports",
                principalTable: "user",
                principalColumn: "id_user",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DataContext_User_ModifiedBy",
                schema: "golden_reports",
                table: "data_context",
                column: "id_modified_by",
                principalSchema: "golden_reports",
                principalTable: "user",
                principalColumn: "id_user",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DataSource_User_CreatedBy",
                schema: "golden_reports",
                table: "data_source",
                column: "id_created_by",
                principalSchema: "golden_reports",
                principalTable: "user",
                principalColumn: "id_user",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DataSource_User_ModifiedBy",
                schema: "golden_reports",
                table: "data_source",
                column: "id_modified_by",
                principalSchema: "golden_reports",
                principalTable: "user",
                principalColumn: "id_user",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Namespace_User_CreatedBy",
                schema: "golden_reports",
                table: "namespace",
                column: "id_created_by",
                principalSchema: "golden_reports",
                principalTable: "user",
                principalColumn: "id_user",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Namespace_User_ModifiedBy",
                schema: "golden_reports",
                table: "namespace",
                column: "id_modified_by",
                principalSchema: "golden_reports",
                principalTable: "user",
                principalColumn: "id_user",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NamespaceAsset_User_CreatedBy",
                schema: "golden_reports",
                table: "namespace_asset",
                column: "id_created_by",
                principalSchema: "golden_reports",
                principalTable: "user",
                principalColumn: "id_user",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NamespaceAsset_User_ModifiedBy",
                schema: "golden_reports",
                table: "namespace_asset",
                column: "id_modified_by",
                principalSchema: "golden_reports",
                principalTable: "user",
                principalColumn: "id_user",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_permission_users_created_by_id",
                table: "permission",
                column: "created_by_id",
                principalSchema: "golden_reports",
                principalTable: "user",
                principalColumn: "id_user",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_permission_users_modified_by_id",
                table: "permission",
                column: "modified_by_id",
                principalSchema: "golden_reports",
                principalTable: "user",
                principalColumn: "id_user",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReportAsset_User_CreatedBy",
                schema: "golden_reports",
                table: "report_asset",
                column: "id_created_by",
                principalSchema: "golden_reports",
                principalTable: "user",
                principalColumn: "id_user",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReportAsset_User_ModifiedBy",
                schema: "golden_reports",
                table: "report_asset",
                column: "id_modified_by",
                principalSchema: "golden_reports",
                principalTable: "user",
                principalColumn: "id_user",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReportDefinition_User_CreatedBy",
                schema: "golden_reports",
                table: "report_definition",
                column: "id_created_by",
                principalSchema: "golden_reports",
                principalTable: "user",
                principalColumn: "id_user",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReportDefinition_User_ModifiedBy",
                schema: "golden_reports",
                table: "report_definition",
                column: "id_modified_by",
                principalSchema: "golden_reports",
                principalTable: "user",
                principalColumn: "id_user",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReportParameter_User_CreatedBy",
                schema: "golden_reports",
                table: "report_parameter",
                column: "id_created_by",
                principalSchema: "golden_reports",
                principalTable: "user",
                principalColumn: "id_user",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReportParameter_User_ModifiedBy",
                schema: "golden_reports",
                table: "report_parameter",
                column: "id_modified_by",
                principalSchema: "golden_reports",
                principalTable: "user",
                principalColumn: "id_user",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReportVariable_User_CreatedBy",
                schema: "golden_reports",
                table: "report_variable",
                column: "id_created_by",
                principalSchema: "golden_reports",
                principalTable: "user",
                principalColumn: "id_user",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReportVariable_User_ModifiedBy",
                schema: "golden_reports",
                table: "report_variable",
                column: "id_modified_by",
                principalSchema: "golden_reports",
                principalTable: "user",
                principalColumn: "id_user",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_User_User_CreatedBy",
                schema: "golden_reports",
                table: "user",
                column: "id_created_by",
                principalSchema: "golden_reports",
                principalTable: "user",
                principalColumn: "id_user",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_User_User_ModifiedBy",
                schema: "golden_reports",
                table: "user",
                column: "id_modified_by",
                principalSchema: "golden_reports",
                principalTable: "user",
                principalColumn: "id_user",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DataContext_User_CreatedBy",
                schema: "golden_reports",
                table: "data_context");

            migrationBuilder.DropForeignKey(
                name: "FK_DataContext_User_ModifiedBy",
                schema: "golden_reports",
                table: "data_context");

            migrationBuilder.DropForeignKey(
                name: "FK_DataSource_User_CreatedBy",
                schema: "golden_reports",
                table: "data_source");

            migrationBuilder.DropForeignKey(
                name: "FK_DataSource_User_ModifiedBy",
                schema: "golden_reports",
                table: "data_source");

            migrationBuilder.DropForeignKey(
                name: "FK_Namespace_User_CreatedBy",
                schema: "golden_reports",
                table: "namespace");

            migrationBuilder.DropForeignKey(
                name: "FK_Namespace_User_ModifiedBy",
                schema: "golden_reports",
                table: "namespace");

            migrationBuilder.DropForeignKey(
                name: "FK_NamespaceAsset_User_CreatedBy",
                schema: "golden_reports",
                table: "namespace_asset");

            migrationBuilder.DropForeignKey(
                name: "FK_NamespaceAsset_User_ModifiedBy",
                schema: "golden_reports",
                table: "namespace_asset");

            migrationBuilder.DropForeignKey(
                name: "fk_permission_users_created_by_id",
                table: "permission");

            migrationBuilder.DropForeignKey(
                name: "fk_permission_users_modified_by_id",
                table: "permission");

            migrationBuilder.DropForeignKey(
                name: "FK_ReportAsset_User_CreatedBy",
                schema: "golden_reports",
                table: "report_asset");

            migrationBuilder.DropForeignKey(
                name: "FK_ReportAsset_User_ModifiedBy",
                schema: "golden_reports",
                table: "report_asset");

            migrationBuilder.DropForeignKey(
                name: "FK_ReportDefinition_User_CreatedBy",
                schema: "golden_reports",
                table: "report_definition");

            migrationBuilder.DropForeignKey(
                name: "FK_ReportDefinition_User_ModifiedBy",
                schema: "golden_reports",
                table: "report_definition");

            migrationBuilder.DropForeignKey(
                name: "FK_ReportParameter_User_CreatedBy",
                schema: "golden_reports",
                table: "report_parameter");

            migrationBuilder.DropForeignKey(
                name: "FK_ReportParameter_User_ModifiedBy",
                schema: "golden_reports",
                table: "report_parameter");

            migrationBuilder.DropForeignKey(
                name: "FK_ReportVariable_User_CreatedBy",
                schema: "golden_reports",
                table: "report_variable");

            migrationBuilder.DropForeignKey(
                name: "FK_ReportVariable_User_ModifiedBy",
                schema: "golden_reports",
                table: "report_variable");

            migrationBuilder.DropForeignKey(
                name: "FK_User_User_CreatedBy",
                schema: "golden_reports",
                table: "user");

            migrationBuilder.DropForeignKey(
                name: "FK_User_User_ModifiedBy",
                schema: "golden_reports",
                table: "user");

            migrationBuilder.AlterColumn<Guid>(
                name: "id_modified_by",
                schema: "golden_reports",
                table: "user",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "id_created_by",
                schema: "golden_reports",
                table: "user",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "id_modified_by",
                schema: "golden_reports",
                table: "report_variable",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "id_created_by",
                schema: "golden_reports",
                table: "report_variable",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "id_modified_by",
                schema: "golden_reports",
                table: "report_parameter",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "id_created_by",
                schema: "golden_reports",
                table: "report_parameter",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "id_modified_by",
                schema: "golden_reports",
                table: "report_definition",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "id_created_by",
                schema: "golden_reports",
                table: "report_definition",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "id_modified_by",
                schema: "golden_reports",
                table: "report_asset",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "id_created_by",
                schema: "golden_reports",
                table: "report_asset",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "modified_by_id",
                table: "permission",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "created_by_id",
                table: "permission",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "id_modified_by",
                schema: "golden_reports",
                table: "namespace_asset",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "id_created_by",
                schema: "golden_reports",
                table: "namespace_asset",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "id_modified_by",
                schema: "golden_reports",
                table: "namespace",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "id_created_by",
                schema: "golden_reports",
                table: "namespace",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "id_modified_by",
                schema: "golden_reports",
                table: "data_source",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "id_created_by",
                schema: "golden_reports",
                table: "data_source",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "id_modified_by",
                schema: "golden_reports",
                table: "data_context",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "id_created_by",
                schema: "golden_reports",
                table: "data_context",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.UpdateData(
                schema: "golden_reports",
                table: "namespace",
                keyColumn: "id_namespace",
                keyValue: new Guid("745e002d-9b7b-452c-9f1e-bcd439bde28f"),
                columns: new[] { "id_created_by", "id_modified_by" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                schema: "golden_reports",
                table: "user",
                keyColumn: "id_user",
                keyValue: new Guid("83a661ae-9e59-4777-b3ef-bf3586f7798e"),
                columns: new[] { "id_created_by", "id_modified_by" },
                values: new object[] { null, null });

            migrationBuilder.AddForeignKey(
                name: "FK_DataContext_User_CreatedBy",
                schema: "golden_reports",
                table: "data_context",
                column: "id_created_by",
                principalSchema: "golden_reports",
                principalTable: "user",
                principalColumn: "id_user");

            migrationBuilder.AddForeignKey(
                name: "FK_DataContext_User_ModifiedBy",
                schema: "golden_reports",
                table: "data_context",
                column: "id_modified_by",
                principalSchema: "golden_reports",
                principalTable: "user",
                principalColumn: "id_user");

            migrationBuilder.AddForeignKey(
                name: "FK_DataSource_User_CreatedBy",
                schema: "golden_reports",
                table: "data_source",
                column: "id_created_by",
                principalSchema: "golden_reports",
                principalTable: "user",
                principalColumn: "id_user");

            migrationBuilder.AddForeignKey(
                name: "FK_DataSource_User_ModifiedBy",
                schema: "golden_reports",
                table: "data_source",
                column: "id_modified_by",
                principalSchema: "golden_reports",
                principalTable: "user",
                principalColumn: "id_user");

            migrationBuilder.AddForeignKey(
                name: "FK_Namespace_User_CreatedBy",
                schema: "golden_reports",
                table: "namespace",
                column: "id_created_by",
                principalSchema: "golden_reports",
                principalTable: "user",
                principalColumn: "id_user");

            migrationBuilder.AddForeignKey(
                name: "FK_Namespace_User_ModifiedBy",
                schema: "golden_reports",
                table: "namespace",
                column: "id_modified_by",
                principalSchema: "golden_reports",
                principalTable: "user",
                principalColumn: "id_user");

            migrationBuilder.AddForeignKey(
                name: "FK_NamespaceAsset_User_CreatedBy",
                schema: "golden_reports",
                table: "namespace_asset",
                column: "id_created_by",
                principalSchema: "golden_reports",
                principalTable: "user",
                principalColumn: "id_user");

            migrationBuilder.AddForeignKey(
                name: "FK_NamespaceAsset_User_ModifiedBy",
                schema: "golden_reports",
                table: "namespace_asset",
                column: "id_modified_by",
                principalSchema: "golden_reports",
                principalTable: "user",
                principalColumn: "id_user");

            migrationBuilder.AddForeignKey(
                name: "fk_permission_users_created_by_id",
                table: "permission",
                column: "created_by_id",
                principalSchema: "golden_reports",
                principalTable: "user",
                principalColumn: "id_user");

            migrationBuilder.AddForeignKey(
                name: "fk_permission_users_modified_by_id",
                table: "permission",
                column: "modified_by_id",
                principalSchema: "golden_reports",
                principalTable: "user",
                principalColumn: "id_user");

            migrationBuilder.AddForeignKey(
                name: "FK_ReportAsset_User_CreatedBy",
                schema: "golden_reports",
                table: "report_asset",
                column: "id_created_by",
                principalSchema: "golden_reports",
                principalTable: "user",
                principalColumn: "id_user");

            migrationBuilder.AddForeignKey(
                name: "FK_ReportAsset_User_ModifiedBy",
                schema: "golden_reports",
                table: "report_asset",
                column: "id_modified_by",
                principalSchema: "golden_reports",
                principalTable: "user",
                principalColumn: "id_user");

            migrationBuilder.AddForeignKey(
                name: "FK_ReportDefinition_User_CreatedBy",
                schema: "golden_reports",
                table: "report_definition",
                column: "id_created_by",
                principalSchema: "golden_reports",
                principalTable: "user",
                principalColumn: "id_user");

            migrationBuilder.AddForeignKey(
                name: "FK_ReportDefinition_User_ModifiedBy",
                schema: "golden_reports",
                table: "report_definition",
                column: "id_modified_by",
                principalSchema: "golden_reports",
                principalTable: "user",
                principalColumn: "id_user");

            migrationBuilder.AddForeignKey(
                name: "FK_ReportParameter_User_CreatedBy",
                schema: "golden_reports",
                table: "report_parameter",
                column: "id_created_by",
                principalSchema: "golden_reports",
                principalTable: "user",
                principalColumn: "id_user");

            migrationBuilder.AddForeignKey(
                name: "FK_ReportParameter_User_ModifiedBy",
                schema: "golden_reports",
                table: "report_parameter",
                column: "id_modified_by",
                principalSchema: "golden_reports",
                principalTable: "user",
                principalColumn: "id_user");

            migrationBuilder.AddForeignKey(
                name: "FK_ReportVariable_User_CreatedBy",
                schema: "golden_reports",
                table: "report_variable",
                column: "id_created_by",
                principalSchema: "golden_reports",
                principalTable: "user",
                principalColumn: "id_user");

            migrationBuilder.AddForeignKey(
                name: "FK_ReportVariable_User_ModifiedBy",
                schema: "golden_reports",
                table: "report_variable",
                column: "id_modified_by",
                principalSchema: "golden_reports",
                principalTable: "user",
                principalColumn: "id_user");

            migrationBuilder.AddForeignKey(
                name: "FK_User_User_CreatedBy",
                schema: "golden_reports",
                table: "user",
                column: "id_created_by",
                principalSchema: "golden_reports",
                principalTable: "user",
                principalColumn: "id_user");

            migrationBuilder.AddForeignKey(
                name: "FK_User_User_ModifiedBy",
                schema: "golden_reports",
                table: "user",
                column: "id_modified_by",
                principalSchema: "golden_reports",
                principalTable: "user",
                principalColumn: "id_user");
        }
    }
}
