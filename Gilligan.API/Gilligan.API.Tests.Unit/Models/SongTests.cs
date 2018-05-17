using System.Collections.Generic;
using Gilligan.API.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Gilligan.API.Tests.Unit.Models
{
    [TestClass]
    public class SongTests
    {
        [TestMethod]
        public void CalculateAverageRating_NoParameter_CalculatesCorrectAverage()
        {
            // Arrange
            var song = new Song
            {
                Ratings = new List<Rating>
                {
                new Rating{Value = 2},
                new Rating{Value = 0},
                new Rating{Value = 4},
                new Rating{Value = 4},
                new Rating{Value = 0}
                }
            };
            const int expectedValue = 2;

            // Act
            song.CalculateAverageRating();
            var actualValue = song.AverageRating;

            // Assert
            Assert.AreEqual(expectedValue, actualValue);
        }
    }
}
