using Zotikov_Leonid_KT_31_21.Filters.StudentFilters;
using Zotikov_Leonid_KT_31_21.Models;
using Zotikov_Leonid_KT_31_21.Database;
using Microsoft.EntityFrameworkCore;

namespace Zotikov_Leonid_KT_31_21.Interfaces.StudentsInterfaces
{
    public interface IStudentService
    {
        public Task<Student[]> GetStudentsByGroupAsync(StudentGroupFilter filter, CancellationToken cancellationToken);
    }

    public class StudentService : IStudentService
    {
        private readonly StudentDbContext _dbContext;
        public StudentService(StudentDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<Student[]> GetStudentsByGroupAsync(StudentGroupFilter filter, CancellationToken cancellationToken = default)
        {
            var students = _dbContext.Set<Student>().Where(w => w.Group.GroupName == filter.GroupName).ToArrayAsync(cancellationToken);

            return students;
        }
    }
}
