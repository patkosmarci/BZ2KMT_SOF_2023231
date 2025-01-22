using BZ2KMT_SOF_2023231.Models;

namespace BZ2KMT_SOF_2023231.Repository
{
    public interface ISchoolRepository
    {
        void Create(School _item);
        void Delete(int _id);
        School Read(int _id);
        School Read(string name);
        IQueryable<School> ReadAll();
        void Update(School _item);
    }
}