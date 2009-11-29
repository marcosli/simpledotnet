﻿using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Simple.Reflection;
using Simple.Tests.SimpleLib.Sample;

namespace Simple.Tests.SimpleLib
{
    [TestFixture]
    public class AttributeCacheFixture
    {
        [Test]
        public void ClassAttributesFirstTest()
        {
            var attr1 = AttributeCache.Do.First<Attribute1Attribute>(typeof(AttributeTest));
            Assert.IsNotNull(attr1);

            var attr2 = AttributeCache.Do.First<Attribute2Attribute>(typeof(AttributeTest));
            Assert.IsNotNull(attr2);

            var attr3 = AttributeCache.Do.First<Attribute3Attribute>(typeof(AttributeTest));
            Assert.IsNull(attr3);
        }

        [Test]
        public void ClassAttributeEnumTest()
        {
            var attr1 = new List<Attribute1Attribute>(
                AttributeCache.Do.Enumerate<Attribute1Attribute>(typeof(AttributeTest)));
            Assert.AreEqual(2, attr1.Count);
        }

        [Test]
        public void PropAttributesFirstTest()
        {
            var attr1 = AttributeCache.Do.First<Attribute1Attribute>(typeof(AttributeTest).GetProperty("TestProp"));
            Assert.IsNull(attr1);

            var attr2 = AttributeCache.Do.First<Attribute2Attribute>(typeof(AttributeTest).GetProperty("TestProp"));
            Assert.IsNotNull(attr2);

            var attr3 = AttributeCache.Do.First<Attribute3Attribute>(typeof(AttributeTest).GetProperty("TestProp"));
            Assert.IsNotNull(attr3);
        }

        [Test]
        public void PropAttributeEnumTest()
        {
            var attr3 = new List<Attribute3Attribute>(
                AttributeCache.Do.Enumerate<Attribute3Attribute>(typeof(AttributeTest).GetProperty("TestProp")));
            Assert.AreEqual(2, attr3.Count);
        }
    }
}
