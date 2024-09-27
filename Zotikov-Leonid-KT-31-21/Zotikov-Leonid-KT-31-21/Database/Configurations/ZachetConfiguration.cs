using Zotikov_Leonid_KT_31_21.Database.Helpers;
using Zotikov_Leonid_KT_31_21.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Zotikov_Leonid_KT_31_21.Database.Configurations
{
    public class ZachetConfiguration : IEntityTypeConfiguration<Zachet>
    {
        private const string TableName = "cd_zachet";

        public void Configure(EntityTypeBuilder<Zachet> builder)
        {
            //Задаем первичный ключ
            builder
                .HasKey(p => p.ZachetId)
                .HasName($"pk_{TableName}_zachet_id");

            //Для целочисленного первичного ключа задаем автогенерацию (к каждой новой записи будет добавлять +1)
            builder.Property(p => p.ZachetId)
                    .ValueGeneratedOnAdd();

            //Расписываем как будут называться колонки в БД, а так же их обязательность и тд
            builder.Property(p => p.ZachetId)
                .HasColumnName("zachet_id")
                .HasComment("Идентификатор зачета");

            //HasComment добавит комментарий, который будет отображаться в СУБД (добавлять по желанию)
            builder.Property(p => p.StudentCard)
                .IsRequired()
                .HasColumnName("c_student_card")
                .HasColumnType(ColumnType.String).HasMaxLength(100)
                .HasComment("Зачетная книжка");

            builder.Property(p => p.Subject)
               .IsRequired()
               .HasColumnName("c_zachet_subject")
               .HasColumnType(ColumnType.String).HasMaxLength(100)
               .HasComment("Зачетная книжка");

            builder.Property(p => p.NameTeacher)
              .HasColumnName("c_name_teacher")
              .HasColumnType(ColumnType.String).HasMaxLength(100)
              .HasComment("Имя преподавателя");

            
            builder.ToTable(TableName);
        }
    }
}
