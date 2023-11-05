using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Levels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Level_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Createdate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Levels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sexs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sex_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    createdate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sexs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StatusAs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusAs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StatusMs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    statusM_name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusMs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StatusPCs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    statusPC_name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusPCs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StatusUs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusU_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    createdate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusUs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TitleMs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TitleMs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Titles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    createdate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Titles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    User_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    User_lastname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    User_cardnumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    User_birthdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    User_placeofbirth = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    User_race = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    User_nationality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    User_religion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Field = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Createdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    id_title = table.Column<int>(type: "int", nullable: false),
                    id_statusU = table.Column<int>(type: "int", nullable: false),
                    id_sex = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Sexs_id_sex",
                        column: x => x.id_sex,
                        principalTable: "Sexs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_StatusUs_id_statusU",
                        column: x => x.id_statusU,
                        principalTable: "StatusUs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_Titles_id_title",
                        column: x => x.id_title,
                        principalTable: "Titles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Academicpositions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    academic_position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    academic_branchcode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    academic_branchname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    academic_startdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    academic_refer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    File = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Createdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Academicpositions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Academicpositions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Activities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Activi_startdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Activi_enddate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Activi_placename = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Activi_position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    createdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Activities_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Addresss",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    address_startdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    address_enddate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    address_housenumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    address_alley = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    address_road = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    address_canton = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    address_district = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    address_province = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    address_country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Createdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    id_statusA = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresss", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresss_StatusAs_id_statusA",
                        column: x => x.id_statusA,
                        principalTable: "StatusAs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Addresss_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Arrests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Arrest_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Arrest_crimescene = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Arrest_plaint = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Arrest_outcomeofthecase = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Createdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Arrests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Arrests_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Childrens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Child_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Child_lastname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Child_birthdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Child_race = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Child_nationlyty = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Child_religion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Chaild_address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Child_occupation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Child_position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Child_workplace = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Child_phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Createdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    id_title = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Childrens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Childrens_Titles_id_title",
                        column: x => x.id_title,
                        principalTable: "Titles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Childrens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Educations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Educa_startdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Educa_enddate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Educa_placename = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Educa_location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Educa_course = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Educa_results = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    File = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Createdat = table.Column<DateTime>(type: "datetime2", nullable: false),
                    id_level = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Educations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Educations_Levels_id_level",
                        column: x => x.id_level,
                        principalTable: "Levels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Educations_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FatherAndMothers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fa_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fa_lastname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fa_birthdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fa_placebirth = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fa_race = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fa_religion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fa_nationality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fa_address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fa_phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fa_occupation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fa_position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fa_workplace = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fa_WPphone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    mo_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    mo_lastname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    mo_birthdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    mo_placebirth = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    mo_race = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    mo_religion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    mo_nationality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    mo_address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    mo_phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    mo_occupation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    mo_position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    mo_workplace = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    mo_WPphone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Createdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Fa_title = table.Column<int>(type: "int", nullable: false),
                    MO_title = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FatherAndMothers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FatherAndMothers_TitleMs_MO_title",
                        column: x => x.MO_title,
                        principalTable: "TitleMs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FatherAndMothers_Titles_Fa_title",
                        column: x => x.Fa_title,
                        principalTable: "Titles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FatherAndMothers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Insignias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    insignia_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    insignia_year = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    insignia_receiveddate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Createdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Insignias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Insignias_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Managementpositions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    manageP_position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    manageP_agency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    manageP_details = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    manageP_startdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    manageP_enddate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    manageP_refer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Createdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    id_statusS = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Managementpositions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Managementpositions_Statuses_id_statusS",
                        column: x => x.id_statusS,
                        principalTable: "Statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Managementpositions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Marriages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    marria_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    marria_lastname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    marria_birdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    marria_race = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    marria_religion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    marria_nationality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    marria_occupation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    marria_position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    marria_workplace = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    marria_WPphone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    marriia_weddingday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    marria_address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    marria_phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    marria_divorce = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    marria_lastaddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Createdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    id_title = table.Column<int>(type: "int", nullable: false),
                    id_statusPC = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marriages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Marriages_StatusPCs_id_statusPC",
                        column: x => x.id_statusPC,
                        principalTable: "StatusPCs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Marriages_Titles_id_title",
                        column: x => x.id_title,
                        principalTable: "Titles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Marriages_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Petitions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    peti_message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    File = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    peti_staus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Createdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Petitions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Petitions_Users_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReportLeaves",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReportL_lastyear = table.Column<float>(type: "real", nullable: false),
                    ReportL_thisyear = table.Column<float>(type: "real", nullable: false),
                    ReportL_leavesick = table.Column<float>(type: "real", nullable: false),
                    ReportL_leavepersonal = table.Column<float>(type: "real", nullable: false),
                    ReportL_leavematerntity = table.Column<int>(type: "int", nullable: false),
                    ReportL_leaveTHHWWGB = table.Column<int>(type: "int", nullable: false),
                    ReportL_leave = table.Column<float>(type: "real", nullable: false),
                    ReportL_leaveordination = table.Column<int>(type: "int", nullable: false),
                    ReportL_leaveforfasting = table.Column<int>(type: "int", nullable: false),
                    ReportL_leavespouse = table.Column<int>(type: "int", nullable: false),
                    ReportL_leaveforstudy = table.Column<int>(type: "int", nullable: false),
                    createdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportLeaves", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReportLeaves_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Salarys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    salary_details = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    salary_ordernum = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    salary_datenum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    salary_effectivedate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    salary_enddate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    salary_salary = table.Column<float>(type: "real", nullable: false),
                    salary_beforepostpone = table.Column<int>(type: "int", nullable: false),
                    salary_percentage = table.Column<float>(type: "real", nullable: false),
                    salary_calculationbase = table.Column<int>(type: "int", nullable: false),
                    Createdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    id_starusS = table.Column<int>(type: "int", nullable: false),
                    id_TypeS = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salarys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Salarys_Statuses_id_starusS",
                        column: x => x.id_starusS,
                        principalTable: "Statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Salarys_TypeS_id_TypeS",
                        column: x => x.id_TypeS,
                        principalTable: "TypeS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Salarys_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Travels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    travel_startdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    travel_enddate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    travel_city = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    travel_county = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    travel_purpose = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    travel_capital = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cratedate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Travels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Travels_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "WorkHistories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkH_startdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WorkH_enddate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WorkH_employer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkH_placename = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkH_position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkH_reason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    createdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkHistories_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Leaves",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    leave_type = table.Column<int>(type: "int", nullable: false),
                    leave_quantity = table.Column<float>(type: "real", nullable: false),
                    leave_startdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    leave_enddate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    leave_note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    createdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReportLeaveId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leaves", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Leaves_ReportLeaves_ReportLeaveId",
                        column: x => x.ReportLeaveId,
                        principalTable: "ReportLeaves",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Levels",
                columns: new[] { "Id", "Createdate", "Level_name" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 3, 22, 16, 50, 4, 169, DateTimeKind.Local).AddTicks(8729), "ประถมศึกษา 6" },
                    { 2, new DateTime(2023, 3, 22, 16, 50, 4, 169, DateTimeKind.Local).AddTicks(8731), "มัธยมศึกษา 3" },
                    { 3, new DateTime(2023, 3, 22, 16, 50, 4, 169, DateTimeKind.Local).AddTicks(8732), "มัธยมศึกษา 6" },
                    { 4, new DateTime(2023, 3, 22, 16, 50, 4, 169, DateTimeKind.Local).AddTicks(8733), "ปริญญาตรี" },
                    { 5, new DateTime(2023, 3, 22, 16, 50, 4, 169, DateTimeKind.Local).AddTicks(8734), "ปริญญาโทร" },
                    { 6, new DateTime(2023, 3, 22, 16, 50, 4, 169, DateTimeKind.Local).AddTicks(8735), "ปริญญาเอก" }
                });

            migrationBuilder.InsertData(
                table: "Sexs",
                columns: new[] { "Id", "Sex_name", "createdate" },
                values: new object[,]
                {
                    { 1, "ชาย", new DateTime(2023, 3, 22, 16, 50, 4, 169, DateTimeKind.Local).AddTicks(8704) },
                    { 2, "หญิง", new DateTime(2023, 3, 22, 16, 50, 4, 169, DateTimeKind.Local).AddTicks(8707) }
                });

            migrationBuilder.InsertData(
                table: "StatusAs",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "เคยอาศัย" },
                    { 2, "อาศัยในปัจจุบัน" }
                });

            migrationBuilder.InsertData(
                table: "StatusPCs",
                columns: new[] { "Id", "statusPC_name" },
                values: new object[,]
                {
                    { 1, "ครั้งก่อน" },
                    { 2, "ปัจจุบัน" }
                });

            migrationBuilder.InsertData(
                table: "StatusUs",
                columns: new[] { "Id", "StatusU_name", "createdate" },
                values: new object[,]
                {
                    { 1, "ข้าราชการ", new DateTime(2023, 3, 22, 16, 50, 4, 169, DateTimeKind.Local).AddTicks(8775) },
                    { 2, "พนักงานข้าราชการ", new DateTime(2023, 3, 22, 16, 50, 4, 169, DateTimeKind.Local).AddTicks(8777) },
                    { 3, "เจ้าหน้าที่", new DateTime(2023, 3, 22, 16, 50, 4, 169, DateTimeKind.Local).AddTicks(8778) }
                });

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "ครั้งก่อน" },
                    { 2, "ปัจจุบัน" }
                });

            migrationBuilder.InsertData(
                table: "Titles",
                columns: new[] { "Id", "Title_name", "createdate" },
                values: new object[,]
                {
                    { 1, "เด็กชาย", new DateTime(2023, 3, 22, 16, 50, 4, 169, DateTimeKind.Local).AddTicks(8474) },
                    { 2, "เด็กหญิง", new DateTime(2023, 3, 22, 16, 50, 4, 169, DateTimeKind.Local).AddTicks(8487) },
                    { 3, "นาย", new DateTime(2023, 3, 22, 16, 50, 4, 169, DateTimeKind.Local).AddTicks(8488) },
                    { 4, "นาง", new DateTime(2023, 3, 22, 16, 50, 4, 169, DateTimeKind.Local).AddTicks(8489) },
                    { 5, "นางสาว", new DateTime(2023, 3, 22, 16, 50, 4, 169, DateTimeKind.Local).AddTicks(8490) }
                });

            migrationBuilder.InsertData(
                table: "TypeS",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "เลื่อนขั้นเงินเดือนปกติ" },
                    { 2, "เลื่อนขั้นเงินเดือนพิเศษ" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Academicpositions_UserId",
                table: "Academicpositions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_UserId",
                table: "Activities",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresss_id_statusA",
                table: "Addresss",
                column: "id_statusA");

            migrationBuilder.CreateIndex(
                name: "IX_Addresss_UserId",
                table: "Addresss",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Arrests_UserId",
                table: "Arrests",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Childrens_id_title",
                table: "Childrens",
                column: "id_title");

            migrationBuilder.CreateIndex(
                name: "IX_Childrens_UserId",
                table: "Childrens",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Educations_id_level",
                table: "Educations",
                column: "id_level");

            migrationBuilder.CreateIndex(
                name: "IX_Educations_UserId",
                table: "Educations",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FatherAndMothers_Fa_title",
                table: "FatherAndMothers",
                column: "Fa_title");

            migrationBuilder.CreateIndex(
                name: "IX_FatherAndMothers_MO_title",
                table: "FatherAndMothers",
                column: "MO_title");

            migrationBuilder.CreateIndex(
                name: "IX_FatherAndMothers_UserId",
                table: "FatherAndMothers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Insignias_UserId",
                table: "Insignias",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Leaves_ReportLeaveId",
                table: "Leaves",
                column: "ReportLeaveId");

            migrationBuilder.CreateIndex(
                name: "IX_Managementpositions_id_statusS",
                table: "Managementpositions",
                column: "id_statusS");

            migrationBuilder.CreateIndex(
                name: "IX_Managementpositions_UserId",
                table: "Managementpositions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Marriages_id_statusPC",
                table: "Marriages",
                column: "id_statusPC");

            migrationBuilder.CreateIndex(
                name: "IX_Marriages_id_title",
                table: "Marriages",
                column: "id_title");

            migrationBuilder.CreateIndex(
                name: "IX_Marriages_UserId",
                table: "Marriages",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Petitions_AuthorId",
                table: "Petitions",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_ReportLeaves_UserId",
                table: "ReportLeaves",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Salarys_id_starusS",
                table: "Salarys",
                column: "id_starusS");

            migrationBuilder.CreateIndex(
                name: "IX_Salarys_id_TypeS",
                table: "Salarys",
                column: "id_TypeS");

            migrationBuilder.CreateIndex(
                name: "IX_Salarys_UserId",
                table: "Salarys",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Travels_UserId",
                table: "Travels",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_id_sex",
                table: "Users",
                column: "id_sex");

            migrationBuilder.CreateIndex(
                name: "IX_Users_id_statusU",
                table: "Users",
                column: "id_statusU");

            migrationBuilder.CreateIndex(
                name: "IX_Users_id_title",
                table: "Users",
                column: "id_title");

            migrationBuilder.CreateIndex(
                name: "IX_WorkHistories_UserId",
                table: "WorkHistories",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Academicpositions");

            migrationBuilder.DropTable(
                name: "Activities");

            migrationBuilder.DropTable(
                name: "Addresss");

            migrationBuilder.DropTable(
                name: "Arrests");

            migrationBuilder.DropTable(
                name: "Childrens");

            migrationBuilder.DropTable(
                name: "Educations");

            migrationBuilder.DropTable(
                name: "FatherAndMothers");

            migrationBuilder.DropTable(
                name: "Insignias");

            migrationBuilder.DropTable(
                name: "Leaves");

            migrationBuilder.DropTable(
                name: "Managementpositions");

            migrationBuilder.DropTable(
                name: "Marriages");

            migrationBuilder.DropTable(
                name: "Petitions");

            migrationBuilder.DropTable(
                name: "Salarys");

            migrationBuilder.DropTable(
                name: "StatusMs");

            migrationBuilder.DropTable(
                name: "Travels");

            migrationBuilder.DropTable(
                name: "WorkHistories");

            migrationBuilder.DropTable(
                name: "StatusAs");

            migrationBuilder.DropTable(
                name: "Levels");

            migrationBuilder.DropTable(
                name: "TitleMs");

            migrationBuilder.DropTable(
                name: "ReportLeaves");

            migrationBuilder.DropTable(
                name: "StatusPCs");

            migrationBuilder.DropTable(
                name: "Statuses");

            migrationBuilder.DropTable(
                name: "TypeS");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Sexs");

            migrationBuilder.DropTable(
                name: "StatusUs");

            migrationBuilder.DropTable(
                name: "Titles");
        }
    }
}
