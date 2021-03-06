﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace FC.Repositories
{
    /// <summary>
    /// Defines interface for common data access functionality for entity.
    /// </summary>
    /// <typeparam name="TType">Type of entity.</typeparam>
    public interface IRepository<TType>
    {
        void SaveChanges(TType entity);

        //bool Update(TType entity);

        //bool Delete(TType entity);

        TType Get(int id);

        IEnumerable<TType> GetAll();
    }
}