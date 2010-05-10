﻿using Simple.Data.Context;

namespace Simple.Services
{
    public class DefaultCallHook : BaseCallHook
    {
        public object ConfigKey { get; protected set; }
        public IDataContext Context { get; protected set; }

        public DefaultCallHook(CallHookArgs args)
            : this(args, null) { }

        public DefaultCallHook(CallHookArgs args, object key)
            : base(args)
        {
            this.ConfigKey = key;
        }

        public override void Before()
        {
            Context = DataContextFactory.Do[ConfigKey].EnterContext();
        }

        public override void AfterSuccess()
        {
        }

        public override void Finally()
        {
            Context.Dispose();
        }
    }
}
