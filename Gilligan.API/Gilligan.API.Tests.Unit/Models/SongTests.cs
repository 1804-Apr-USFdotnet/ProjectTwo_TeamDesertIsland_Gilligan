﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Gilligan.API.Models;
using System.Collections.Generic;

namespace Gilligan.API.Tests.Unit
{
    [TestClass]
    public class SongTests
    {
        [TestMethod]
        public void CalculateAverageRating_NoParameter_CalculatesCorrectAverage()
        {
            // Arrange
            var song = new Song();
            song.Ratings = new List<Rating>
            {
                new Rating{Value = 2},
                new Rating{Value = 0},
                new Rating{Value = 4},
                new Rating{Value = 4},
                new Rating{Value = 0}
            };
            var expectedValue = 2;

            // Act
            song.CalculateAverageRating();
            var actualValue = song.AverageRating;

            // Assert
            Assert.AreEqual(expectedValue, actualValue);
        }
    }
}
