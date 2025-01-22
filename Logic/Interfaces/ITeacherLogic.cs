using BZ2KMT_SOF_2023231.Models;
using System.Linq;

namespace BZ2KMT_SOF_2023231.Logic
{
    public interface ITeacherLogic
    {
        void Create(Teacher _item);
        void Delete(int _id);
        Teacher LeastPaidTeacher();
        Teacher MostPaidTeacher();
        Teacher Read(int _id);
        IQueryable<Teacher> ReadAll();
        Teacher ReadName(string _name);
        void Update(Teacher _teacher);
    }
}