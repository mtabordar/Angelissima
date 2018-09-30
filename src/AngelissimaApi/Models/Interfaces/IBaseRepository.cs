namespace AngelissimaApi.Models.Interfaces
{
    using System.Collections.Generic;

    public interface IBaseRepository<T>
    {
        void Add(T item);

        void AddRange(IEnumerable<T> items);

        IEnumerable<T> GetAll();

        T Find(int id);        

        void Remove(int id);

        void Remove(T entity);

        void Update(T item);

        void SaveChanges();
    }
}
