﻿
namespace TestDataGenerator.Tests
{
    using System.Collections.Generic;
    using MbUnit.Framework;

    [TestFixture]
    public class ObjectDataTreeTests
    {
        class Sample
        {
            public readonly int f0 = 10;
            public int f1 = 20;

            private readonly string f2;
            private string f3;

            public Sample(string f2, string f3)
            {
                this.f2 = f2;
                this.f3 = f3;
            }

            public string F4 { get; set; }
            private string F5 { get; set; }

            public List<string> List { get; set; }

            public Sample[] Other { get; set; }
        }

        [Test]
        void Can_Parse_Simple_Class()
        {
            Catalog catalog = new Catalog();
            Sample instance = catalog.CreateInstance<Sample>();

            ObjectDataTree dataTree = new ObjectDataTree(instance);
            string asString = dataTree.StringValue();

            ObjectDataTree otherDataTree = new ObjectDataTree(instance);
            string otherString = otherDataTree.StringValue();

            Assert.IsNotEmpty(asString);
            Assert.IsNotEmpty(otherString);
            Assert.AreEqual(asString, otherString);
        }
    }
}
