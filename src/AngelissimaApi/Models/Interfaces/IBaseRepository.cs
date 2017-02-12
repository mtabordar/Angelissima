namespace AngelissimaApi.Models.Interfaces
{
    using System.Collections.Generic;

    public interface IBaseRepository<T>
    {
        void Add(T item);

        IEnumerable<T> GetAll();

        T Find(int id);

        void Remove(int id);

        void Update(T item);
    }
}
