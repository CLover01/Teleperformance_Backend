using NUnit.Framework;
using System;
using Teleperformance_Backend_Test_NetCore;

namespace Teleperformance_Backend_Test_NetCore_Test
{
    public class Question3Tests
    {
        [SetUp]
        public void Setup()
        {
            // Do nothing
        }

        [Test]
        public void Reverse_InputString_Is_NULL()
        {
            Assert.Throws(typeof(ArgumentNullException),
                () => Question3.Reverse(null));
        }

        [Test]
        public void Restock_InputString_Is_Empty()
        {
            var testString = string.Empty;
            var result = Question3.Reverse(testString.ToCharArray());

            Assert.AreEqual(testString.ToCharArray(), result);
        }

        [Test]
        public void Restock_InputString_Has_One_Character()
        {
            var testString = "a";
            var result = Question3.Reverse(testString.ToCharArray());

            Assert.AreEqual(testString.ToCharArray(), result);
        }

        [Test]
        public void Restock_InputString_Have_Odd_Character()
        {
            var testString = "abcdefgh129";
            var result = Question3.Reverse(testString.ToCharArray());

            Assert.AreEqual("921hgfedcba".ToCharArray(), result);
        }

        [Test]
        public void Restock_InputString_Have_Even_Character()
        {
            var testString = "abcdefgh1290";
            var result = Question3.Reverse(testString.ToCharArray());

            Assert.AreEqual("0921hgfedcba".ToCharArray(), result);
        }
    }
}