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
                name: "user",
                schema: "golden_reports",
                columns: table => new
                {
                    iduser = table.Column<Guid>(name: "id_user", type: "uuid", nullable: false),
                    authcontextkey = table.Column<string>(name: "auth_context_key", type: "character varying(200)", maxLength: 200, nullable: false),
                    firstname = table.Column<string>(name: "first_name", type: "character varying(50)", maxLength: 50, nullable: false),
                    lastname = table.Column<string>(name: "last_name", type: "character varying(50)", maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    idcreatedby = table.Column<Guid>(name: "id_created_by", type: "uuid", nullable: true),
                    creationdate = table.Column<DateTime>(name: "creation_date", type: "timestamp with time zone", nullable: false),
                    idmodifiedby = table.Column<Guid>(name: "id_modified_by", type: "uuid", nullable: true),
                    modificationdate = table.Column<DateTime>(name: "modification_date", type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.iduser);
                    table.UniqueConstraint("UK_User", x => x.authcontextkey);
                    table.ForeignKey(
                        name: "FK_User_User_CreatedBy",
                        column: x => x.idcreatedby,
                        principalSchema: "golden_reports",
                        principalTable: "user",
                        principalColumn: "id_user");
                    table.ForeignKey(
                        name: "FK_User_User_ModifiedBy",
                        column: x => x.idmodifiedby,
                        principalSchema: "golden_reports",
                        principalTable: "user",
                        principalColumn: "id_user");
                });

            migrationBuilder.CreateTable(
                name: "namespace",
                schema: "golden_reports",
                columns: table => new
                {
                    idnamespace = table.Column<Guid>(name: "id_namespace", type: "uuid", nullable: false),
                    idparent = table.Column<Guid>(name: "id_parent", type: "uuid", nullable: true),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    description = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    idcreatedby = table.Column<Guid>(name: "id_created_by", type: "uuid", nullable: true),
                    creationdate = table.Column<DateTime>(name: "creation_date", type: "timestamp with time zone", nullable: false),
                    idmodifiedby = table.Column<Guid>(name: "id_modified_by", type: "uuid", nullable: true),
                    modificationdate = table.Column<DateTime>(name: "modification_date", type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Namespace", x => x.idnamespace);
                    table.ForeignKey(
                        name: "FK_Namespace_Namespace",
                        column: x => x.idparent,
                        principalSchema: "golden_reports",
                        principalTable: "namespace",
                        principalColumn: "id_namespace");
                    table.ForeignKey(
                        name: "FK_Namespace_User_CreatedBy",
                        column: x => x.idcreatedby,
                        principalSchema: "golden_reports",
                        principalTable: "user",
                        principalColumn: "id_user");
                    table.ForeignKey(
                        name: "FK_Namespace_User_ModifiedBy",
                        column: x => x.idmodifiedby,
                        principalSchema: "golden_reports",
                        principalTable: "user",
                        principalColumn: "id_user");
                });

            migrationBuilder.CreateTable(
                name: "data_context",
                schema: "golden_reports",
                columns: table => new
                {
                    iddatacontext = table.Column<Guid>(name: "id_data_context", type: "uuid", nullable: false),
                    idnamespace = table.Column<Guid>(name: "id_namespace", type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    schema = table.Column<string>(type: "character varying(10000)", maxLength: 10000, nullable: false),
                    idcreatedby = table.Column<Guid>(name: "id_created_by", type: "uuid", nullable: true),
                    creationdate = table.Column<DateTime>(name: "creation_date", type: "timestamp with time zone", nullable: false),
                    idmodifiedby = table.Column<Guid>(name: "id_modified_by", type: "uuid", nullable: true),
                    modificationdate = table.Column<DateTime>(name: "modification_date", type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataContext", x => x.iddatacontext);
                    table.ForeignKey(
                        name: "FK_DataContext_Namespace",
                        column: x => x.idnamespace,
                        principalSchema: "golden_reports",
                        principalTable: "namespace",
                        principalColumn: "id_namespace",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DataContext_User_CreatedBy",
                        column: x => x.idcreatedby,
                        principalSchema: "golden_reports",
                        principalTable: "user",
                        principalColumn: "id_user");
                    table.ForeignKey(
                        name: "FK_DataContext_User_ModifiedBy",
                        column: x => x.idmodifiedby,
                        principalSchema: "golden_reports",
                        principalTable: "user",
                        principalColumn: "id_user");
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
                    idcreatedby = table.Column<Guid>(name: "id_created_by", type: "uuid", nullable: true),
                    creationdate = table.Column<DateTime>(name: "creation_date", type: "timestamp with time zone", nullable: false),
                    idmodifiedby = table.Column<Guid>(name: "id_modified_by", type: "uuid", nullable: true),
                    modificationdate = table.Column<DateTime>(name: "modification_date", type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataSource", x => x.iddatasource);
                    table.ForeignKey(
                        name: "FK_DataSource_Namespace",
                        column: x => x.idnamespace,
                        principalSchema: "golden_reports",
                        principalTable: "namespace",
                        principalColumn: "id_namespace",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DataSource_User_CreatedBy",
                        column: x => x.idcreatedby,
                        principalSchema: "golden_reports",
                        principalTable: "user",
                        principalColumn: "id_user");
                    table.ForeignKey(
                        name: "FK_DataSource_User_ModifiedBy",
                        column: x => x.idmodifiedby,
                        principalSchema: "golden_reports",
                        principalTable: "user",
                        principalColumn: "id_user");
                });

            migrationBuilder.CreateTable(
                name: "namespace_asset",
                schema: "golden_reports",
                columns: table => new
                {
                    idnamespaceasset = table.Column<Guid>(name: "id_namespace_asset", type: "uuid", nullable: false),
                    idnamespace = table.Column<Guid>(name: "id_namespace", type: "uuid", nullable: false),
                    idcreatedby = table.Column<Guid>(name: "id_created_by", type: "uuid", nullable: true),
                    creationdate = table.Column<DateTime>(name: "creation_date", type: "timestamp with time zone", nullable: false),
                    idmodifiedby = table.Column<Guid>(name: "id_modified_by", type: "uuid", nullable: true),
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
                    table.ForeignKey(
                        name: "FK_NamespaceAsset_User_CreatedBy",
                        column: x => x.idcreatedby,
                        principalSchema: "golden_reports",
                        principalTable: "user",
                        principalColumn: "id_user");
                    table.ForeignKey(
                        name: "FK_NamespaceAsset_User_ModifiedBy",
                        column: x => x.idmodifiedby,
                        principalSchema: "golden_reports",
                        principalTable: "user",
                        principalColumn: "id_user");
                });

            migrationBuilder.CreateTable(
                name: "permission",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    namespaceid = table.Column<Guid>(name: "namespace_id", type: "uuid", nullable: true),
                    createdbyid = table.Column<Guid>(name: "created_by_id", type: "uuid", nullable: true),
                    creationdate = table.Column<DateTime>(name: "creation_date", type: "timestamp with time zone", nullable: false),
                    modifiedbyid = table.Column<Guid>(name: "modified_by_id", type: "uuid", nullable: true),
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
                    table.ForeignKey(
                        name: "fk_permission_users_created_by_id",
                        column: x => x.createdbyid,
                        principalSchema: "golden_reports",
                        principalTable: "user",
                        principalColumn: "id_user");
                    table.ForeignKey(
                        name: "fk_permission_users_modified_by_id",
                        column: x => x.modifiedbyid,
                        principalSchema: "golden_reports",
                        principalTable: "user",
                        principalColumn: "id_user");
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
                    template = table.Column<string>(type: "text", nullable: true),
                    idcreatedby = table.Column<Guid>(name: "id_created_by", type: "uuid", nullable: true),
                    creationdate = table.Column<DateTime>(name: "creation_date", type: "timestamp with time zone", nullable: false),
                    idmodifiedby = table.Column<Guid>(name: "id_modified_by", type: "uuid", nullable: true),
                    modificationdate = table.Column<DateTime>(name: "modification_date", type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportDefinition", x => x.idreportdefinition);
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
                    table.ForeignKey(
                        name: "FK_ReportDefinition_User_CreatedBy",
                        column: x => x.idcreatedby,
                        principalSchema: "golden_reports",
                        principalTable: "user",
                        principalColumn: "id_user");
                    table.ForeignKey(
                        name: "FK_ReportDefinition_User_ModifiedBy",
                        column: x => x.idmodifiedby,
                        principalSchema: "golden_reports",
                        principalTable: "user",
                        principalColumn: "id_user");
                });

            migrationBuilder.CreateTable(
                name: "report_asset",
                schema: "golden_reports",
                columns: table => new
                {
                    idreportasset = table.Column<Guid>(name: "id_report_asset", type: "uuid", nullable: false),
                    idreport = table.Column<Guid>(name: "id_report", type: "uuid", nullable: false),
                    idcreatedby = table.Column<Guid>(name: "id_created_by", type: "uuid", nullable: true),
                    creationdate = table.Column<DateTime>(name: "creation_date", type: "timestamp with time zone", nullable: false),
                    idmodifiedby = table.Column<Guid>(name: "id_modified_by", type: "uuid", nullable: true),
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
                    table.ForeignKey(
                        name: "FK_ReportAsset_User_CreatedBy",
                        column: x => x.idcreatedby,
                        principalSchema: "golden_reports",
                        principalTable: "user",
                        principalColumn: "id_user");
                    table.ForeignKey(
                        name: "FK_ReportAsset_User_ModifiedBy",
                        column: x => x.idmodifiedby,
                        principalSchema: "golden_reports",
                        principalTable: "user",
                        principalColumn: "id_user");
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
                    idcreatedby = table.Column<Guid>(name: "id_created_by", type: "uuid", nullable: true),
                    creationdate = table.Column<DateTime>(name: "creation_date", type: "timestamp with time zone", nullable: false),
                    idmodifiedby = table.Column<Guid>(name: "id_modified_by", type: "uuid", nullable: true),
                    modificationdate = table.Column<DateTime>(name: "modification_date", type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportParameter", x => x.idreportparameter);
                    table.ForeignKey(
                        name: "FK_ReportParameter_ReportDefinition",
                        column: x => x.idreport,
                        principalSchema: "golden_reports",
                        principalTable: "report_definition",
                        principalColumn: "id_report_definition",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReportParameter_User_CreatedBy",
                        column: x => x.idcreatedby,
                        principalSchema: "golden_reports",
                        principalTable: "user",
                        principalColumn: "id_user");
                    table.ForeignKey(
                        name: "FK_ReportParameter_User_ModifiedBy",
                        column: x => x.idmodifiedby,
                        principalSchema: "golden_reports",
                        principalTable: "user",
                        principalColumn: "id_user");
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
                    idcreatedby = table.Column<Guid>(name: "id_created_by", type: "uuid", nullable: true),
                    creationdate = table.Column<DateTime>(name: "creation_date", type: "timestamp with time zone", nullable: false),
                    idmodifiedby = table.Column<Guid>(name: "id_modified_by", type: "uuid", nullable: true),
                    modificationdate = table.Column<DateTime>(name: "modification_date", type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportVariable", x => x.idreportvariable);
                    table.ForeignKey(
                        name: "FK_ReportVariable_ReportDefinition",
                        column: x => x.idreport,
                        principalSchema: "golden_reports",
                        principalTable: "report_definition",
                        principalColumn: "id_report_definition",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReportVariable_User_CreatedBy",
                        column: x => x.idcreatedby,
                        principalSchema: "golden_reports",
                        principalTable: "user",
                        principalColumn: "id_user");
                    table.ForeignKey(
                        name: "FK_ReportVariable_User_ModifiedBy",
                        column: x => x.idmodifiedby,
                        principalSchema: "golden_reports",
                        principalTable: "user",
                        principalColumn: "id_user");
                });

            migrationBuilder.InsertData(
                schema: "golden_reports",
                table: "namespace",
                columns: new[] { "id_namespace", "id_created_by", "creation_date", "description", "modification_date", "id_modified_by", "name", "id_parent" },
                values: new object[] { new Guid("745e002d-9b7b-452c-9f1e-bcd439bde28f"), null, new DateTime(2022, 12, 21, 4, 18, 20, 850, DateTimeKind.Utc), "Global namespace", new DateTime(2022, 12, 21, 4, 18, 20, 850, DateTimeKind.Utc), null, "Global", null });

            migrationBuilder.InsertData(
                schema: "golden_reports",
                table: "user",
                columns: new[] { "id_user", "auth_context_key", "id_created_by", "creation_date", "email", "first_name", "last_name", "modification_date", "id_modified_by" },
                values: new object[] { new Guid("83a661ae-9e59-4777-b3ef-bf3586f7798e"), "golden-reports-system-user", null, new DateTime(2022, 12, 21, 4, 18, 20, 850, DateTimeKind.Utc), null, "System", "User", new DateTime(2022, 12, 21, 4, 18, 20, 850, DateTimeKind.Utc), null });

            migrationBuilder.CreateIndex(
                name: "ix_data_context_created_by_id",
                schema: "golden_reports",
                table: "data_context",
                column: "id_created_by");

            migrationBuilder.CreateIndex(
                name: "ix_data_context_modified_by_id",
                schema: "golden_reports",
                table: "data_context",
                column: "id_modified_by");

            migrationBuilder.CreateIndex(
                name: "IX_DataContext_Name",
                schema: "golden_reports",
                table: "data_context",
                columns: new[] { "id_namespace", "name" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_data_source_created_by_id",
                schema: "golden_reports",
                table: "data_source",
                column: "id_created_by");

            migrationBuilder.CreateIndex(
                name: "ix_data_source_modified_by_id",
                schema: "golden_reports",
                table: "data_source",
                column: "id_modified_by");

            migrationBuilder.CreateIndex(
                name: "IX_DataSource_Code",
                schema: "golden_reports",
                table: "data_source",
                column: "code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DataSource_Name",
                schema: "golden_reports",
                table: "data_source",
                columns: new[] { "id_namespace", "name" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_namespace_created_by_id",
                schema: "golden_reports",
                table: "namespace",
                column: "id_created_by");

            migrationBuilder.CreateIndex(
                name: "ix_namespace_modified_by_id",
                schema: "golden_reports",
                table: "namespace",
                column: "id_modified_by");

            migrationBuilder.CreateIndex(
                name: "IX_Namespace_Name",
                schema: "golden_reports",
                table: "namespace",
                columns: new[] { "id_parent", "name" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_namespace_asset_created_by_id",
                schema: "golden_reports",
                table: "namespace_asset",
                column: "id_created_by");

            migrationBuilder.CreateIndex(
                name: "ix_namespace_asset_modified_by_id",
                schema: "golden_reports",
                table: "namespace_asset",
                column: "id_modified_by");

            migrationBuilder.CreateIndex(
                name: "ix_permission_created_by_id",
                table: "permission",
                column: "created_by_id");

            migrationBuilder.CreateIndex(
                name: "ix_permission_modified_by_id",
                table: "permission",
                column: "modified_by_id");

            migrationBuilder.CreateIndex(
                name: "ix_permission_namespace_id",
                table: "permission",
                column: "namespace_id");

            migrationBuilder.CreateIndex(
                name: "ix_report_asset_created_by_id",
                schema: "golden_reports",
                table: "report_asset",
                column: "id_created_by");

            migrationBuilder.CreateIndex(
                name: "ix_report_asset_modified_by_id",
                schema: "golden_reports",
                table: "report_asset",
                column: "id_modified_by");

            migrationBuilder.CreateIndex(
                name: "ix_report_definition_created_by_id",
                schema: "golden_reports",
                table: "report_definition",
                column: "id_created_by");

            migrationBuilder.CreateIndex(
                name: "ix_report_definition_modified_by_id",
                schema: "golden_reports",
                table: "report_definition",
                column: "id_modified_by");

            migrationBuilder.CreateIndex(
                name: "ix_report_definition_parent_id",
                schema: "golden_reports",
                table: "report_definition",
                column: "id_parent");

            migrationBuilder.CreateIndex(
                name: "IX_ReportDefinition_Name",
                schema: "golden_reports",
                table: "report_definition",
                columns: new[] { "id_namespace", "name" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_report_parameter_created_by_id",
                schema: "golden_reports",
                table: "report_parameter",
                column: "id_created_by");

            migrationBuilder.CreateIndex(
                name: "ix_report_parameter_modified_by_id",
                schema: "golden_reports",
                table: "report_parameter",
                column: "id_modified_by");

            migrationBuilder.CreateIndex(
                name: "UK_ReportParameter_Name",
                schema: "golden_reports",
                table: "report_parameter",
                columns: new[] { "id_report", "name" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_report_variable_created_by_id",
                schema: "golden_reports",
                table: "report_variable",
                column: "id_created_by");

            migrationBuilder.CreateIndex(
                name: "ix_report_variable_modified_by_id",
                schema: "golden_reports",
                table: "report_variable",
                column: "id_modified_by");

            migrationBuilder.CreateIndex(
                name: "UK_ReportVariable_Name",
                schema: "golden_reports",
                table: "report_variable",
                columns: new[] { "id_report", "name" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_user_id_created_by",
                schema: "golden_reports",
                table: "user",
                column: "id_created_by");

            migrationBuilder.CreateIndex(
                name: "ix_user_modified_by_id",
                schema: "golden_reports",
                table: "user",
                column: "id_modified_by");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "data_context",
                schema: "golden_reports");

            migrationBuilder.DropTable(
                name: "data_source",
                schema: "golden_reports");

            migrationBuilder.DropTable(
                name: "namespace_asset",
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
                name: "report_definition",
                schema: "golden_reports");

            migrationBuilder.DropTable(
                name: "namespace",
                schema: "golden_reports");

            migrationBuilder.DropTable(
                name: "user",
                schema: "golden_reports");
        }
    }
}
