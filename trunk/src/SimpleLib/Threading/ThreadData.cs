﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Simple.Threading
{
    public class ThreadData
    {
        object defaultKey = new object();

        public ThreadData()
        {
        }

        public Dictionary<object, object> GetStorage()
        {
            lock (this)
            {
                var store = Thread.GetNamedDataSlot(this.GetType().GUID.ToString());
                var dic = (Dictionary<object, object>)Thread.GetData(store);
                if (dic == null)
                {
                    dic = new Dictionary<object, object>();
                    Thread.SetData(store, dic);
                }
                return dic;
            }
        }

        public T Get<T>(object key)
        {
            lock (this)
            {
                if (key == null) key = defaultKey;

                try
                {
                    return (T)GetStorage()[key];
                }
                catch (KeyNotFoundException)
                {
                    return default(T);
                }
            }
        }

        public void Set(object key, object value)
        {
            lock (this)
            {
                if (key == null) key = defaultKey;

                GetStorage()[key] = value;
            }
        }

        public void Remove(object key)
        {
            lock (this)
            {
                if (key == null) key = defaultKey;

                GetStorage().Remove(key);
            }
        }
    }
}