using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kata_DeadAnts
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void String_ant_Should_Be_Zero()
        {
            DeadAntsCountShouldBeEqual("ant", 0);
        }

        [TestMethod]
        public void String_antant_Should_Be_Zero()
        {
            DeadAntsCountShouldBeEqual("antant", 0);
        }

        [TestMethod]
        public void String_Empty_Should_Be_Zero()
        {
            DeadAntsCountShouldBeEqual(string.Empty, 0);
        }

        [TestMethod]
        public void String_Null_Should_Be_Zero()
        {
            DeadAntsCountShouldBeEqual(null, 0);
        }

        [TestMethod]
        public void String_antantantant_Should_Be_Zero()
        {
            DeadAntsCountShouldBeEqual("ant ant ant ant", 0);
        }

        [TestMethod]
        public void String_Should_Be_Two()
        {
            DeadAntsCountShouldBeEqual("ant ant .... a nt", 1);
        }

        [TestMethod]
        public void BasicTests()
        {
            //Assert.AreEqual(0, Kata.DeadAntCount("ant ant ant ant"));
            //Assert.AreEqual(0, Kata.DeadAntCount(null));
            //Assert.AreEqual(2, Kata.DeadAntCount("ant anantt aantnt"));
            //Assert.AreEqual(1, Kata.DeadAntCount("ant ant .... a nt"));
        }

        private static void DeadAntsCountShouldBeEqual(string antsStr, int expected)
        {
            Kata deadAnts = new Kata();
            var result = deadAnts.DeadAntCount(antsStr);
            Assert.AreEqual(expected, result);
        }
       
    }

    public class Kata
    {
        public int DeadAntCount(string antsStr)
        {
            if (string.IsNullOrEmpty(antsStr))
            {
                return 0;
            }

            var deadAnts = antsStr.Replace("ant", "").Where(x => x == 'a' || x == 'n' || x == 't');

            return !deadAnts.Any() ? 0 : deadAnts.GroupBy(x => x).Max(group => group.Count());
        }

    }
}
