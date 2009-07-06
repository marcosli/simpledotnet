﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Simple.ConfigSource
{
    public class AggregateFactory<THIS>
        where THIS : AggregateFactory<THIS>, new()
    {
        protected AggregateFactory()
        {
        }
        protected object ConfigKey { get; private set; }

        static Dictionary<object, THIS> _instances = new Dictionary<object, THIS>();
        public static THIS Do
        {
            get
            {
                return Get(null);
            }
        }

        public static THIS Get(object key)
        {
            lock (_instances)
            {
                if (key == null) key = SourceManager.DefaultKey;

                THIS ret;
                if (!_instances.TryGetValue(key, out ret))
                {
                    ret = new THIS();
                    ret.ConfigKey = key;
                    _instances[key] = ret;
                }
                return ret;
            }
        }
    }
}