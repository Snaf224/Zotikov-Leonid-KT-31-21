using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Zotikov_Leonid_KT_31_21.Migrations
{
    /// <inheritdoc />
    public partial class CreateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cd_group",
                columns: table => new
                {
                    group_id = table.Column<int>(type: "integer", nullable: false, comment: "Идентификатор записи группы")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    c_group_name = table.Column<string>(type: "varchar", maxLength: 100, nullable: false, comment: "Название группы")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_group_group_id", x => x.group_id);
                });

            migrationBuilder.CreateTable(
                name: "cd_student",
                columns: table => new
                {
                    student_id = table.Column<int>(type: "integer", nullable: false, comment: "Идентификатор записи студента")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    c_student_firstname = table.Column<string>(type: "varchar", maxLength: 100, nullable: false, comment: "Имя студента"),
                    c_student_lastname = table.Column<string>(type: "varchar", maxLength: 100, nullable: false, comment: "Фамилия студента"),
                    c_student_middlename = table.Column<string>(type: "varchar", maxLength: 100, nullable: false, comment: "Отчество студента"),
                    f_group_id = table.Column<int>(type: "int4", nullable: false, comment: "Идентификатор группы")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_student_student_id", x => x.student_id);
                    table.ForeignKey(
                        name: "fk_f_group_id",
                        column: x => x.f_group_id,
                        principalTable: "cd_group",
                        principalColumn: "group_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cd_grade",
                columns: table => new
                {
                    grade_id = table.Column<int>(type: "integer", nullable: false, comment: "индентификатор записи оценок")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    c_grade_subject = table.Column<string>(type: "varchar", maxLength: 100, nullable: false, comment: "Название предмета"),
                    c_grade_score = table.Column<int>(type: "int4", maxLength: 100, nullable: false, comment: "Баллы"),
                    StudentId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_grade_grade_id", x => x.grade_id);
                    table.ForeignKey(
                        name: "FK_cd_grade_cd_student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "cd_student",
                        principalColumn: "student_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cd_subject",
                columns: table => new
                {
                    subject_id = table.Column<int>(type: "integer", nullable: false, comment: "Идентификатор предмета")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    c_subject_name = table.Column<string>(type: "varchar", maxLength: 100, nullable: false, comment: "Название предмета"),
                    StudentId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_subject_subject_id", x => x.subject_id);
                    table.ForeignKey(
                        name: "FK_cd_subject_cd_student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "cd_student",
                        principalColumn: "student_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cd_zachet",
                columns: table => new
                {
                    zachet_id = table.Column<int>(type: "integer", nullable: false, comment: "Идентификатор зачета")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    c_student_card = table.Column<string>(type: "varchar", maxLength: 100, nullable: false, comment: "Зачетная книжка"),
                    c_zachet_subject = table.Column<string>(type: "varchar", maxLength: 100, nullable: false, comment: "Зачетная книжка"),
                    c_name_teacher = table.Column<string>(type: "varchar", maxLength: 100, nullable: false, comment: "Имя преподавателя"),
                    StudentId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_zachet_zachet_id", x => x.zachet_id);
                    table.ForeignKey(
                        name: "FK_cd_zachet_cd_student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "cd_student",
                        principalColumn: "student_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_cd_grade_StudentId",
                table: "cd_grade",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "idx_cd_student_fk_f_group_id",
                table: "cd_student",
                column: "f_group_id");

            migrationBuilder.CreateIndex(
                name: "IX_cd_subject_StudentId",
                table: "cd_subject",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_cd_zachet_StudentId",
                table: "cd_zachet",
                column: "StudentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cd_grade");

            migrationBuilder.DropTable(
                name: "cd_subject");

            migrationBuilder.DropTable(
                name: "cd_zachet");

            migrationBuilder.DropTable(
                name: "cd_student");

            migrationBuilder.DropTable(
                name: "cd_group");
        }
    }
}
