using System.Collections.Generic;

namespace EnglishSchool.Interfaces
{
    public interface IRepository<T>
    {
        List<T> List();

        T ReturnById(int Id);

        void Insert(T entity);

        void DeactivateOrActivate(int Id, int value);

        void Update(int Id, T entity);

        int Next();

    }
}