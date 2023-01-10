using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoldenReports.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ReplaceAltKeysWithIndex : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "UK_ReportVariable_Name",
                schema: "golden_reports",
                table: "report_variable");

            migrationBuilder.DropUniqueConstraint(
                name: "UK_ReportSection_Name",
                schema: "golden_reports",
                table: "report_section");

            migrationBuilder.DropUniqueConstraint(
                name: "UK_ReportParameter_Name",
                schema: "golden_reports",
                table: "report_parameter");

            migrationBuilder.DropUniqueConstraint(
                name: "UK_ReportPage_Name",
                schema: "golden_reports",
                table: "report_page");

            migrationBuilder.DropUniqueConstraint(
                name: "UK_ReportDefinition_Name",
                schema: "golden_reports",
                table: "report_definition");

            migrationBuilder.DropUniqueConstraint(
                name: "UK_Namespace_Name",
                schema: "golden_reports",
                table: "namespace");

            migrationBuilder.DropUniqueConstraint(
                name: "UK_DataSource_Code",
                schema: "golden_reports",
                table: "data_source");

            migrationBuilder.DropUniqueConstraint(
                name: "UK_DataContext_Name",
                schema: "golden_reports",
                table: "data_context");

            migrationBuilder.CreateIndex(
                name: "UK_ReportVariable_Name",
                schema: "golden_reports",
                table: "report_variable",
                columns: new[] { "id_report", "name" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UK_ReportSection_Name",
                schema: "golden_reports",
                table: "report_section",
                columns: new[] { "id_page", "name" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UK_ReportParameter_Name",
                schema: "golden_reports",
                table: "report_parameter",
                columns: new[] { "id_report", "name" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UK_ReportPage_Name",
                schema: "golden_reports",
                table: "report_page",
                columns: new[] { "id_report", "name" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ReportDefinition_Name",
                schema: "golden_reports",
                table: "report_definition",
                columns: new[] { "id_namespace", "name" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Namespace_Name",
                schema: "golden_reports",
                table: "namespace",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DataSource_Code",
                schema: "golden_reports",
                table: "data_source",
                column: "code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DataContext_Name",
                schema: "golden_reports",
                table: "data_context",
                column: "name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "UK_ReportVariable_Name",
                schema: "golden_reports",
                table: "report_variable");

            migrationBuilder.DropIndex(
                name: "UK_ReportSection_Name",
                schema: "golden_reports",
                table: "report_section");

            migrationBuilder.DropIndex(
                name: "UK_ReportParameter_Name",
                schema: "golden_reports",
                table: "report_parameter");

            migrationBuilder.DropIndex(
                name: "UK_ReportPage_Name",
                schema: "golden_reports",
                table: "report_page");

            migrationBuilder.DropIndex(
                name: "IX_ReportDefinition_Name",
                schema: "golden_reports",
                table: "report_definition");

            migrationBuilder.DropIndex(
                name: "IX_Namespace_Name",
                schema: "golden_reports",
                table: "namespace");

            migrationBuilder.DropIndex(
                name: "IX_DataSource_Code",
                schema: "golden_reports",
                table: "data_source");

            migrationBuilder.DropIndex(
                name: "IX_DataContext_Name",
                schema: "golden_reports",
                table: "data_context");

            migrationBuilder.AddUniqueConstraint(
                name: "UK_ReportVariable_Name",
                schema: "golden_reports",
                table: "report_variable",
                columns: new[] { "id_report", "name" });

            migrationBuilder.AddUniqueConstraint(
                name: "UK_ReportSection_Name",
                schema: "golden_reports",
                table: "report_section",
                columns: new[] { "id_page", "name" });

            migrationBuilder.AddUniqueConstraint(
                name: "UK_ReportParameter_Name",
                schema: "golden_reports",
                table: "report_parameter",
                columns: new[] { "id_report", "name" });

            migrationBuilder.AddUniqueConstraint(
                name: "UK_ReportPage_Name",
                schema: "golden_reports",
                table: "report_page",
                columns: new[] { "id_report", "name" });

            migrationBuilder.AddUniqueConstraint(
                name: "UK_ReportDefinition_Name",
                schema: "golden_reports",
                table: "report_definition",
                columns: new[] { "id_namespace", "name" });

            migrationBuilder.AddUniqueConstraint(
                name: "UK_Namespace_Name",
                schema: "golden_reports",
                table: "namespace",
                column: "name");

            migrationBuilder.AddUniqueConstraint(
                name: "UK_DataSource_Code",
                schema: "golden_reports",
                table: "data_source",
                column: "code");

            migrationBuilder.AddUniqueConstraint(
                name: "UK_DataContext_Name",
                schema: "golden_reports",
                table: "data_context",
                column: "name");
        }
    }
}
