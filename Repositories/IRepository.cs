using System;
using System.Collections.Generic;

namespace GamersPlace.Repositories
{
    public interface IRepository<T>
    {
        T FindOneById(int id);
        T DeleteOneById(int id);
        T Insert(T item);
        T Update(T item);
        List<T> FindAll();
    }
}
