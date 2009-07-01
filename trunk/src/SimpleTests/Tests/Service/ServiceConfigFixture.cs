﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Simple.ConfigSource;
using Simple.Services;
using Simple.Client;

namespace Simple.Tests.ConfigSource
{
    [TestClass]
    public class ServiceObjectsFixture
    {
        [TestMethod]
        public void TestNullServiceCreation()
        {
            SourceManager.RemoveSource<IServiceClientProvider>(this);
            var svc = Simply.Connect<ITestClientConnector>();

            Assert.AreEqual(0, svc.TestInt());
            Assert.AreEqual(null, svc.TestString());
        }
    }

    public interface ITestClientConnector
    {
        int TestInt();
        string TestString();
    }
}
