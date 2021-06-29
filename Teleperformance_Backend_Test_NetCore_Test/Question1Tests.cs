using NUnit.Framework;
using System;
using System.Collections.Generic;
using Teleperformance_Backend_Test_NetCore;

namespace Teleperformance_Backend_Test_NetCore_Test
{
    public class Question1Tests
    {
        [SetUp]
        public void Setup()
        {
            // Do nothing
        }

        [Test]
        public void Restock_ItemCount_Is_NULL()
        {
            Assert.Throws(typeof(ArgumentException),
                () => Question1.Restock(null, 100));
        }

        [Test]
        public void Restock_ItemCount_Is_Empty()
        {
            Assert.Throws(typeof(ArgumentException),
                () => Question1.Restock(new List<int>(), 100));
        }

        [Test]
        public void Restock_Target_Is_0()
        {
            Assert.Throws(typeof(ArgumentException),
                () => Question1.Restock(new List<int> { 1, 2 }, 0));
        }

        [Test]
        public void Restock_ItemCount_Is_LessThan_0()
        {
            Assert.Throws(typeof(ArgumentException),
                () => Question1.Restock(new List<int> { 1, 2 }, -100));
        }

        [Test]
        public void Restock_ItemCount_NeedSell()
        {
            int number = Question1.Restock(new List<int> { 10, 20, 30, 40, 15 }, 80);
            Assert.AreEqual(20, number);
        }

        [Test]
        public void Restock_ItemCount_NeedBuy()
        {
            int number = Question1.Restock(new List<int> { 10, 20, 30, 40, 15 }, 120);
            Assert.AreEqual(-5, number);
        }

        [Test]
        public void Restock_ItemCount_NeedNothing()
        {
            int number = Question1.Restock(new List<int> { 10, 20, 30, 40, 15 }, 115);
            Assert.AreEqual(0, number);
        }

        [Test]
        public void Restock_ItemCount_Invalid_ItemCount_BeIngored()
        {
            int number = Question1.Restock(new List<int> { 10, 20, 0, -50, 30, 40, 15 }, 115);
            Assert.AreEqual(0, number);
        }

        [Test]
        public void Restock_ItemCount_Boundary_test()
        {
            int number = Question1.Restock(new List<int> { int.MaxValue - 10, int.MaxValue - 1, 30, 40, 15 }, int.MaxValue);
            Assert.AreEqual(int.MaxValue - 11, number);
        }
    }
}