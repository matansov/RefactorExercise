using Microsoft.VisualStudio.TestTools.UnitTesting;
using RefactorExercise;
using System.Collections.Generic;

namespace UnitTests
{
    [TestClass]
    public class GoalieStatisticsTest
    {
        public double TOLERANCE = 0.001;

        [TestMethod]
        public void NoGamesInSeasonEnsureZeroGoalsAgainstAverage()
        {
            // arrange phase
            Season season = new Season();

            // act phase
            GoalieStatistics statistics = season.getGoalieStatistics();

            // assert phase
            Assert.AreEqual(0.0, statistics.getGoalsAgainstAverage());
        }

        [TestMethod]
        public void NoGamesInSeasonEnsureZeroSavePercentage()
        {
            // arrange phase
            Season season = new Season();

            // act phase
            GoalieStatistics statistics = season.getGoalieStatistics();

            // assert phase
            Assert.AreEqual(0.0, statistics.getSavePercentage());
        }

        [TestMethod]
        public void OneGameInSeasonEnsureCorrectGoalsAgainstAverage()
        {
            // arrange phase
            Season season = new Season();

            // act phase
            season.addGame(new Game(3, 10, 60.0));
            GoalieStatistics statistics = season.getGoalieStatistics();

            // assert phase
            Assert.AreEqual(3.0, statistics.getGoalsAgainstAverage());
        }

        [TestMethod]
        public void OneGameInSeasonEnsureCorrectSavePercantage()
        {
            // arrange phase
            Season season = new Season();

            // act phase
            season.addGame(new Game(3, 10, 60.0));
            GoalieStatistics statistics = season.getGoalieStatistics();

            // assert phase
            Assert.AreEqual(0.7, statistics.getSavePercentage());
        }

        [TestMethod]
        public void MultipleGamesInSeasonEnsureCorrectGoalsAgainstAverage()
        {
            // arrange phase
            Season season = new Season();

            // act phase
            season.addGame(new Game(3, 10, 60.0));
            season.addGame(new Game(2, 17, 90.0));
            GoalieStatistics statistics = season.getGoalieStatistics();

            // assert phase
            Assert.AreEqual(2, statistics.getGoalsAgainstAverage());
        }

        [TestMethod]
        public void MultipleGamesInSeasonEnsureCorrectSavePercentage()
        {
            // arrange phase
            Season season = new Season();

            // act phase
            season.addGame(new Game(3, 10, 60.0));
            season.addGame(new Game(2, 17, 90.0));
            GoalieStatistics statistics = season.getGoalieStatistics();

            // assert phase
            Assert.AreEqual(0.8139, statistics.getSavePercentage(), TOLERANCE);
        }
    }
}