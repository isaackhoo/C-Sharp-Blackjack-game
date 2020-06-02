using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using NUnit.Framework;
using testCsharp.Model.Decks;

namespace UnitTest.Decks
{
    public class ActiveDeckUnitTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void InitializesActiveDeck_ReturnsVoid()
        {
            // Arrange
            ActiveDeck activeDeck = new ActiveDeck();

            // Act

            // Assert
            Assert.AreEqual(0, activeDeck.getCount());
        }

        [Test]
        public void Create52CardDeck_ReturnsVoid()
        {
            // Arrange
            ActiveDeck activeDeck = new ActiveDeck();

            // Act
            activeDeck.createDeck();

            // Assert
            Assert.AreEqual(52, activeDeck.getCount());
        }

        [Test]
        public void CreateMultipleDeck_ReturnsVoid()
        {
            // Arrange
            const int NumberOfDecks = 3;
            ActiveDeck activeDeck = new ActiveDeck();

            // Act
            activeDeck.createDeck(NumberOfDecks);

            // Assert
            Assert.AreEqual(52 * NumberOfDecks, activeDeck.getCount());
        }

        [Test]
        public void RandomCardDraw_ReturnsVoid()
        {
            // Arrange
            const int CARDS_DRAWN = 3;
            List<List<Card>> drawSeq = new List<List<Card>>();

            // Act
            for (int i = 0; i < 2; i++)
            {
                drawSeq.Add(new List<Card>());
                ActiveDeck activeDeck = new ActiveDeck();
                activeDeck.createDeck(); // creates a fresh deck of 52 cards of the same sequence
                // draw 3 cards
                for (int j = 0; j < CARDS_DRAWN; j++)
                    drawSeq[i].Add(activeDeck.drawCard());
            }

            // determine sequencing
            bool equalSequence = true;
            for (int cardSequence = 0; cardSequence < CARDS_DRAWN; cardSequence++)
            {
                if (drawSeq[0][cardSequence].getId() != drawSeq[1][cardSequence].getId())
                {
                    equalSequence = false;
                    break;
                }
            }

            // Assert
            Assert.IsFalse(equalSequence);
        }
    }
}
