using practice1.Models;

namespace practice1.Repository.Interface
{
    public interface IStudentInterface
    {
        public Task<int> AddStudentRepo(Student data);

        //public Task<int> UpdateStudentRepo(Student data);

        public Task<List<Student>> GetAllStudentRepo();

        //public Task<Student> GetStudentByIdRepo(int Id);

        //public Task<int> DeleteStudentRepo(int Id);
    }
}
