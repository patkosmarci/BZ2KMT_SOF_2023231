using BZ2KMT_SOF_2023231.Models;

namespace BZ2KMT_SOF_2023231.Repository
{
    public interface ITeacherRepository
    {
        void Create(Teacher _item);
        void Delete(int _id);
        Teacher Read(int _id);
        IQueryable<Teacher> ReadAll();
        void Update(Teacher _item);
    }
}