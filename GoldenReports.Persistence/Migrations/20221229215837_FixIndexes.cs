using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoldenReports.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class FixIndexes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Namespace_Name",
                schema: "golden_reports",
                table: "namespace");

            migrationBuilder.DropIndex(
                name: "ix_namespace_parent_id",
                schema: "golden_reports",
                table: "namespace");

            migrationBuilder.DropIndex(
                name: "ix_data_source_namespace_id",
                schema: "golden_reports",
                table: "data_source");

            migrationBuilder.DropIndex(
                name: "ix_data_context_namespace_id",
                schema: "golden_reports",
                table: "data_context");

            migrationBuilder.DropIndex(
                name: "IX_DataContext_Name",
                schema: "golden_reports",
                table: "data_context");

            migrationBuilder.AlterColumn<string>(
                name: "schema",
                schema: "golden_reports",
                table: "data_context",
                type: "character varying(10000)",
                maxLength: 10000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.CreateIndex(
                name: "IX_Namespace_Name",
                schema: "golden_reports",
                table: "namespace",
                columns: new[] { "id_parent", "name" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DataSource_Name",
                schema: "golden_reports",
                table: "data_source",
                columns: new[] { "id_namespace", "name" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DataContext_Name",
                schema: "golden_reports",
                table: "data_context",
                columns: new[] { "id_namespace", "name" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Namespace_Name",
                schema: "golden_reports",
                table: "namespace");

            migrationBuilder.DropIndex(
                name: "IX_DataSource_Name",
                schema: "golden_reports",
                table: "data_source");

            migrationBuilder.DropIndex(
                name: "IX_DataContext_Name",
                schema: "golden_reports",
                table: "data_context");

            migrationBuilder.AlterColumn<string>(
                name: "schema",
                schema: "golden_reports",
                table: "data_context",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(10000)",
                oldMaxLength: 10000);

            migrationBuilder.CreateIndex(
                name: "IX_Namespace_Name",
                schema: "golden_reports",
                table: "namespace",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_namespace_parent_id",
                schema: "golden_reports",
                table: "namespace",
                column: "id_parent");

            migrationBuilder.CreateIndex(
                name: "ix_data_source_namespace_id",
                schema: "golden_reports",
                table: "data_source",
                column: "id_namespace");

            migrationBuilder.CreateIndex(
                name: "ix_data_context_namespace_id",
                schema: "golden_reports",
                table: "data_context",
                column: "id_namespace");

            migrationBuilder.CreateIndex(
                name: "IX_DataContext_Name",
                schema: "golden_reports",
                table: "data_context",
                column: "name",
                unique: true);
        }
    }
}
