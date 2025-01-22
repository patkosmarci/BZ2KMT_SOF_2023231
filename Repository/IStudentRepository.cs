using BZ2KMT_SOF_2023231.Models;

namespace BZ2KMT_SOF_2023231.Repository
{
    public interface IStudentRepository
    {
        void Create(Student _item);
        void Delete(int _id);
        Student Read(int _id);
        IQueryable<Student> ReadAll();
        void Update(Student _item);
    }
}