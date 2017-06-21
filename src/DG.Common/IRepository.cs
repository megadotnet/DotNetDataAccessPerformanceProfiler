using System.Collections.Generic;

namespace DG.Common
{
    public interface IRepository<T>
    {
        List<T> GetAllBySortingAndPaged(SortDefinitions sortDefinitions, int startIndex, int pageSize);
        List<T> GetAllBySorting(SortDefinitions sortDefinitions);
        List<T> GetAll();
        long Insert(T item);
        void Update(T item);
        void Delete(T item);
    }
}
