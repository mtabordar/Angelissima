namespace AngelissimaApi.Core.Interfaces
{
    using System.Collections.Generic;

    public interface IBaseCore<T>
    {
        void Add(T item);

        IEnumerable<T> GetAll();

        T Find(int id);

        void Remove(int id);

        void Update(T item);
    }
}
