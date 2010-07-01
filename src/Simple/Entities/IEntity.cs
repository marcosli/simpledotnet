﻿using System;
using System.Linq.Expressions;
using Simple.Validation;

namespace Simple.Entities
{
    public interface IEntity
    {
    }
    public interface IEntity<T> : IEntity
    {
        T Clone();
        T Refresh();
        T Reload();
        T Merge();
        T Evict();
        T Persist();
        T Save();
        T Update();
        void Delete();
        T SaveOrUpdate();
        ValidationList Validate();
        ValidationList Validate(params string[] propName);
        ValidationList Validate<P>(params Expression<Func<T, P>>[] expr);
    }

}
