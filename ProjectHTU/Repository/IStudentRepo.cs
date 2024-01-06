using ProjectHTU.Entities;
namespace ProjectHTU.Repository
{
    public interface IStudentRepo
    {
        public List<Student> GetAllstudents();
        public Task DeleteStudent(string Id);
        public Task UpdateStudent(Student student);
        public Task CreateStudent(Student student, string password, string roleIds);

    }
}
