using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ConsoleForTest
{
    [TestFixture]
    class ContestWinnerTests
    {
        private ContestWinner _contestWinner;

        [TestFixtureSetUp]
        public void Init()
        {
           _contestWinner  = new ContestWinner();

        }

        [TestFixtureTearDown]
        public void Dispose()
        { /* ... */
        }

        [Test]
        public void SingleWinnnerWithMaxTask()
        {
            int[] events = new[] {4, 7, 4, 10};
            
            int winner = _contestWinner.GetWinner(events);
            int winnerLinq = _contestWinner.GetWinnerLINQ(events);
            Assert.AreEqual(4, winner);
            Assert.AreEqual(4, winnerLinq);
        }

        [Test]
        public void TieMaxTaskWinnerAppearsFirst()
        {
            int[] events = new[] {1, 2, 3, 4, 5};
            int winner = _contestWinner.GetWinner(events);
            int winnerLinq = _contestWinner.GetWinnerLINQ(events);
            Assert.AreEqual(1, winner);
            Assert.AreEqual(1, winnerLinq);
        }

        [Test]
        public void TieMaxTaskWinnerAppearsNotFirst()
        {
            int[] events = new[] { 2, 3, 3, 2, 1, 1 };
            int winner = _contestWinner.GetWinner(events);
            int winnerLinq = _contestWinner.GetWinnerLINQ(events);
            Assert.AreEqual(3, winner);
            Assert.AreEqual(3, winnerLinq);

        }


    }
}
