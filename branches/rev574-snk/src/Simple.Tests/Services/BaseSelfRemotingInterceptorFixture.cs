﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Simple.Services.Remoting;
using Simple.Config;
using Simple.Services;
using NUnit.Framework;
using System.Threading;
using System.Diagnostics;
using System.Reflection;

namespace Simple.Tests.Services
{
    public abstract class BaseSelfRemotingServerInterceptorFixture : BaseSelfRemotingInterceptorFixture
    {
        protected override Guid Configure()
        {
            Guid guid = base.Configure();
            ConfigureServerHooks(guid);
            ConfigureClientServerHooks(guid);
            return guid;
        }
        [Test, Ignore("still cannot call some generic methods in service without error")]
        public override void TestGenericInt()
        {
            base.TestGenericInt();
        }

    }

    public abstract class BaseSelfRemotingClientInterceptorFixture : BaseSelfRemotingInterceptorFixture
    {
        protected override Guid Configure()
        {
            Guid guid = base.Configure();
            ConfigureClientHooks(guid);
            return guid;
        }
    }

    public abstract class BaseSelfRemotingInterceptorFixture : BaseInterceptorFixture
    {
        public abstract Uri Uri { get; }

        protected override Guid Configure()
        {
            Guid guid = Guid.NewGuid();

            Simply.Do[guid].Configure
                .Remoting().FromXmlString(Helper.MakeConfig(Uri));

            ConfigureSvcsWithoutHooks(guid);

            return guid;
        }

        protected override void Release(Guid guid)
        {
            Simply.Do[guid].StopServer();
        }
    }
}