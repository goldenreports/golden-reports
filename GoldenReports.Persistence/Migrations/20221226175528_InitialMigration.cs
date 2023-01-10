using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoldenReports.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "golden_reports");

            migrationBuilder.CreateTable(
                name: "namespace",
                schema: "golden_reports",
                columns: table => new
                {
                    idnamespace = table.Column<Guid>(name: "id_namespace", type: "uuid", nullable: false),
                    idparent = table.Column<Guid>(name: "id_parent", type: "uuid", nullable: true),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    description = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    creationdate = table.Column<DateTime>(name: "creation_date", type: "timestamp with time zone", nullable: false),
                    modificationdate = table.Column<DateTime>(name: "modification_date", type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Namespace", x => x.idnamespace);
                    table.UniqueConstraint("UK_Namespace_Name", x => x.name);
                    table.ForeignKey(
                        name: "FK_Namespace_Namespace",
                        column: x => x.idparent,
                        principalSchema: "golden_reports",
                        principalTable: "namespace",
                        principalColumn: "id_namespace");
                });

            migrationBuilder.CreateTable(
                name: "data_context",
                schema: "golden_reports",
                columns: table => new
                {
                    iddatacontext = table.Column<Guid>(name: "id_data_context", type: "uuid", nullable: false),
                    idnamespace = table.Column<Guid>(name: "id_namespace", type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    schema = table.Column<string>(type: "text", nullable: false),
                    creationdate = table.Column<DateTime>(name: "creation_date", type: "timestamp with time zone", nullable: false),
                    modificationdate = table.Column<DateTime>(name: "modification_date", type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataContext", x => x.iddatacontext);
                    table.UniqueConstraint("UK_DataContext_Name", x => x.name);
                    table.ForeignKey(
                        name: "FK_DataContext_Namespace",
                        column: x => x.idnamespace,
                        principalSchema: "golden_reports",
                        principalTable: "namespace",
                        principalColumn: "id_namespace",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "data_source",
                schema: "golden_reports",
                columns: table => new
                {
                    iddatasource = table.Column<Guid>(name: "id_data_source", type: "uuid", nullable: false),
                    idnamespace = table.Column<Guid>(name: "id_namespace", type: "uuid", nullable: false),
                    code = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    description = table.Column<string>(type: "character varying(750)", maxLength: 750, nullable: true),
                    connectionstring = table.Column<string>(name: "connection_string", type: "character varying(750)", maxLength: 750, nullable: false),
                    creationdate = table.Column<DateTime>(name: "creation_date", type: "timestamp with time zone", nullable: false),
                    modificationdate = table.Column<DateTime>(name: "modification_date", type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataSource", x => x.iddatasource);
                    table.UniqueConstraint("UK_DataSource_Code", x => x.code);
                    table.ForeignKey(
                        name: "FK_DataSource_Namespace",
                        column: x => x.idnamespace,
                        principalSchema: "golden_reports",
                        principalTable: "namespace",
                        principalColumn: "id_namespace",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "namespace_asset",
                schema: "golden_reports",
                columns: table => new
                {
                    idnamespaceasset = table.Column<Guid>(name: "id_namespace_asset", type: "uuid", nullable: false),
                    idnamespace = table.Column<Guid>(name: "id_namespace", type: "uuid", nullable: false),
                    creationdate = table.Column<DateTime>(name: "creation_date", type: "timestamp with time zone", nullable: false),
                    modificationdate = table.Column<DateTime>(name: "modification_date", type: "timestamp with time zone", nullable: false),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    path = table.Column<string>(type: "character varying(750)", maxLength: 750, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NamespaceAsset", x => x.idnamespaceasset);
                    table.UniqueConstraint("UK_NamespaceAsset_Name", x => new { x.idnamespace, x.name });
                    table.ForeignKey(
                        name: "FK_NamespaceAsset_Namespace",
                        column: x => x.idnamespace,
                        principalSchema: "golden_reports",
                        principalTable: "namespace",
                        principalColumn: "id_namespace",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "permission",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    namespaceid = table.Column<Guid>(name: "namespace_id", type: "uuid", nullable: true),
                    creationdate = table.Column<DateTime>(name: "creation_date", type: "timestamp with time zone", nullable: false),
                    modificationdate = table.Column<DateTime>(name: "modification_date", type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_permission", x => x.id);
                    table.ForeignKey(
                        name: "fk_permission_namespaces_namespace_id",
                        column: x => x.namespaceid,
                        principalSchema: "golden_reports",
                        principalTable: "namespace",
                        principalColumn: "id_namespace");
                });

            migrationBuilder.CreateTable(
                name: "report_definition",
                schema: "golden_reports",
                columns: table => new
                {
                    idreportdefinition = table.Column<Guid>(name: "id_report_definition", type: "uuid", nullable: false),
                    idnamespace = table.Column<Guid>(name: "id_namespace", type: "uuid", nullable: false),
                    idparent = table.Column<Guid>(name: "id_parent", type: "uuid", nullable: true),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    description = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    query = table.Column<string>(type: "character varying(2500)", maxLength: 2500, nullable: true),
                    styles = table.Column<string>(type: "character varying(2500)", maxLength: 2500, nullable: true),
                    creationdate = table.Column<DateTime>(name: "creation_date", type: "timestamp with time zone", nullable: false),
                    modificationdate = table.Column<DateTime>(name: "modification_date", type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportDefinition", x => x.idreportdefinition);
                    table.UniqueConstraint("UK_ReportDefinition_Name", x => new { x.idnamespace, x.name });
                    table.ForeignKey(
                        name: "FK_ReportDefinition_Namespace",
                        column: x => x.idnamespace,
                        principalSchema: "golden_reports",
                        principalTable: "namespace",
                        principalColumn: "id_namespace",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReportDefinition_ReportDefinitionParent",
                        column: x => x.idparent,
                        principalSchema: "golden_reports",
                        principalTable: "report_definition",
                        principalColumn: "id_report_definition");
                });

            migrationBuilder.CreateTable(
                name: "report_asset",
                schema: "golden_reports",
                columns: table => new
                {
                    idreportasset = table.Column<Guid>(name: "id_report_asset", type: "uuid", nullable: false),
                    idreport = table.Column<Guid>(name: "id_report", type: "uuid", nullable: false),
                    creationdate = table.Column<DateTime>(name: "creation_date", type: "timestamp with time zone", nullable: false),
                    modificationdate = table.Column<DateTime>(name: "modification_date", type: "timestamp with time zone", nullable: false),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    path = table.Column<string>(type: "character varying(750)", maxLength: 750, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportAsset", x => x.idreportasset);
                    table.UniqueConstraint("UK_ReportAsset_Name", x => new { x.idreport, x.name });
                    table.ForeignKey(
                        name: "FK_ReportAsset_ReportDefinition",
                        column: x => x.idreport,
                        principalSchema: "golden_reports",
                        principalTable: "report_definition",
                        principalColumn: "id_report_definition",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "report_page",
                schema: "golden_reports",
                columns: table => new
                {
                    idreportpage = table.Column<Guid>(name: "id_report_page", type: "uuid", nullable: false),
                    idreport = table.Column<Guid>(name: "id_report", type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    query = table.Column<string>(type: "character varying(2500)", maxLength: 2500, nullable: true),
                    type = table.Column<int>(type: "integer", nullable: false),
                    pageconditionexpression = table.Column<string>(name: "page_condition_expression", type: "character varying(750)", maxLength: 750, nullable: true),
                    creationdate = table.Column<DateTime>(name: "creation_date", type: "timestamp with time zone", nullable: false),
                    modificationdate = table.Column<DateTime>(name: "modification_date", type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportPage", x => x.idreportpage);
                    table.UniqueConstraint("UK_ReportPage_Name", x => new { x.idreport, x.name });
                    table.ForeignKey(
                        name: "FK_ReportPage_ReportDefinition",
                        column: x => x.idreport,
                        principalSchema: "golden_reports",
                        principalTable: "report_definition",
                        principalColumn: "id_report_definition",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "report_parameter",
                schema: "golden_reports",
                columns: table => new
                {
                    idreportparameter = table.Column<Guid>(name: "id_report_parameter", type: "uuid", nullable: false),
                    idreport = table.Column<Guid>(name: "id_report", type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    type = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    required = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    defaultvalue = table.Column<string>(name: "default_value", type: "text", nullable: true),
                    creationdate = table.Column<DateTime>(name: "creation_date", type: "timestamp with time zone", nullable: false),
                    modificationdate = table.Column<DateTime>(name: "modification_date", type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportParameter", x => x.idreportparameter);
                    table.UniqueConstraint("UK_ReportParameter_Name", x => new { x.idreport, x.name });
                    table.ForeignKey(
                        name: "FK_ReportParameter_ReportDefinition",
                        column: x => x.idreport,
                        principalSchema: "golden_reports",
                        principalTable: "report_definition",
                        principalColumn: "id_report_definition",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "report_variable",
                schema: "golden_reports",
                columns: table => new
                {
                    idreportvariable = table.Column<Guid>(name: "id_report_variable", type: "uuid", nullable: false),
                    idreport = table.Column<Guid>(name: "id_report", type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    expression = table.Column<string>(type: "character varying(750)", maxLength: 750, nullable: false),
                    creationdate = table.Column<DateTime>(name: "creation_date", type: "timestamp with time zone", nullable: false),
                    modificationdate = table.Column<DateTime>(name: "modification_date", type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportVariable", x => x.idreportvariable);
                    table.UniqueConstraint("UK_ReportVariable_Name", x => new { x.idreport, x.name });
                    table.ForeignKey(
                        name: "FK_ReportVariable_ReportDefinition",
                        column: x => x.idreport,
                        principalSchema: "golden_reports",
                        principalTable: "report_definition",
                        principalColumn: "id_report_definition",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "report_section",
                schema: "golden_reports",
                columns: table => new
                {
                    idreportsection = table.Column<Guid>(name: "id_report_section", type: "uuid", nullable: false),
                    idpage = table.Column<Guid>(name: "id_page", type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    gridtemplate = table.Column<string>(name: "grid_template", type: "character varying(750)", maxLength: 750, nullable: false),
                    creationdate = table.Column<DateTime>(name: "creation_date", type: "timestamp with time zone", nullable: false),
                    modificationdate = table.Column<DateTime>(name: "modification_date", type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportSection", x => x.idreportsection);
                    table.UniqueConstraint("UK_ReportSection_Name", x => new { x.idpage, x.name });
                    table.ForeignKey(
                        name: "FK_ReportSection_ReportPage",
                        column: x => x.idpage,
                        principalSchema: "golden_reports",
                        principalTable: "report_page",
                        principalColumn: "id_report_page",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "report_element",
                schema: "golden_reports",
                columns: table => new
                {
                    idreportelement = table.Column<Guid>(name: "id_report_element", type: "uuid", nullable: false),
                    idsection = table.Column<Guid>(name: "id_section", type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    gridarea = table.Column<string>(name: "grid_area", type: "character varying(50)", maxLength: 50, nullable: false),
                    verticalalignment = table.Column<int>(name: "vertical_alignment", type: "integer", nullable: false, defaultValue: 0),
                    horizontalalignment = table.Column<int>(name: "horizontal_alignment", type: "integer", nullable: false, defaultValue: 0),
                    zindex = table.Column<int>(name: "z_index", type: "integer", nullable: false, defaultValue: 0),
                    creationdate = table.Column<DateTime>(name: "creation_date", type: "timestamp with time zone", nullable: false),
                    modificationdate = table.Column<DateTime>(name: "modification_date", type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportElement", x => x.idreportelement);
                    table.UniqueConstraint("UK_ReportElement_Name", x => new { x.idsection, x.name });
                    table.ForeignKey(
                        name: "FK_ReportElement_ReportSection",
                        column: x => x.idsection,
                        principalSchema: "golden_reports",
                        principalTable: "report_section",
                        principalColumn: "id_report_section",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "barcode_element",
                schema: "golden_reports",
                columns: table => new
                {
                    idreportelement = table.Column<Guid>(name: "id_report_element", type: "uuid", nullable: false),
                    value = table.Column<string>(type: "character varying(2500)", maxLength: 2500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BarcodeElement", x => x.idreportelement);
                    table.ForeignKey(
                        name: "fk_barcode_element_report_element_id_report_element",
                        column: x => x.idreportelement,
                        principalSchema: "golden_reports",
                        principalTable: "report_element",
                        principalColumn: "id_report_element",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "box_element",
                schema: "golden_reports",
                columns: table => new
                {
                    idreportelement = table.Column<Guid>(name: "id_report_element", type: "uuid", nullable: false),
                    backgroundcolor = table.Column<string>(name: "background_color", type: "character varying(50)", maxLength: 50, nullable: false),
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    leftbordercolor = table.Column<string>(name: "left_border_color", type: "character varying(50)", maxLength: 50, nullable: false),
                    leftborderthickness = table.Column<double>(name: "left_border_thickness", type: "double precision", nullable: false),
                    leftbordertype = table.Column<int>(name: "left_border_type", type: "integer", nullable: false),
                    topbordercolor = table.Column<string>(name: "top_border_color", type: "character varying(50)", maxLength: 50, nullable: false),
                    topborderthickness = table.Column<double>(name: "top_border_thickness", type: "double precision", nullable: false),
                    topbordertype = table.Column<int>(name: "top_border_type", type: "integer", nullable: false),
                    rightbordercolor = table.Column<string>(name: "right_border_color", type: "character varying(50)", maxLength: 50, nullable: false),
                    rightborderthickness = table.Column<double>(name: "right_border_thickness", type: "double precision", nullable: false),
                    rightbordertype = table.Column<int>(name: "right_border_type", type: "integer", nullable: false),
                    bottombordercolor = table.Column<string>(name: "bottom_border_color", type: "character varying(50)", maxLength: 50, nullable: false),
                    bottomborderthickness = table.Column<double>(name: "bottom_border_thickness", type: "double precision", nullable: false),
                    bottombordertype = table.Column<int>(name: "bottom_border_type", type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoxElement", x => x.idreportelement);
                    table.ForeignKey(
                        name: "fk_box_element_box_element_id",
                        column: x => x.id,
                        principalSchema: "golden_reports",
                        principalTable: "box_element",
                        principalColumn: "id_report_element",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_box_element_report_element_id_report_element",
                        column: x => x.idreportelement,
                        principalSchema: "golden_reports",
                        principalTable: "report_element",
                        principalColumn: "id_report_element",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "image_element",
                schema: "golden_reports",
                columns: table => new
                {
                    idreportelement = table.Column<Guid>(name: "id_report_element", type: "uuid", nullable: false),
                    assetname = table.Column<string>(name: "asset_name", type: "character varying(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageElement", x => x.idreportelement);
                    table.ForeignKey(
                        name: "fk_image_element_report_element_id_report_element",
                        column: x => x.idreportelement,
                        principalSchema: "golden_reports",
                        principalTable: "report_element",
                        principalColumn: "id_report_element",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "label_element",
                schema: "golden_reports",
                columns: table => new
                {
                    idreportelement = table.Column<Guid>(name: "id_report_element", type: "uuid", nullable: false),
                    text = table.Column<string>(type: "character varying(750)", maxLength: 750, nullable: false),
                    textcolor = table.Column<string>(name: "text_color", type: "character varying(50)", maxLength: 50, nullable: false),
                    textsize = table.Column<string>(name: "text_size", type: "character varying(50)", maxLength: 50, nullable: false),
                    backgroundcolor = table.Column<string>(name: "background_color", type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LabelElement", x => x.idreportelement);
                    table.ForeignKey(
                        name: "fk_label_element_report_element_id_report_element",
                        column: x => x.idreportelement,
                        principalSchema: "golden_reports",
                        principalTable: "report_element",
                        principalColumn: "id_report_element",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "list_element",
                schema: "golden_reports",
                columns: table => new
                {
                    idreportelement = table.Column<Guid>(name: "id_report_element", type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListElement", x => x.idreportelement);
                    table.ForeignKey(
                        name: "fk_list_element_report_element_id_report_element",
                        column: x => x.idreportelement,
                        principalSchema: "golden_reports",
                        principalTable: "report_element",
                        principalColumn: "id_report_element",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "sub_report_element",
                schema: "golden_reports",
                columns: table => new
                {
                    idreportelement = table.Column<Guid>(name: "id_report_element", type: "uuid", nullable: false),
                    path = table.Column<string>(type: "character varying(750)", maxLength: 750, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubReportElement", x => x.idreportelement);
                    table.ForeignKey(
                        name: "fk_sub_report_element_report_element_id_report_element",
                        column: x => x.idreportelement,
                        principalSchema: "golden_reports",
                        principalTable: "report_element",
                        principalColumn: "id_report_element",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "table_element",
                schema: "golden_reports",
                columns: table => new
                {
                    idreportelement = table.Column<Guid>(name: "id_report_element", type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableElement", x => x.idreportelement);
                    table.ForeignKey(
                        name: "fk_table_element_report_element_id_report_element",
                        column: x => x.idreportelement,
                        principalSchema: "golden_reports",
                        principalTable: "report_element",
                        principalColumn: "id_report_element",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "parameter_value",
                schema: "golden_reports",
                columns: table => new
                {
                    idparametervalue = table.Column<Guid>(name: "id_parameter_value", type: "uuid", nullable: false),
                    parameter = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    value = table.Column<string>(type: "character varying(750)", maxLength: 750, nullable: false),
                    idsubreportelement = table.Column<Guid>(name: "id_sub_report_element", type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParameterValue", x => x.idparametervalue);
                    table.ForeignKey(
                        name: "FK_ParameterValue_SubReportElement",
                        column: x => x.idsubreportelement,
                        principalSchema: "golden_reports",
                        principalTable: "sub_report_element",
                        principalColumn: "id_report_element",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "golden_reports",
                table: "namespace",
                columns: new[] { "id_namespace", "creation_date", "description", "modification_date", "name", "id_parent" },
                values: new object[] { new Guid("745e002d-9b7b-452c-9f1e-bcd439bde28f"), new DateTime(2022, 12, 21, 4, 18, 20, 850, DateTimeKind.Utc), "Global namespace", new DateTime(2022, 12, 21, 4, 18, 20, 850, DateTimeKind.Utc), "Global", null });

            migrationBuilder.CreateIndex(
                name: "ix_data_context_namespace_id",
                schema: "golden_reports",
                table: "data_context",
                column: "id_namespace");

            migrationBuilder.CreateIndex(
                name: "ix_data_source_namespace_id",
                schema: "golden_reports",
                table: "data_source",
                column: "id_namespace");

            migrationBuilder.CreateIndex(
                name: "ix_namespace_parent_id",
                schema: "golden_reports",
                table: "namespace",
                column: "id_parent");

            migrationBuilder.CreateIndex(
                name: "ix_parameter_value_id_sub_report_element",
                schema: "golden_reports",
                table: "parameter_value",
                column: "id_sub_report_element");

            migrationBuilder.CreateIndex(
                name: "ix_permission_namespace_id",
                table: "permission",
                column: "namespace_id");

            migrationBuilder.CreateIndex(
                name: "ix_report_definition_parent_id",
                schema: "golden_reports",
                table: "report_definition",
                column: "id_parent");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "barcode_element",
                schema: "golden_reports");

            migrationBuilder.DropTable(
                name: "box_element",
                schema: "golden_reports");

            migrationBuilder.DropTable(
                name: "data_context",
                schema: "golden_reports");

            migrationBuilder.DropTable(
                name: "data_source",
                schema: "golden_reports");

            migrationBuilder.DropTable(
                name: "image_element",
                schema: "golden_reports");

            migrationBuilder.DropTable(
                name: "label_element",
                schema: "golden_reports");

            migrationBuilder.DropTable(
                name: "list_element",
                schema: "golden_reports");

            migrationBuilder.DropTable(
                name: "namespace_asset",
                schema: "golden_reports");

            migrationBuilder.DropTable(
                name: "parameter_value",
                schema: "golden_reports");

            migrationBuilder.DropTable(
                name: "permission");

            migrationBuilder.DropTable(
                name: "report_asset",
                schema: "golden_reports");

            migrationBuilder.DropTable(
                name: "report_parameter",
                schema: "golden_reports");

            migrationBuilder.DropTable(
                name: "report_variable",
                schema: "golden_reports");

            migrationBuilder.DropTable(
                name: "table_element",
                schema: "golden_reports");

            migrationBuilder.DropTable(
                name: "sub_report_element",
                schema: "golden_reports");

            migrationBuilder.DropTable(
                name: "report_element",
                schema: "golden_reports");

            migrationBuilder.DropTable(
                name: "report_section",
                schema: "golden_reports");

            migrationBuilder.DropTable(
                name: "report_page",
                schema: "golden_reports");

            migrationBuilder.DropTable(
                name: "report_definition",
                schema: "golden_reports");

            migrationBuilder.DropTable(
                name: "namespace",
                schema: "golden_reports");
        }
    }
}
