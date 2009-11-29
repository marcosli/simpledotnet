﻿using System;
using System.Collections.Generic;
using System.Text;
using Simple.Patterns;
using Simple.Config;
using Simple.Common;
using NHibernate;

namespace Simple.DataAccess.Context
{
    public class DataContextFactory : AggregateFactory<DataContextFactory>, IDataContextFactory
    {
        ThreadData _data = new ThreadData();
        object _myKey = new object();

        public IDataContext EnterContext()
        {
            var contextList = GetContextList();
            var curContext = GetContext(false);

            Func<ISession> addCreator = () => Simply.Do[ConfigKey].OpenSession();
            Func<ISession> defCreator =
                (curContext == null ? addCreator : () => curContext.Session);

            var context = new DataContext(defCreator, addCreator, curContext == null);
            contextList.AddLast(context);

            return context;
        }

        public IDataContext GetContext()
        {
            return GetContext(true);
        }

        protected IDataContext GetContext(bool throwException)
        {
            var contextList = GetContextList();

            IDataContext context = null;
            while (contextList.Count > 0 && (context == null || !context.IsOpen))
            {
                context = contextList.Last.Value;
                if (!context.IsOpen) contextList.RemoveLast();
            }

            if (context != null && context.IsOpen) return context;
            else if (throwException) throw new InvalidOperationException("There is no open DataContext");
            else return null;
        }

        protected LinkedList<IDataContext> GetContextList()
        {
            var col = _data.Get<LinkedList<IDataContext>>(_myKey);
            if (col == null)
            {
                col = new LinkedList<IDataContext>();
                _data.Set(_myKey, col);
            }
            return col;
        }

        #region IDataContextFactory Members


        public NHibernate.ISession GetSession()
        {
            return GetContext().Session;
        }

        public NHibernate.ISession NewSession()
        {
            var context = GetContext(false);
            if (context == null)
            {
                throw new InvalidOperationException("There is no open datacontext");
            }
            else
            {
                return context.Session;
            }
        }

        #endregion
    }
}
