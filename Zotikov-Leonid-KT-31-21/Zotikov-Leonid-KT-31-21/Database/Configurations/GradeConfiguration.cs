using Zotikov_Leonid_KT_31_21.Database.Helpers;
using Zotikov_Leonid_KT_31_21.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Zotikov_Leonid_KT_31_21.Database.Configurations
{
    public class GradeConfiguration : IEntityTypeConfiguration<Grade>
    {
        private const string TableName = "cd_grade";

        public void Configure(EntityTypeBuilder<Grade> builder)
        {
            //1 key
            builder
                .HasKey(p => p.GradeId)
                .HasName($"pk_{TableName}_grade_id");

            //ключ автогенерации
            builder.Property(p => p.GradeId)
                .ValueGeneratedOnAdd();

            //колонк в бд и их обязательства
            builder.Property(p => p.GradeId)
                .HasColumnName("grade_id")
                .HasComment("индентификатор записи оценок");

            //имя в субд(предмет)
            builder.Property(p => p.Subject)
                .IsRequired()
                .HasColumnName("c_grade_subject")
                .HasColumnType(ColumnType.String).HasMaxLength(100)
                .HasComment("Название предмета");

            //баллы
            builder.Property(p => p.Score)
                .HasColumnName("c_grade_score")
                .HasColumnType (ColumnType.Int).HasMaxLength(100)
                .HasComment("Баллы");


            builder.ToTable(TableName);
              

           
        }
    }
}
