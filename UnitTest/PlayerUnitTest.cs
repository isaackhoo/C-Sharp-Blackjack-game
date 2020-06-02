using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using testCsharp.Model;

namespace UnitTest
{
    class PlayerUnitTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CreatesPlayerObject_ReturnsPlayer()
        {
            try
            {

                // Arrange
                const string playerName = "player1";

                // Act
                Player player = new Player(playerName);

                // Assert
                Assert.IsNotNull(player);
                Assert.AreEqual(player.Name, playerName);
            } catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
